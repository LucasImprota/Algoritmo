using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Dictionary<int, string> listaDeCompras = new Dictionary<int, string>();
        int proximoId = 1;
        int opcao;

        do
        {
            Console.WriteLine("\n==== Lista de Compras ====");
            Console.WriteLine("1 - Adicionar item");
            Console.WriteLine("2 - Remover item (por ID)");
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
                    string novoItem = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(novoItem))
                    {
                        listaDeCompras[proximoId] = novoItem.Trim();
                        Console.WriteLine($"Item adicionado com ID {proximoId}!");
                        proximoId++;
                    }
                    else
                    {
                        Console.WriteLine("Item inválido. Tente novamente.");
                    }
                    break;

                case 2:
                    Console.Write("Digite o ID do item a remover: ");
                    int idRemover;
                    if (int.TryParse(Console.ReadLine(), out idRemover))
                    {
                        if (listaDeCompras.Remove(idRemover))
                        {
                            Console.WriteLine("Item removido com sucesso.");
                        }
                        else
                        {
                            Console.WriteLine("ID não encontrado na lista.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("ID inválido.");
                    }
                    break;

                case 3:
                    Console.WriteLine("\n📋 Lista de Compras:");
                    if (listaDeCompras.Count == 0)
                    {
                        Console.WriteLine("A lista está vazia.");
                    }
                    else
                    {
                        foreach (var item in listaDeCompras)
                        {
                            Console.WriteLine($"ID {item.Key}: {item.Value}");
                        }
                    }
                    break;

                case 0:
                    Console.WriteLine("Saindo... Até logo!");
                    break;

                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }

        } while (opcao != 0);
        Console.ReadKey();
    }
}
