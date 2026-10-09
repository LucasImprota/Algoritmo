using System;

class Program
{
    static void SelectionSort(int[] vetor, out int trocas)
    {
        trocas = 0;
        int n = vetor.Length;
        for (int i = 0; i < n - 1; i++)
        {
            int menor = i;
            for (int j = i + 1; j < n; j++)
            {
                if (vetor[j] < vetor[menor])
                    menor = j;
            }
            if (menor != i)
            {
                (vetor[i], vetor[menor]) = (vetor[menor], vetor[i]);
                trocas++;
            }
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

        int[] copia = (int[])vetor.Clone();

        SelectionSort(copia, out int trocasSelecao);
        Console.WriteLine("\nVetor ordenado (Selection Sort): " + string.Join(", ", copia));
        Console.WriteLine($"Trocas realizadas (Selection): {trocasSelecao}");
    }
}
