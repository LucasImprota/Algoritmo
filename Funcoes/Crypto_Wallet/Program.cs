using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funcoes_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using System;

class FinTechWallet
        {
            static void Main()
            {
                double saldo = 0.0;
                bool programaAtivo = true;

                while (programaAtivo)
                {
                    Console.WriteLine("\n--- FinTech Wallet ---");
                    Console.WriteLine("1. Definir Saldo Inicial");
                    Console.WriteLine("2. Realizar Nova Transação");
                    Console.WriteLine("3. Consultar Saldo");
                    Console.WriteLine("4. Sair");
                    Console.Write("Escolha uma opção: ");

                    string opcao = Console.ReadLine();

                    switch (opcao)
                    {
                        case "1":
                            Console.Write("Digite o saldo inicial: ");
                            if (double.TryParse(Console.ReadLine(), out double saldoInicial))
                            {
                                if (saldoInicial < 0)
                                {
                                    Console.WriteLine("O saldo inicial não pode ser negativo.");
                                }
                                else
                                {
                                    saldo = saldoInicial;
                                    Console.WriteLine($"Saldo definido com sucesso: {saldo:C}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Valor inválido.");
                            }
                            break;

                        case "2":
                            Console.Write("Digite a carteira de destino (34 caracteres): ");
                            string carteiraDestino = Console.ReadLine();

                            Console.Write("Digite o valor da transação: ");
                            if (double.TryParse(Console.ReadLine(), out double valorTransacao))
                            {
                                try
                                {
                                    RealizarTransacao(ref saldo, carteiraDestino, valorTransacao);
                                    Console.WriteLine("Transação realizada com sucesso.");
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"Erro: {ex.Message}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Valor inválido.");
                            }
                            break;

                        case "3":
                            Console.WriteLine($"Saldo atual: {saldo:C}");
                            break;

                        case "4":
                            programaAtivo = false;
                            Console.WriteLine("Encerrando o programa...");
                            break;

                        default:
                            Console.WriteLine("Opção inválida.");
                            break;
                    }
                }
            }

            static void RealizarTransacao(ref double saldo, string carteiraDestino, double valor)
            {
                string carteiraOrigem = "1234567890123456789012345678901234"; // Simula carteira principal (34 caracteres)

                ValidarTransacao(saldo, carteiraOrigem, carteiraDestino, valor);

                saldo -= valor;
            }

            static void ValidarTransacao(double saldoAtual, string carteiraOrigem, string carteiraDestino, double valor)
            {
                if (valor <= 0)
                    throw new ArgumentException("O valor da transação deve ser positivo.");

                if (carteiraOrigem == carteiraDestino)
                    throw new ArgumentException("A carteira de origem não pode ser igual à de destino.");

                if (string.IsNullOrEmpty(carteiraDestino) || carteiraDestino.Length != 34)
                    throw new ArgumentException("A carteira de destino deve conter exatamente 34 caracteres.");

                if (saldoAtual < valor)
                    throw new InvalidOperationException("Saldo insuficiente para realizar a transação.");
            }
        }

    }
}
}
