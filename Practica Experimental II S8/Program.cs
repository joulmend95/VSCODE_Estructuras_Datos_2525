using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Queue<string> cola = new Queue<string>(); // Cola para el orden de llegada
        Stack<string> pila = new Stack<string>(); // Pila para el último en subir
        int asientos = 30;

        // Las personas llegan y se forman en la cola
        for (int i = 1; i <= asientos; i++)
        {
            Console.Write("Ingrese el nombre de la persona #" + i + ": ");
            string nombre = Console.ReadLine() ?? "(Sin nombre)";
            cola.Enqueue(nombre); // Se agrega a la cola
        }

        Console.WriteLine("\nAsignando asientos en orden de llegada:");
        int numeroAsiento = 1;
        while (cola.Count > 0)
        {
            string persona = cola.Dequeue(); // Se atiende al primero de la cola
            Console.WriteLine("Asiento #" + numeroAsiento + " asignado a: " + persona);
            pila.Push(persona); // Se agrega a la pila (último en subir)
            numeroAsiento++;
        }

        Console.WriteLine("\nTodos los asientos han sido asignados.");
        Console.WriteLine("\nPersona que subió al final (último en la pila): " + pila.Peek());

        // Ejemplo de cancelar el último asiento asignado
        Console.WriteLine("\n¿Desea cancelar el último asiento asignado? (s/n): ");
        string cancelar = Console.ReadLine() ?? "n";
        if (cancelar.ToLower() == "s")
        {
            string personaCancelada = pila.Pop();
            Console.WriteLine("El asiento del último en subir ha sido cancelado: " + personaCancelada);
        }
        else
        {
            Console.WriteLine("No se canceló ningún asiento.");
        }
    }
}
