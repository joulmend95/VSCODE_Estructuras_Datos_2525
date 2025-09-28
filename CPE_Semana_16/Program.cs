Console.WriteLine("Calculo de centralidades");

var g = new Grafo(6);
g.AgregarArista(0, 1);
g.AgregarArista(0, 2);
g.AgregarArista(1, 2);
g.AgregarArista(1, 3);
g.AgregarArista(2, 4);
g.AgregarArista(3, 4);
g.AgregarArista(3, 5);
g.AgregarArista(4, 5);

g.MostrarGrafo();

var grado = g.CentralidadGrado();
var cercania = g.CentralidadCercania();
var inter = g.CentralidadIntermediacion();
var vector = g.CentralidadVectorPropio();

Console.WriteLine("\nResultados:");
comparar(grado, cercania, inter, vector);

static void comparar(Dictionary<int, double> g1, Dictionary<int, double> g2, Dictionary<int, double> g3, Dictionary<int, double> g4)
{
    Console.WriteLine("Nodo | Grado | Cercania | Inter | Vector");
    Console.WriteLine("----|-------|----------|-------|--------");
    
    for (int i = 0; i < g1.Count; i++)
    {
        Console.WriteLine($" {i}  | {g1[i]:F1}   |   {g2[i]:F2}   | {g3[i]:F1} |  {g4[i]:F2}");
    }
}

public class Grafo
{
    private Dictionary<int, List<int>> adj;
    private int n;

    public Grafo(int vertices)
    {
        n = vertices;
        adj = new Dictionary<int, List<int>>();
        
        for (int i = 0; i < vertices; i++)
            adj[i] = new List<int>();
    }

    public void AgregarArista(int a, int b)
    {
        adj[a].Add(b);
        adj[b].Add(a);
    }

    public Dictionary<int, double> CentralidadGrado()
    {
        var datos = new Dictionary<int, double>();
        for (int i = 0; i < n; i++)
            datos[i] = adj[i].Count;
        return datos;
    }

    private Dictionary<int, int> Dijkstra(int origen)
    {
        var dist = new Dictionary<int, int>();
        var vis = new HashSet<int>();
        var cola = new SortedSet<(int d, int v)>();

        for (int i = 0; i < n; i++)
            dist[i] = int.MaxValue;
        
        dist[origen] = 0;
        cola.Add((0, origen));

        while (cola.Count > 0)
        {
            var (d, v) = cola.Min;
            cola.Remove(cola.Min);

            if (vis.Contains(v))
                continue;

            vis.Add(v);

            foreach (var vecino in adj[v])
            {
                int nd = dist[v] + 1;
                if (nd < dist[vecino])
                {
                    dist[vecino] = nd;
                    cola.Add((nd, vecino));
                }
            }
        }

        return dist;
    }

    public Dictionary<int, double> CentralidadCercania()
    {
        var datos = new Dictionary<int, double>();

        for (int i = 0; i < n; i++)
        {
            var dist = Dijkstra(i);
            double suma = 0;
            int cnt = 0;

            foreach (var kvp in dist)
            {
                if (kvp.Value != int.MaxValue && kvp.Key != i)
                {
                    suma += kvp.Value;
                    cnt++;
                }
            }

            datos[i] = cnt > 0 ? cnt / suma : 0;
        }

        return datos;
    }

    private List<List<int>> buscarCaminos(int origen, int destino)
    {
        var caminos = new List<List<int>>();
        var cola = new Queue<List<int>>();
        var vis = new Dictionary<int, int>();
        
        cola.Enqueue(new List<int> { origen });
        vis[origen] = 0;
        int minDist = int.MaxValue;

        while (cola.Count > 0)
        {
            var path = cola.Dequeue();
            var nodo = path.Last();

            if (path.Count - 1 > minDist)
                continue;

            if (nodo == destino)
            {
                if (path.Count - 1 < minDist)
                {
                    minDist = path.Count - 1;
                    caminos.Clear();
                }
                if (path.Count - 1 == minDist)
                {
                    caminos.Add(new List<int>(path));
                }
                continue;
            }

            foreach (var vecino in adj[nodo])
            {
                if (!path.Contains(vecino) && 
                    (!vis.ContainsKey(vecino) || vis[vecino] >= path.Count))
                {
                    vis[vecino] = path.Count;
                    var newPath = new List<int>(path) { vecino };
                    cola.Enqueue(newPath);
                }
            }
        }

        return caminos;
    }

    public Dictionary<int, double> CentralidadIntermediacion()
    {
        var datos = new Dictionary<int, double>();
        
        for (int i = 0; i < n; i++)
            datos[i] = 0.0;

        for (int s = 0; s < n; s++)
        {
            for (int t = s + 1; t < n; t++)
            {
                var caminos = buscarCaminos(s, t);
                
                if (caminos.Count > 0)
                {
                    var cont = new Dictionary<int, int>();
                    foreach (var path in caminos)
                        for (int i = 1; i < path.Count - 1; i++)
                            cont[path[i]] = cont.GetValueOrDefault(path[i], 0) + 1;

                    foreach (var kvp in cont)
                        datos[kvp.Key] += (double)kvp.Value / caminos.Count;
                }
            }
        }

        return datos;
    }

    public Dictionary<int, double> CentralidadVectorPropio(int maxIter = 100, double tol = 1e-6)
    {
        var datos = new Dictionary<int, double>();
        var vAnt = new double[n];
        var vAct = new double[n];

        for (int i = 0; i < n; i++)
            vAct[i] = 1.0 / Math.Sqrt(n);

        for (int iter = 0; iter < maxIter; iter++)
        {
            Array.Copy(vAct, vAnt, n);
            Array.Fill(vAct, 0.0);

            for (int i = 0; i < n; i++)
                foreach (var vecino in adj[i])
                    vAct[i] += vAnt[vecino];

            double norma = Math.Sqrt(vAct.Sum(x => x * x));
            if (norma > 0)
                for (int i = 0; i < n; i++)
                    vAct[i] /= norma;

            double dif = 0;
            for (int i = 0; i < n; i++)
                dif += Math.Abs(vAct[i] - vAnt[i]);

            if (dif < tol)
                break;
        }

        for (int i = 0; i < n; i++)
            datos[i] = Math.Abs(vAct[i]);

        return datos;
    }

    public void MostrarGrafo()
    {
        Console.WriteLine("\nGrafo:");
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Nodo {i}: ");
            Console.WriteLine(string.Join(" -> ", adj[i]));
        }
    }
}
