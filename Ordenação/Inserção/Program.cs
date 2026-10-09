using System;

class Program
{
    static void InsertionSort(int[] vetor, out int trocas)
    {
        trocas = 0;
        for (int i = 1; i < vetor.Length; i++)
        {
            int chave = vetor[i];
            int j = i - 1;

            while (j >= 0 && vetor[j] > chave)
            {
                vetor[j + 1] = vetor[j];
                j--;
                trocas++;
            }
            vetor[j + 1] = chave;
        }
    }

    static void SelectionSort(int[] vetor, out int trocas)
    {
        trocas = 0;
        for (int i = 0; i < vetor.Length - 1; i++)
        {
            int menor = i;
            for (int j = i + 1; j < vetor.Length; j++)
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

        int[] copiaSelecao = (int[])vetor.Clone();
        int[] copiaInsercao = (int[])vetor.Clone();

        SelectionSort(copiaSelecao, out int trocasSelecao);
        InsertionSort(copiaInsercao, out int trocasInsercao);

        Console.WriteLine("\nSelection Sort:");
        Console.WriteLine("Vetor ordenado: " + string.Join(", ", copiaSelecao));
        Console.WriteLine($"Trocas: {trocasSelecao}");

        Console.WriteLine("\nInsertion Sort:");
        Console.WriteLine("Vetor ordenado: " + string.Join(", ", copiaInsercao));
        Console.WriteLine($"Trocas: {trocasInsercao}");
    }
}
