using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamify_Rewards
{
    internal class Program
    {
        static void Main(string[] args)
        {

                int totalMoedas = 0;
                bool executando = true;

                while (executando)
                {
                    Console.WriteLine("\n--- GamifyRewards: Sistema de Recompensas ---");
                    Console.WriteLine("1. Registrar Tarefa Concluída");
                    Console.WriteLine("2. Simular um Dia de Trabalho");
                    Console.WriteLine("3. Consultar Total de Moedas");
                    Console.WriteLine("4. Sair");
                    Console.Write("Escolha uma opção: ");
                    string opcao = Console.ReadLine();

                    switch (opcao)
                    {
                        case "1":
                            Console.Write("Informe o nível de dificuldade da tarefa (1 a 5): ");
                            if (!int.TryParse(Console.ReadLine(), out int dificuldade))
                            {
                                Console.WriteLine("Entrada inválida.");
                                break;
                            }

                            Console.Write("Informe o tempo gasto (em segundos): ");
                            if (!int.TryParse(Console.ReadLine(), out int tempo))
                            {
                                Console.WriteLine("Entrada inválida.");
                                break;
                            }

                            try
                            {
                                int recompensa = CalcularRecompensa(dificuldade, tempo);
                                totalMoedas += recompensa;
                                Console.WriteLine($"Você ganhou {recompensa} moedas!");
                            }
                            catch (ArgumentOutOfRangeException ex)
                            {
                                Console.WriteLine($"Erro: {ex.Message}");
                            }

                            break;

                        case "2":
                            // Simulando um dia com 5 tarefas aleatórias
                            Console.WriteLine("Simulando tarefas do dia...");
                            Random rand = new Random();
                            int totalDia = 0;

                            for (int i = 1; i <= 5; i++)
                            {
                                int nivel = rand.Next(1, 6); // 1 a 5
                                int tempoSegundos = rand.Next(10, 121); // 10 a 120s

                                try
                                {
                                    int moedas = CalcularRecompensa(nivel, tempoSegundos);
                                    totalMoedas += moedas;
                                    totalDia += moedas;
                                    Console.WriteLine($"Tarefa {i}: Nível {nivel}, Tempo {tempoSegundos}s → +{moedas} moedas");
                                }
                                catch (ArgumentOutOfRangeException ex)
                                {
                                    Console.WriteLine($"Erro na tarefa {i}: {ex.Message}");
                                }
                            }

                            Console.WriteLine($"Total de moedas ganhas hoje: {totalDia}");
                            break;

                        case "3":
                            Console.WriteLine($"Total acumulado de moedas: {totalMoedas}");
                            break;

                        case "4":
                            executando = false;
                            Console.WriteLine("Encerrando o GamifyRewards...");
                            break;

                        default:
                            Console.WriteLine("Opção inválida.");
                            break;
                    }
                }
            }

            // Função que calcula as moedas ganhas por tarefa
            static int CalcularRecompensa(int nivelDificuldade, int tempoGastoSegundos)
            {
                if (nivelDificuldade < 1 || nivelDificuldade > 5)
                    throw new ArgumentOutOfRangeException("Nível de dificuldade inválido. Deve ser entre 1 e 5.");

                if (tempoGastoSegundos < 0)
                    throw new ArgumentOutOfRangeException("O tempo gasto não pode ser negativo.");

                int recompensa = nivelDificuldade * 10;

                if (tempoGastoSegundos < 30)
                {
                    recompensa += 50;
                }

                return recompensa;
            }
        }

    }

