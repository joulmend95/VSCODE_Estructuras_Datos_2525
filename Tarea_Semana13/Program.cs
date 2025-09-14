

// Lista inicial de revistas
List<string> revistas = new List<string>()
{
    "Mundo Cientifico",
    "Horizontes Globales",
    "Ciencia y Sociedad",
    "Conexion Cultural",
    "Innovacion del Hoy",
    "Saberes y Descubrimientos",
    "Tendencias del Futuro",
    "Arte y Creatividad",
    "Perspectiva Moderna",
    "Naturaleza Viva",
    "Programadores Orientados"
};

// Ordenamos la lista para poder usar búsqueda binaria
revistas.Sort(StringComparer.OrdinalIgnoreCase);

// Funcion recursiva de busqueda binaria.
// Devuelve el indice donde esta el texto o -1 si no esta.
int BuscarRec(List<string> lista, string texto, int inicio, int fin)
{
    if (inicio > fin)
        return -1; 

    int medio = (inicio + fin) / 2;
    int cmp = string.Compare(lista[medio], texto, StringComparison.OrdinalIgnoreCase);

    if (cmp == 0)
        return medio;
    else if (cmp > 0)
        return BuscarRec(lista, texto, inicio, medio - 1); // ir a la izquierda
    else
        return BuscarRec(lista, texto, medio + 1, fin); // ir a la derecha
}

// Muestra la lista completa
void VerLista()
{
    Console.WriteLine();
    Console.WriteLine("Listado de revistas (" + revistas.Count + "):");
    for (int i = 0; i < revistas.Count; i++)
    {
        Console.WriteLine((i + 1) + ". " + revistas[i]);
    }
}

// Agrega una nueva revista si no existe
void Agregar()
{
    Console.Write("Escribe el titulo nuevo: ");
    string? t = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(t))
    {
        Console.WriteLine("Dato vacio. No se agrega.");
        return;
    }

    t = t.Trim();
    // Revisar si ya existe
    int pos = BuscarRec(revistas, t, 0, revistas.Count - 1);
    if (pos >= 0)
    {
        Console.WriteLine("Ya estaba en la lista.");
        return;
    }

    revistas.Add(t);
    // Se vuelve a ordenar para que la busqueda funcione siempre
    revistas.Sort(StringComparer.OrdinalIgnoreCase);
    Console.WriteLine("Se agrego correctamente.");
}

// Busca un titulo y muestra mensaje
void Buscar()
{
    Console.Write("Titulo a buscar: ");
    string? t = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(t))
    {
        Console.WriteLine("Entrada vacia.");
        return;
    }
    int pos = BuscarRec(revistas, t.Trim(), 0, revistas.Count - 1);
    if (pos >= 0)
        Console.WriteLine("Si esta en la lista.");
    else
        Console.WriteLine("No se encontro.");
}

// Muestra el menu simple
void Menu()
{
    Console.WriteLine();
    Console.WriteLine("====MENU CATALOGO====");
    Console.WriteLine("1. Buscar revista");
    Console.WriteLine("2. Ver lista de revistas");
    Console.WriteLine("3. Agregar revista");
    Console.WriteLine("0. Salir");
    Console.Write("Elige opcion: ");
}

// Bucle principal
while (true)
{
    Menu();
    string? op = Console.ReadLine();
    if (op == null) continue;

    if (op == "1")
        Buscar();
    else if (op == "2")
        VerLista();
    else if (op == "3")
        Agregar();
    else if (op == "0")
    {
        Console.WriteLine("Gracias! Vuelva Pronto!");
        break;
    }
    else
        Console.WriteLine("Opcion no valida.");
}
