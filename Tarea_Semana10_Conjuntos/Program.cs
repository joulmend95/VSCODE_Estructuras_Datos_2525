using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();

        // Se crean 500 ciudadanos ficticios
        HashSet<string> ciudadanos = new HashSet<string>();
        for (int i = 1; i <= 500; i++)
        {
            ciudadanos.Add("Ciudadano " + i);
        }

        // Se generan 75 ciudadanos vacunados con Pfizer
        HashSet<string> pfizer = new HashSet<string>();
        for (int i = 0; i < 75; i++)
        {
            pfizer.Add("Ciudadano " + random.Next(1, 501));
        }

        // Se generan 75 ciudadanos vacunados con AstraZeneca
        HashSet<string> astrazeneca = new HashSet<string>();
        for (int i = 0; i < 75; i++)
        {
            astrazeneca.Add("Ciudadano " + random.Next(1, 501));
        }

        // Ciudadanos con ambas dosis (intersección entre Pfizer y AstraZeneca)
        HashSet<string> ambasDosis = new HashSet<string>(pfizer);
        ambasDosis.IntersectWith(astrazeneca);

        // Ciudadanos que solo recibieron Pfizer (Pfizer menos AstraZeneca)
        HashSet<string> soloPfizer = new HashSet<string>(pfizer);
        soloPfizer.ExceptWith(astrazeneca);

        // Ciudadanos que solo recibieron AstraZeneca (AstraZeneca menos Pfizer)
        HashSet<string> soloAstra = new HashSet<string>(astrazeneca);
        soloAstra.ExceptWith(pfizer);

        // Ciudadanos que no se vacunaron (todos menos los que aparecen en Pfizer o AstraZeneca)
        HashSet<string> vacunados = new HashSet<string>(pfizer);
        vacunados.UnionWith(astrazeneca);
        HashSet<string> noVacunados = new HashSet<string>(ciudadanos);
        noVacunados.ExceptWith(vacunados);

        // Mostrar resultados detallados
        Console.WriteLine("=== Ciudadanos con ambas dosis ===");
        foreach (var item in ambasDosis) Console.WriteLine(item);

        Console.WriteLine("\n=== Ciudadanos solo con Pfizer ===");
        foreach (var item in soloPfizer) Console.WriteLine(item);

        Console.WriteLine("\n=== Ciudadanos solo con AstraZeneca ===");
        foreach (var item in soloAstra) Console.WriteLine(item);

        Console.WriteLine("\n=== Ciudadanos no vacunados ===");
        foreach (var item in noVacunados) Console.WriteLine(item);

        // Mostrar un pequeño resumen con cantidades
        Console.WriteLine("\n=== RESUMEN ===");
        Console.WriteLine($"Total de ciudadanos: {ciudadanos.Count}");
        Console.WriteLine($"Vacunados con Pfizer: {pfizer.Count}");
        Console.WriteLine($"Vacunados con AstraZeneca: {astrazeneca.Count}");
        Console.WriteLine($"Con ambas dosis: {ambasDosis.Count}");
        Console.WriteLine($"Solo Pfizer: {soloPfizer.Count}");
        Console.WriteLine($"Solo AstraZeneca: {soloAstra.Count}");
        Console.WriteLine($"No vacunados: {noVacunados.Count}");
        
        Console.WriteLine("\nPresiona cualquier tecla para salir...");
        Console.ReadKey();
    }
}



