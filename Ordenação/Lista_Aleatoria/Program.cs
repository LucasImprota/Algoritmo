using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Random rnd = new Random();
        List<int> lista = new List<int>();
        for (int i = 0; i < 10; i++)
            lista.Add(rnd.Next(1, 100));

        Console.WriteLine("Lista gerada: " + string.Join(", ", lista));
        Console.WriteLine("Escolha o algoritmo:");
        Console.WriteLine("1 - Seleção\n2 - Inserção\n3 - Bolha\n4 - Merge\n5 - Quick");

        int opcao = int.Parse(Console.ReadLine());
        List<int> copia = new List<int>(lista);

        switch (opcao)
        {
            case 1:
                SelectionSort(copia);
                break;
            case 2:
                InsertionSort(copia);
                break;
            case 3:
                BubbleSort(copia);
                break;
            case 4:
                copia = MergeSort(copia);
                break;
            case 5:
                QuickSort(copia, 0, copia.Count - 1);
                break;
            default:
                Console.WriteLine("Opção inválida.");
                return;
        }

        Console.WriteLine("Lista ordenada: " + string.Join(", ", copia));
    }

    static void SelectionSort(List<int> lista)
    {
        for (int i = 0; i < lista.Count - 1; i++)
        {
            int min = i;
            for (int j = i + 1; j < lista.Count; j++)
                if (lista[j] < lista[min])
                    min = j;

            (lista[i], lista[min]) = (lista[min], lista[i]);
        }
    }

    static void InsertionSort(List<int> lista)
    {
        for (int i = 1; i < lista.Count; i++)
        {
            int chave = lista[i];
            int j = i - 1;
            while (j >= 0 && lista[j] > chave)
            {
                lista[j + 1] = lista[j];
                j--;
            }
            lista[j + 1] = chave;
        }
    }

    static void BubbleSort(List<int> lista)
    {
        for (int i = 0; i < lista.Count - 1; i++)
            for (int j = 0; j < lista.Count - i - 1; j++)
                if (lista[j] > lista[j + 1])
                    (lista[j], lista[j + 1]) = (lista[j + 1], lista[j]);
    }

    static List<int> MergeSort(List<int> lista)
    {
        if (lista.Count <= 1) return lista;

        int meio = lista.Count / 2;
        var esquerda = MergeSort(lista.GetRange(0, meio));
        var direita = MergeSort(lista.GetRange(meio, lista.Count - meio));

        return Merge(esquerda, direita);
    }

    static List<int> Merge(List<int> esq, List<int> dir)
    {
        List<int> result = new List<int>();
        int i = 0, j = 0;
        while (i < esq.Count && j < dir.Count)
        {
            if (esq[i] < dir[j])
                result.Add(esq[i++]);
            else
                result.Add(dir[j++]);
        }
        result.AddRange(esq.GetRange(i, esq.Count - i));
        result.AddRange(dir.GetRange(j, dir.Count - j));
        return result;
    }

    static void QuickSort(List<int> lista, int esq, int dir)
    {
        if (esq < dir)
        {
            int p = Particionar(lista, esq, dir);
            QuickSort(lista, esq, p - 1);
            QuickSort(lista, p + 1, dir);
        }
    }

    static int Particionar(List<int> lista, int esq, int dir)
    {
        int pivo = lista[dir];
        int i = esq - 1;
        for (int j = esq; j < dir; j++)
        {
            if (lista[j] < pivo)
            {
                i++;
                (lista[i], lista[j]) = (lista[j], lista[i]);
            }
        }
        (lista[i + 1], lista[dir]) = (lista[dir], lista[i + 1]);
        return i + 1;
    }
}
