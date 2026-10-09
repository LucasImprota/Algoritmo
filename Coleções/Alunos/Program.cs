using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alunos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<(string Nome, int Idade, double Nota1, double Nota2, double Nota3)> alunos = new List<(string, int, double, double, double)>();

            Console.Write("Quantos alunos deseja cadastrar? ");
            int quantidade;
            while (!int.TryParse(Console.ReadLine(), out quantidade) || quantidade <= 0)
            {
                Console.Write("Digite um número inteiro positivo: ");
            }

            for (int i = 0; i < quantidade; i++)
            {
                Console.WriteLine($"\n--- Aluno {i + 1} ---");

                Console.Write("Nome: ");
                string nome = Console.ReadLine();

                Console.Write("Idade: ");
                int idade;
                while (!int.TryParse(Console.ReadLine(), out idade))
                {
                    Console.Write("Digite uma idade válida: ");
                }

                double nota1 = LerNota("Nota 1");
                double nota2 = LerNota("Nota 2");
                double nota3 = LerNota("Nota 3");

                alunos.Add((nome, idade, nota1, nota2, nota3));
            }

            // Exibe os dados
            Console.WriteLine("\n===== Informações dos Alunos =====");
            foreach (var aluno in alunos)
            {
                double media = (aluno.Nota1 + aluno.Nota2 + aluno.Nota3) / 3;
                Console.WriteLine($"\nNome: {aluno.Nome}");
                Console.WriteLine($"Idade: {aluno.Idade}");
                Console.WriteLine($"Notas: {aluno.Nota1}, {aluno.Nota2}, {aluno.Nota3}");
                Console.WriteLine($"Média: {media:F2}");
            }
        }

        static double LerNota(string mensagem)
        {
            double nota;
            Console.Write($"{mensagem}: ");
            while (!double.TryParse(Console.ReadLine(), out nota) || nota < 0 || nota > 10)
            {
                Console.Write("Nota inválida. Digite uma nota entre 0 e 10: ");
            }
            return nota;
            Console.ReadKey();
        }
    }
}
