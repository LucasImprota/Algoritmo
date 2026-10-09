using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoTracker
{
    internal class Program
    {
        static void Main(string[] args)
        {

            {
                double totalCarbono = 0.0;
                bool executando = true;

                while (executando)
                {
                    Console.WriteLine("\n--- EcoTracker: Calculadora de Pegada de Carbono ---");
                    Console.WriteLine("1. Calcular Viagem Única");
                    Console.WriteLine("2. Calcular Viagem de Múltiplos Trechos");
                    Console.WriteLine("3. Ver Total Acumulado");
                    Console.WriteLine("4. Sair");
                    Console.Write("Escolha uma opção: ");

                    string opcao = Console.ReadLine();

                    switch (opcao)
                    {
                        case "1":
                            AdicionarTrecho(ref totalCarbono);
                            break;

                        case "2":
                            Console.Write("Quantos trechos deseja adicionar? ");
                            if (int.TryParse(Console.ReadLine(), out int numTrechos) && numTrechos > 0)
                            {
                                for (int i = 0; i < numTrechos; i++)
                                {
                                    Console.WriteLine($"\n--- Trecho {i + 1} ---");
                                    AdicionarTrecho(ref totalCarbono);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Número de trechos inválido.");
                            }
                            break;

                        case "3":
                            Console.WriteLine($"Total acumulado de emissões: {totalCarbono:F3} kg de CO₂");
                            break;

                        case "4":
                            executando = false;
                            Console.WriteLine("Encerrando EcoTracker...");
                            break;

                        default:
                            Console.WriteLine("Opção inválida.");
                            break;
                    }
                }
            }

            // Função para calcular emissões
            double CalcularPegadaCarbono(double distanciaKm, string tipoTransporte)
            {
                if (distanciaKm < 0)
                    throw new ArgumentOutOfRangeException("A distância não pode ser negativa.");

                double fatorEmissao;

                switch (tipoTransporte.ToUpper())
                {
                    case "CARRO":
                        fatorEmissao = 0.21;
                        break;
                    case "ONIBUS":
                        fatorEmissao = 0.089;
                        break;
                    case "METRO":
                        fatorEmissao = 0.041;
                        break;
                    case "BICICLETA":
                        fatorEmissao = 0.0;
                        break;
                    case "AVIAO":
                        fatorEmissao = 0.255;
                        break;
                    default:
                        throw new NotSupportedException($"Transporte '{tipoTransporte}' não é suportado.");
                }

                return distanciaKm * fatorEmissao;
            }

            // Função para adicionar trecho e atualizar total
            void AdicionarTrecho(ref double totalCarbono)
            {
                Console.Write("Informe a distância (em km): ");
                if (!double.TryParse(Console.ReadLine(), out double distancia))
                {
                    Console.WriteLine("Distância inválida.");
                    return;
                }

                Console.Write("Informe o tipo de transporte (CARRO, ONIBUS, METRO, BICICLETA, AVIAO): ");
                string tipoTransporte = Console.ReadLine();

                try
                {
                    double emissao = CalcularPegadaCarbono(distancia, tipoTransporte);
                    totalCarbono += emissao;
                    Console.WriteLine($"Emissão deste trecho: {emissao:F3} kg de CO₂");
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine($"Erro: {ex.Message}");
                }
                catch (NotSupportedException ex)
                {
                    Console.WriteLine($"Erro: {ex.Message}");
                }
            }
        }

    }
}