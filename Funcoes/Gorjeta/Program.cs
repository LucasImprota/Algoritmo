using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funcoes_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Função que calcula a gorjeta
            double CalcularGorjeta(double valorConta, double porcentagem)
            {
                return valorConta * (porcentagem / 100);
            }

            // Função que exibe o resumo da conta
            void ExibirConta(double valorConta, double porcentagem)
            {
                double valorGorjeta = CalcularGorjeta(valorConta, porcentagem);
                double totalAPagar = valorConta + valorGorjeta;

                Console.WriteLine("\n--- Resumo da Conta ---");
                Console.WriteLine($"Valor da conta: R$ {valorConta:F2}");
                Console.WriteLine($"Porcentagem da gorjeta: {porcentagem}%");
                Console.WriteLine($"Valor da gorjeta: R$ {valorGorjeta:F2}");
                Console.WriteLine($"Total a pagar: R$ {totalAPagar:F2}");
            }

            // Função principal
            void Main()
            {
                Console.WriteLine("Calculadora de Gorjeta");

                // Entrada do usuário

                double valorConta = 0;
                double porcentagem = 0;

                while (true)
                {
                    Console.Write("Digite o valor da conta: R$ ");
                    valorConta = Convert.ToDouble(Console.ReadLine());
                    if (valorConta <= 0)
                    {
                        Console.WriteLine("Erro: valor invalido");
                        Console.WriteLine("Tente de novo");
                    }
                    else
                    {
                        break;
                    }
                }

                while (true)
                {
                    Console.Write("Digite a porcentagem da gorjeta (%): ");
                    porcentagem = Convert.ToDouble(Console.ReadLine());
                    if (porcentagem < 0)
                    {
                        Console.WriteLine("Erro: valor invalido");
                        Console.WriteLine("Tente de novo");
                    }
                    else
                    {
                        break;
                    }
                }

            // Exibe o resumo
            ExibirConta(valorConta, porcentagem);
            }

            Main();
        }
    }
}