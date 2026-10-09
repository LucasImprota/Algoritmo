using System;

class Program
{
    static void Main()
    {
        int[] estoque = { 15, 3, 8, 2, 20, 6, 7, 1, 13, 4 };

        Array.Sort(estoque);

        Console.WriteLine("Estoque ordenado (crescente):");
        Console.WriteLine(string.Join(", ", estoque));

        Console.WriteLine("\n5 produtos com menor quantidade:");
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"Produto {i + 1}: {estoque[i]} unidades");
        }
    }
}
