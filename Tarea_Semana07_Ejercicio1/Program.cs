using System;
using System.Collections.Generic;

public class Balanceo
{
    public static void run()
    {
        // Muestra título del programa
        System.Console.WriteLine("Verificación de paréntesis balanceados");
        System.Console.WriteLine("=======================================");

        // Pide al usuario que ingrese una expresión
        System.Console.Write("Ingrese la expresión: ");
        string expresion = System.Console.ReadLine() ?? string.Empty;

        // Se crea una pila para guardar los símbolos de apertura
        Stack<char> pila = new Stack<char>();

        // Variable para saber si la expresión está balanceada
        bool balanceado = true;

        // Recorre cada carácter de la expresión
        foreach (char c in expresion)
        {
            // Si el carácter es un símbolo de apertura, se guarda en la pila
            if (c == '(' || c == '{' || c == '[')
            {
                pila.Push(c);
            }
            // Si el carácter es un símbolo de cierre
            else if (c == ')' || c == '}' || c == ']')
            {
                // Si no hay elementos en la pila, hay un error de cierre sin apertura
                if (pila.Count == 0)
                {
                    balanceado = false;
                    break;
                }

                // Saca el último símbolo de apertura de la pila
                char tope = pila.Pop();

                // Verifica si el símbolo de apertura coincide con el de cierre
                if ((c == ')' && tope != '(') ||
                    (c == '}' && tope != '{') ||
                    (c == ']' && tope != '['))
                {
                    balanceado = false;
                    break;
                }
            }
        }

        // Si la pila no está vacía al final, hay símbolos sin cerrar
        if (pila.Count > 0)
        {
            balanceado = false;
        }

        // Muestra el resultado final
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
        // Llama a la función principal que hace la verificación
        Balanceo.run();

        // Espera a que el usuario presione Enter antes de cerrar
        System.Console.WriteLine("Presione Enter para salir...");
        try
        {
            System.Console.ReadLine();
        }
        catch
        {
            // Si hay problemas con la consola, simplemente continúa
        }
    }
}

