using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado_Financeiro
{
    internal class Program
    {
        static void Main(string[] args)
        {

                List<decimal> historicoCotas = new List<decimal>();
                Random random = new Random();
                bool executando = true;

                while (executando)
                {
                    Console.WriteLine("\n--- ExchangeRate: Simulador de Mercado ---");
                    Console.WriteLine("1. Consultar Cotação do Dólar");
                    Console.WriteLine("2. Converter BRL para USD");
                    Console.WriteLine("3. Ver Histórico de Cotações");
                    Console.WriteLine("4. Sair");
                    Console.Write("Escolha uma opção: ");
                    string opcao = Console.ReadLine();

                    switch (opcao)
                    {
                        case "1":
                            try
                            {
                                decimal cotacao = ObterCotacaoDolar(random);
                                historicoCotas.Add(cotacao);
                                Console.WriteLine($"Cotação atual do dólar: R$ {cotacao:F2}");
                            }
                            catch (InvalidOperationException ex)
                            {
                                Console.WriteLine($"Erro: {ex.Message}");
                            }
                            break;

                        case "2":
                            Console.Write("Digite o valor em BRL que deseja converter: ");
                            if (!decimal.TryParse(Console.ReadLine(), out decimal valorBRL) || valorBRL < 0)
                            {
                                Console.WriteLine("Valor inválido.");
                                break;
                            }

                            try
                            {
                                decimal cotacao = ObterCotacaoDolar(random);
                                historicoCotas.Add(cotacao);
                                decimal valorUSD = valorBRL / cotacao;
                                Console.WriteLine($"Cotação usada: R$ {cotacao:F2}");
                                Console.WriteLine($"{valorBRL:F2} BRL = {valorUSD:F2} USD");
                            }
                            catch (InvalidOperationException ex)
                            {
                                Console.WriteLine($"Erro: {ex.Message}");
                            }
                            break;

                        case "3":
                            if (historicoCotas.Count == 0)
                            {
                                Console.WriteLine("Nenhuma cotação registrada.");
                            }
                            else
                            {
                                Console.WriteLine("\n--- Histórico de Cotações ---");
                                foreach (var cot in historicoCotas)
                                {
                                    Console.WriteLine($"R$ {cot:F2}");
                                }
                            }
                            break;

                        case "4":
                            executando = false;
                            Console.WriteLine("Encerrando o ExchangeRate...");
                            break;

                        default:
                            Console.WriteLine("Opção inválida.");
                            break;
                    }
                }
            }

            static decimal ObterCotacaoDolar(Random random)
            {
                int chance = random.Next(1, 11); // 1 a 10

                if (chance % 2 == 0)
                {
                    // Retorna cotação entre 5.00 e 5.50
                    decimal cotacao = (decimal)(5.00 + random.NextDouble() * 0.50);
                    return Math.Round(cotacao, 2);
                }
                else
                {
                    throw new InvalidOperationException("O mercado está instável no momento. Não foi possível obter uma cotação.");
                }
            }
        }

    }

