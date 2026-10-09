using System;

class Program
{
    static void BubbleSort(int[] vetor)
    {
        int n = vetor.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (vetor[j] > vetor[j + 1])
                {
                    (vetor[j], vetor[j + 1]) = (vetor[j + 1], vetor[j]);
                }
            }
            Console.WriteLine($"Passagem {i + 1}: {string.Join(", ", vetor)}");
        }
    }

    static void Main()
    {
        int[] vetor = new int[10];

        Console.WriteLine("Digite 10 números inteiros:");
        for (int i = 0; i < 10; i++)
        {
            Console.Write($"Número {i + 1}: ");
            vetor[i] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine("\nExecução do Bubble Sort:");
        BubbleSort(vetor);
    }
}
