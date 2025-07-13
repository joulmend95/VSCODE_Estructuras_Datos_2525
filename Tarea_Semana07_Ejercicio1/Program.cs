using System;
using System.Collections.Generic;

public class Balanceo
{
    public static void run()
    {
        System.Console.WriteLine("Verificación de paréntesis balanceados");
        System.Console.WriteLine("=======================================");
        
        System.Console.Write("Ingrese la expresión: ");
        string expresion = System.Console.ReadLine() ?? string.Empty;

        Stack<char> pila = new Stack<char>();

        bool balanceado = true;

        foreach (char c in expresion)
        {
            if (c == '(' || c == '{' || c == '[')
            {
                pila.Push(c);
            }
            else if (c == ')' || c == '}' || c == ']')
            {
                if (pila.Count == 0)
                {
                    balanceado = false;
                    break;
                }

                char tope = pila.Pop();

                if ((c == ')' && tope != '(') ||
                    (c == '}' && tope != '{') ||
                    (c == ']' && tope != '['))
                {
                    balanceado = false;
                    break;
                }
            }
        }

        if (pila.Count > 0)
        {
            balanceado = false;
        }

        if (balanceado)
        {
            System.Console.WriteLine("Fórmula balanceada.");
        }
        else
        {
            System.Console.WriteLine("Fórmula no balanceada.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Balanceo.run();
        System.Console.WriteLine("Presione cualquier tecla para salir...");
        System.Console.ReadKey();
    }
}
