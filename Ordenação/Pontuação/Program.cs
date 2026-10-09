using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        var jogadores = new List<(string nome, int pontuacao)>
        {
            ("Lucas", 120),
            ("Maria", 200),
            ("João", 150),
            ("Ana", 170),
            ("Pedro", 90)
        };

        var ranking = jogadores.OrderByDescending(j => j.pontuacao);

        Console.WriteLine("Ranking dos jogadores:");
        foreach (var jogador in ranking)
        {
            Console.WriteLine($"{jogador.nome} - {jogador.pontuacao} pontos");
        }
    }
}
