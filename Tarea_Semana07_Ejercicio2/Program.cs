using System;
using System.Collections.Generic;

public class Hanoi
{
    public static void run()
    {
        System.Console.WriteLine("Torres de Hanoi con pilas");
        System.Console.WriteLine("==========================");

        int n = 3;

        Stack<int> torreA = new Stack<int>();
        Stack<int> torreB = new Stack<int>();
        Stack<int> torreC = new Stack<int>();

        for (int i = n; i >= 1; i--)
        {
            torreA.Push(i);
        }

        Resolver(n, torreA, torreB, torreC, "A", "B", "C");
    }

    public static void Resolver(int n, Stack<int> origen, Stack<int> auxiliar, Stack<int> destino, string nombreO, string nombreA, string nombreD)
    {
        if (n == 1)
        {
            int disco = origen.Pop();
            destino.Push(disco);
            System.Console.WriteLine("Mover disco " + disco + " desde " + nombreO + " hacia " + nombreD);
            return;
        }

        Resolver(n - 1, origen, destino, auxiliar, nombreO, nombreD, nombreA);
        Resolver(1, origen, auxiliar, destino, nombreO, nombreA, nombreD);
        Resolver(n - 1, auxiliar, origen, destino, nombreA, nombreO, nombreD);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Hanoi.run();
    }
}
