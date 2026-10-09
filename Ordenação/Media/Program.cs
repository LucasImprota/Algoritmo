using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        var alunos = new List<(string nome, double media)>();

        for (int i = 0; i < 10; i++)
        {
            Console.Write($"Nome do aluno {i + 1}: ");
            string nome = Console.ReadLine();

            Console.Write($"Média de {nome}: ");
            double media = double.Parse(Console.ReadLine());

            alunos.Add((nome, media));
        }

        var ordenado = alunos.OrderByDescending(a => a.media);

        Console.WriteLine("\nAlunos ordenados por média (decrescente):");
        foreach (var a in ordenado)
        {
            Console.WriteLine($"{a.nome} - {a.media:F2}");
        }
    }
}
