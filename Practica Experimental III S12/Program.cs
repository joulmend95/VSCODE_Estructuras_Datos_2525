// Componente Práctico Experimental III
// Implementación de conjuntos y mapas

// Este programa implementa un sistema de registro de libros para una biblioteca.
// Permite registrar libros, consultarlos por ID y mostrar el catálogo completo.

// Clase que representa un libro con sus propiedades principales
    public class Libro
    {
        public string Titulo { get; set; } = string.Empty; // Título del libro
        public string Autor { get; set; } = string.Empty;  // Autor del libro
        public int AnioPublicacion { get; set; }          // Año de publicación

        // Método para mostrar la información del libro en formato legible
        public override string ToString()
        {
            return $"Título: {Titulo}, Autor: {Autor}, Año: {AnioPublicacion}";
        }
    }

    public class Program
    {
        // Conjunto para asegurar que los IDs de libro sean únicos
        static System.Collections.Generic.HashSet<string> idsLibros =
            new System.Collections.Generic.HashSet<string>();

        // Diccionario que asocia el ID de cada libro con su información
        static System.Collections.Generic.Dictionary<string, Libro> catalogo =
            new System.Collections.Generic.Dictionary<string, Libro>();

        // Método principal: muestra el menú y gestiona la interacción con el usuario
        public static void Main(string[] args)
        {
            Console.WriteLine("===UNIVERSIDAD ESTATAL AMAZÓNICA===");
            Console.WriteLine("=== Aplicación para el registro de libros en una biblioteca ===");
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("\n--- Sistema de Biblioteca ---");
                Console.WriteLine("1. Registrar libro");
                Console.WriteLine("2. Consultar libro por ID");
                Console.WriteLine("3. Mostrar todos los libros");
                Console.WriteLine("4. Salir");
                Console.Write("Seleccione una opción: ");
                string? opcion = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(opcion))
                {
                    Console.WriteLine("Entrada no válida.");
                    continue;
                }

                // Según la opción elegida, se llama al método correspondiente
                switch (opcion)
                {
                    case "1":
                        RegistrarLibro(); // Registrar un nuevo libro
                        break;
                    case "2":
                        ConsultarLibro(); // Consultar libro por ID
                        break;
                    case "3":
                        MostrarCatalogo(); // Mostrar todos los libros
                        break;
                    case "4":
                        salir = true; // Salir del sistema
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }

        // Método para registrar un nuevo libro en el sistema
        static void RegistrarLibro()
        {
            Console.Write("Ingrese el ID del libro: ");
            string? id = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(id))
            {
                Console.WriteLine("ID no puede estar vacío.");
                return;
            }

            // Verifica que el ID no esté repetido
            if (idsLibros.Contains(id))
            {
                Console.WriteLine("Error: El ID ya está registrado. No se pueden duplicar libros.");
                return;
            }

            Console.Write("Ingrese el título: ");
            string? titulo = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(titulo))
            {
                Console.WriteLine("El título no puede estar vacío.");
                return;
            }

            Console.Write("Ingrese el autor: ");
            string? autor = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(autor))
            {
                Console.WriteLine("El autor no puede estar vacío.");
                return;
            }

            Console.Write("Ingrese el año de publicación: ");
            int anio;
            string? anioInput = Console.ReadLine();
            // Valida que el año sea un número entero
            while (!int.TryParse(anioInput, out anio))
            {
                Console.Write("Año inválido. Ingrese nuevamente el año de publicación: ");
                anioInput = Console.ReadLine();
            }

            // Crea el nuevo libro y lo agrega a las estructuras de datos
            Libro nuevoLibro = new Libro
            {
                Titulo = titulo,
                Autor = autor,
                AnioPublicacion = anio
            };

            idsLibros.Add(id);
            catalogo.Add(id, nuevoLibro);

            Console.WriteLine("Libro registrado exitosamente.");
        }

        // Método para consultar un libro por su ID
        static void ConsultarLibro()
        {
            Console.Write("Ingrese el ID del libro a consultar: ");
            string? id = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(id))
            {
                Console.WriteLine("ID no puede estar vacío.");
                return;
            }

            // Busca el libro en el catálogo y muestra su información si existe
            if (catalogo.ContainsKey(id))
            {
                Console.WriteLine("Información del libro:");
                Console.WriteLine(catalogo[id]);
            }
            else
            {
                Console.WriteLine("No existe ningún libro con el ID ingresado.");
            }
        }

        // Método para mostrar todos los libros registrados en el sistema
        static void MostrarCatalogo()
        {
            Console.WriteLine("\n--- Catálogo de libros ---");
            if (catalogo.Count == 0)
            {
                Console.WriteLine("No hay libros registrados.");
                return;
            }

            // Recorre el diccionario y muestra cada libro
            foreach (var par in catalogo)
            {
                Console.WriteLine($"ID: {par.Key}, {par.Value}");
            }
        }
    }

