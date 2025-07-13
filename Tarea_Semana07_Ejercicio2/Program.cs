using System;
using System.Collections.Generic;

public class Hanoi
{
    public static void run()
    {
        // Muestra el título del programa
        System.Console.WriteLine("Torres de Hanoi con pilas");
        System.Console.WriteLine("==========================");

        int n = 3; // Número de discos

        // Se crean tres pilas para representar las torres A, B y C
        Stack<int> torreA = new Stack<int>();
        Stack<int> torreB = new Stack<int>();
        Stack<int> torreC = new Stack<int>();

        // Se cargan los discos en la torre A (de mayor a menor, abajo hacia arriba)
        for (int i = n; i >= 1; i--)
        {
            torreA.Push(i);
        }

        // Se llama a la función recursiva que resuelve el problema
        Resolver(n, torreA, torreB, torreC, "A", "B", "C");
    }

    // Método recursivo para resolver las Torres de Hanoi
    public static void Resolver(
        int n,                 
        Stack<int> origen,     
        Stack<int> auxiliar,      
        Stack<int> destino,    
        string nombreO,         
        string nombreA,           
        string nombreD           
    )
    {
        // Caso base: si solo hay un disco, se mueve directamente al destino
        if (n == 1)
        {
            int disco = origen.Pop();         
            destino.Push(disco);               
            System.Console.WriteLine("Mover disco " + disco + " desde " + nombreO + " hacia " + nombreD);
            return;
        }

        // Paso 1: Mover n-1 discos del origen al auxiliar (usando destino como apoyo)
        Resolver(n - 1, origen, destino, auxiliar, nombreO, nombreD, nombreA);

        // Paso 2: Mover el disco restante del origen al destino
        Resolver(1, origen, auxiliar, destino, nombreO, nombreA, nombreD);

        // Paso 3: Mover los n-1 discos del auxiliar al destino (usando origen como apoyo)
        Resolver(n - 1, auxiliar, origen, destino, nombreA, nombreO, nombreD);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Llama a la función principal del problema de Hanoi
        Hanoi.run();
    }
}

