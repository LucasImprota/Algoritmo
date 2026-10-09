using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, (string Telefone, DateTime DataNascimento)> pessoas = new Dictionary<string, (string, DateTime)>();

            Console.WriteLine("Cadastro de 3 pessoas:");

            for (int i = 0; i < 3; i++)
            {
                Console.Write($"\nNome da pessoa {i + 1}: ");
                string nome = Console.ReadLine();

                Console.Write("Telefone: ");
                string telefone = Console.ReadLine();

                Console.Write("Data de nascimento (dd/mm/aaaa): ");
                DateTime dataNascimento;
                while (!DateTime.TryParse(Console.ReadLine(), out dataNascimento))
                {
                    Console.Write("Data inválida. Digite no formato dd/mm/aaaa: ");
                }

                pessoas[nome] = (telefone, dataNascimento);
            }

            int opcao;
            do
            {
                Console.WriteLine("\n--- Menu ---");
                Console.WriteLine("1 - Mostrar todas as pessoas");
                Console.WriteLine("2 - Mostrar informações de uma pessoa");
                Console.WriteLine("0 - Sair");
                Console.Write("Escolha uma opção: ");

                while (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.Write("Opção inválida. Digite um número: ");
                }

                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("\n📋 Lista completa de pessoas:");
                        foreach (var pessoa in pessoas)
                        {
                            Console.WriteLine($"\nNome: {pessoa.Key}");
                            Console.WriteLine($"Telefone: {pessoa.Value.Telefone}");
                            Console.WriteLine($"Data de nascimento: {pessoa.Value.DataNascimento:dd/MM/yyyy}");
                        }
                        break;

                    case 2:
                        Console.Write("Digite o nome da pessoa: ");
                        string nomeBusca = Console.ReadLine();
                        if (pessoas.TryGetValue(nomeBusca, out var dados))
                        {
                            Console.WriteLine($"\nNome: {nomeBusca}");
                            Console.WriteLine($"Telefone: {dados.Telefone}");
                            Console.WriteLine($"Data de nascimento: {dados.DataNascimento:dd/MM/yyyy}");
                        }
                        else
                        {
                            Console.WriteLine("Pessoa não encontrada.");
                        }
                        break;

                    case 0:
                        Console.WriteLine("Saindo...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }

            } while (opcao != 0);
            Console.ReadKey();
        }
    }
}
