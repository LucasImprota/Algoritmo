using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compras
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> listaDeCompras = new List<string>();
            int opcao;

            do
            {
                Console.WriteLine("\n==== Lista de Compras ====");
                Console.WriteLine("1 - Adicionar item");
                Console.WriteLine("2 - Remover item");
                Console.WriteLine("3 - Exibir lista");
                Console.WriteLine("0 - Sair");
                Console.Write("Escolha uma opção: ");

                while (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.Write("Opção inválida. Digite um número: ");
                }

                switch (opcao)
                {
                    case 1:
                        Console.Write("Digite o nome do item a adicionar: ");
                        string itemAdicionar = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(itemAdicionar))
                        {
                            listaDeCompras.Add(itemAdicionar.Trim());
                            Console.WriteLine("Item adicionado com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("Item inválido!");
                        }
                        break;

                    case 2:
                        Console.Write("Digite o nome do item a remover: ");
                        string itemRemover = Console.ReadLine();
                        if (listaDeCompras.Remove(itemRemover.Trim()))
                        {
                            Console.WriteLine("Item removido com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("Item não encontrado na lista.");
                        }
                        break;

                    case 3:
                        Console.WriteLine("\n📋 Sua lista de compras:");
                        if (listaDeCompras.Count == 0)
                        {
                            Console.WriteLine("A lista está vazia.");
                        }
                        else
                        {
                            for (int i = 0; i < listaDeCompras.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {listaDeCompras[i]}");
                            }
                        }
                        break;

                    case 0:
                        Console.WriteLine("Saindo do programa. Até logo!");
                        break;

                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }

            } while (opcao != 0);

            Console.ReadKey();
        }
    }
}
