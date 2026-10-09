using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social_Scheduler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                List<string> postsAgendados = new List<string>();
                bool executando = true;

                while (executando)
                {
                    Console.WriteLine("\n--- SocialScheduler: Agendador de Conteúdo ---");
                    Console.WriteLine("1. Agendar Novo Post");
                    Console.WriteLine("2. Visualizar Posts Agendados");
                    Console.WriteLine("3. Limpar Agendamentos");
                    Console.WriteLine("4. Sair");
                    Console.Write("Escolha uma opção: ");

                    string opcao = Console.ReadLine();

                    switch (opcao)
                    {
                        case "1":
                            Console.Write("Digite o texto do post (até 280 caracteres): ");
                            string textoPost = Console.ReadLine();

                            Console.Write("Digite a data e hora do agendamento (formato: dd/MM/yyyy HH:mm): ");
                            string dataStr = Console.ReadLine();

                            if (!DateTime.TryParseExact(dataStr, "dd/MM/yyyy HH:mm", null, System.Globalization.DateTimeStyles.None, out DateTime dataAgendamento))
                            {
                                Console.WriteLine("Data/hora em formato inválido.");
                                break;
                            }

                            try
                            {
                                string postFormatado = FormatarPostAgendado(textoPost, dataAgendamento);
                                postsAgendados.Add(postFormatado);
                                Console.WriteLine("Post agendado com sucesso!");
                            }
                            catch (ArgumentException ex)
                            {
                                Console.WriteLine($"Erro: {ex.Message}");
                            }
                            
                            break;

                        case "2":
                            if (postsAgendados.Count == 0)
                            {
                                Console.WriteLine("Nenhum post agendado.");
                            }
                            else
                            {
                                Console.WriteLine("\n--- Posts Agendados ---");
                                foreach (var post in postsAgendados)
                                {
                                    Console.WriteLine(post);
                                }
                            }
                            break;

                        case "3":
                            postsAgendados.Clear();
                            Console.WriteLine("Todos os agendamentos foram removidos.");
                            break;

                        case "4":
                            executando = false;
                            Console.WriteLine("Encerrando o SocialScheduler...");
                            break;

                        default:
                            Console.WriteLine("Opção inválida.");
                            break;
                    }
                }
            }

            string FormatarPostAgendado(string texto, DateTime dataAgendamento)
            {
                if (string.IsNullOrWhiteSpace(texto) || texto.Length > 280)
                    throw new ArgumentException("O texto do post excede o limite de 280 caracteres ou está vazio.");

                if (dataAgendamento < DateTime.Now)
                    throw new ArgumentOutOfRangeException("A data de agendamento não pode ser no passado.");

                return $"[{dataAgendamento:dd/MM/yyyy HH:mm}] - {texto}";
            }
        }

    }
}