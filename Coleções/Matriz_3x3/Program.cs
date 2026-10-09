using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matriz_3x3
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[,] matriz = new int[3, 3];
            int soma = 0;

            Console.WriteLine("Digite os valores para a matriz 3x3:");

            for (int linha = 0; linha < 3; linha++)
            {
                for (int coluna = 0; coluna < 3; coluna++)
                {
                    // Mostra a posição ao usuário começando em 1
                    Console.Write($"Elemento [{linha + 1}, {coluna + 1}]: ");
                    while (!int.TryParse(Console.ReadLine(), out matriz[linha, coluna]))
                    {
                        Console.Write("Entrada inválida. Digite um número inteiro: ");
                    }

                    soma += matriz[linha, coluna];
                }
            }

            Console.WriteLine("\nMatriz digitada:");
            for (int linha = 0; linha < 3; linha++)
            {
                for (int coluna = 0; coluna < 3; coluna++)
                {
                    Console.Write($"{matriz[linha, coluna],4}");
                }
                Console.WriteLine();
            }

            Console.WriteLine($"\nSoma de todos os elementos: {soma}");

            Console.ReadKey();
        }
    }
}
