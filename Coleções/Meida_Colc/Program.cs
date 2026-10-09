using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meida_Colc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numeros = new int[5];
            int soma = 0;

            Console.WriteLine("Digite 5 números inteiros:");

            for (int i = 0; i < numeros.Length; i++)
            {
                Console.Write($"Número {i + 1}: ");
                while (!int.TryParse(Console.ReadLine(), out numeros[i]))
                {
                    Console.Write("Entrada inválida. Digite um número inteiro: ");
                }
                soma += numeros[i];
            }

            double media = (double)soma / numeros.Length;
            Console.WriteLine($"\nA média dos números é: {media:F2}");


            Console.ReadKey();
        }
    }
}
