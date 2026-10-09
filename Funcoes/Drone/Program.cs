using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drone
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
                int altitude = 0;
                int distancia = 0;
                bool executando = true;

                while (executando)
                {
                    Console.WriteLine("\n--- Painel de Controle do Drone ---");
                    Console.WriteLine("1. Enviar Comando Único");
                    Console.WriteLine("2. Executar Rota Pré-definida");
                    Console.WriteLine("3. Verificar Status do Drone");
                    Console.WriteLine("4. Sair");
                    Console.Write("Escolha uma opção: ");

                    string opcao = Console.ReadLine();

                    switch (opcao)
                    {
                        case "1":
                            Console.Write("Digite o comando (SUBIR, DESCER, AVANCAR): ");
                            string comando = Console.ReadLine().ToUpper();

                            try
                            {
                                ExecutarComandoDrone(comando, ref altitude, ref distancia);
                                Console.WriteLine("Comando executado com sucesso.");
                            }
                            catch (InvalidOperationException ex)
                            {
                                Console.WriteLine($"Erro: {ex.Message}");
                            }
                            break;

                        case "2":
                            string[] rota = { "SUBIR", "AVANCAR", "AVANCAR", "DESCER", "DESCER", "DESCER" };

                            Console.WriteLine("Executando rota pré-definida...");
                            ExecutarRota(rota, ref altitude, ref distancia);
                            Console.WriteLine("Rota finalizada.");
                            break;

                        case "3":
                            Console.WriteLine($"Status do Drone:\nAltitude: {altitude}\nDistância: {distancia}");
                            break;

                        case "4":
                            executando = false;
                            Console.WriteLine("Encerrando o controle do drone...");
                            break;

                        default:
                            Console.WriteLine("Opção inválida.");
                            break;
                    }
                }
            }

            static void ExecutarComandoDrone(string comando, ref int altitude, ref int distancia)
            {
                switch (comando)
                {
                    case "SUBIR":
                        altitude++;
                        break;

                    case "DESCER":
                        if (altitude == 0)
                            throw new InvalidOperationException("Não é possível descer: o drone já está no solo.");
                        altitude--;
                        break;

                    case "AVANCAR":
                        distancia++;
                        break;

                    default:
                        throw new InvalidOperationException($"Comando desconhecido: {comando}");
                }
            }

            static void ExecutarRota(string[] rota, ref int altitude, ref int distancia)
            {
                foreach (string comando in rota)
                {
                    try
                    {
                        ExecutarComandoDrone(comando.ToUpper(), ref altitude, ref distancia);
                        Console.WriteLine($"Comando '{comando}' executado com sucesso.");
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine($"Erro ao executar '{comando}': {ex.Message}");
                    }
                }
            }
        }

    }

