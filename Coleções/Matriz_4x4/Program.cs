using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matriz_4x4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] A = new int[4, 4];
            int[,] B = new int[4, 4];
            int[,] C = new int[4, 4];

            Console.WriteLine("Digite os elementos da matriz A (4x4):");

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write($"A[{i + 1}, {j + 1}]: ");
                    while (!int.TryParse(Console.ReadLine(), out A[i, j]))
                    {
                        Console.Write("Entrada inválida. Digite um número inteiro: ");
                    }
                }
            }

            Console.WriteLine("\nDigite os elementos da matriz B (4x4):");

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write($"B[{i + 1}, {j + 1}]: ");
                    while (!int.TryParse(Console.ReadLine(), out B[i, j]))
                    {
                        Console.Write("Entrada inválida. Digite um número inteiro: ");
                    }
                }
            }

            // Soma das matrizes A e B
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    C[i, j] = A[i, j] + B[i, j];
                }
            }

            // Imprime a matriz resultante C
            Console.WriteLine("\nMatriz resultante da soma (C = A + B):");
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write($"{C[i, j],5}");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
