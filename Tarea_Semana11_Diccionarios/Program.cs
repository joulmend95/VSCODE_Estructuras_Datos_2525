public class Traductor
{
    public static void Run()
    {
        // Diccionario inglés-español
        System.Collections.Generic.Dictionary<string, string> diccionarioIngEsp =
            new System.Collections.Generic.Dictionary<string, string>(System.StringComparer.OrdinalIgnoreCase)
            {
                {"time", "tiempo"},
                {"person", "persona"},
                {"year", "año"},
                {"way", "camino"},
                {"day", "día"},
                {"thing", "cosa"},
                {"man", "hombre"},
                {"world", "mundo"},
                {"life", "vida"},
                {"hand", "mano"},
                {"part", "parte"},
                {"child", "niño/a"},
                {"eye", "ojo"},
                {"woman", "mujer"},
                {"place", "lugar"},
                {"work", "trabajo"},
                {"week", "semana"},
                {"case", "caso"},
                {"point", "punto"},
                {"government", "gobierno"},
                {"company", "empresa"}
            };

        // Diccionario español-inglés (inverso)
        System.Collections.Generic.Dictionary<string, string> diccionarioEspIng =
            new System.Collections.Generic.Dictionary<string, string>(System.StringComparer.OrdinalIgnoreCase);
        foreach (var palabra in diccionarioIngEsp)
        {
            diccionarioEspIng[palabra.Value] = palabra.Key;
        }

        int opcion;
        do
        {
            System.Console.WriteLine("Universidad Estatal Amazónica");
            System.Console.WriteLine("======================");
            System.Console.WriteLine("1. Traducir del inglés al español");
            System.Console.WriteLine("2. Traducir del español al inglés");
            System.Console.WriteLine("3. Agregar palabras al diccionario");
            System.Console.WriteLine("0. Salir");
            System.Console.Write("Seleccione una opción: ");

            if (!System.Int32.TryParse(System.Console.ReadLine(), out opcion))
            {
                System.Console.WriteLine("Opción no válida. Intente de nuevo.");
                continue;
            }

            if (opcion == 1)
            {
                System.Console.Write("Ingrese la frase en inglés a traducir: ");
                string frase = System.Console.ReadLine() ?? "";
                string traduccion = TraducirFrase(frase, diccionarioIngEsp);
                System.Console.WriteLine("Traducción: " + traduccion);
            }
            else if (opcion == 2)
            {
                System.Console.Write("Ingrese la frase en español a traducir: ");
                string frase = System.Console.ReadLine() ?? "";
                string traduccion = TraducirFrase(frase, diccionarioEspIng);
                System.Console.WriteLine("Traducción: " + traduccion);
            }
            else if (opcion == 3)
            {
                System.Console.Write("Ingrese la palabra en inglés: ");
                string ingles = (System.Console.ReadLine() ?? "").Trim().ToLower();
                System.Console.Write("Ingrese su traducción al español: ");
                string espanol = (System.Console.ReadLine() ?? "").Trim().ToLower();
                if (!diccionarioIngEsp.ContainsKey(ingles))
                {
                    diccionarioIngEsp.Add(ingles, espanol);
                    diccionarioEspIng.Add(espanol, ingles); // Agregar también al diccionario inverso
                    System.Console.WriteLine("Palabra agregada correctamente.");
                }
                else
                {
                    System.Console.WriteLine("La palabra ya existe en el diccionario.");
                }
            }
            else if (opcion == 0)
            {
                System.Console.WriteLine("Saliendo del programa...");
            }
            else
            {
                System.Console.WriteLine("Opción no válida. Intente de nuevo.");
            }

        } while (opcion != 0);
    }

    public static string TraducirFrase(string frase, System.Collections.Generic.Dictionary<string, string> diccionario)
    {
        if (string.IsNullOrEmpty(frase))
            return "";

        string[] palabras = frase.Split(' ');
        for (int i = 0; i < palabras.Length; i++)
        {
            string palabraOriginal = palabras[i];
            
            // Remover signos de puntuación del inicio y final
            string palabraLimpia = palabras[i].Trim('¿', '¡', '"', '\'', '(', ')', '.', ',', ';', ':', '!', '?');
            
            // Encontrar los signos antes y después
            string signoInicio = "";
            string signoFinal = "";
            
            int inicioLimpia = palabraOriginal.IndexOf(palabraLimpia);
            if (inicioLimpia > 0)
            {
                signoInicio = palabraOriginal.Substring(0, inicioLimpia);
            }
            
            int finalLimpia = inicioLimpia + palabraLimpia.Length;
            if (finalLimpia < palabraOriginal.Length)
            {
                signoFinal = palabraOriginal.Substring(finalLimpia);
            }
            
            string palabraMinuscula = palabraLimpia.ToLower();

            if (!string.IsNullOrEmpty(palabraLimpia) && diccionario.ContainsKey(palabraMinuscula))
            {
                palabras[i] = signoInicio + diccionario[palabraMinuscula] + signoFinal;
            }
        }
        return string.Join(" ", palabras);
    }

    public static void Main(string[] args)
    {
        Run();
    }
}
