using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Par_Impar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] vetor = new char[100];

            for (int i = 0; i < vetor.Length; i++)
            {
                if (i % 2 == 0)
                    vetor[i] = 'P';
                else
                    vetor[i] = 'I';
            }

            Console.WriteLine("Vetor com 'P' (par) e 'I' (ímpar):\n");

            for (int i = 0; i < vetor.Length; i++)
            {
                Console.Write($"{vetor[i]} ");

                
                if ((i + 1) % 20 == 0)
                    Console.WriteLine();

             
            }
            Console.ReadKey();
        }
    }
}