using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentimentAI
{
    internal class Program
    {
        static void Main(string[] args)
        {
        
                int positivos = 0;
                int negativos = 0;
                int neutros = 0;
                bool executando = true;

                while (executando)
                {
                    Console.WriteLine("\n--- SentimentAI: Análise de Sentimento ---");
                    Console.WriteLine("1. Analisar um Texto");
                    Console.WriteLine("2. Analisar um Lote de Textos");
                    Console.WriteLine("3. Ver Estatísticas");
                    Console.WriteLine("4. Sair");
                    Console.Write("Escolha uma opção: ");

                    string opcao = Console.ReadLine();

                    switch (opcao)
                    {
                        case "1":
                            Console.Write("Digite a avaliação do cliente: ");
                            string input = Console.ReadLine();

                            try
                            {
                                string resultado = AnalisarSentimento(input);
                                Console.WriteLine($"Sentimento detectado: {resultado}");

                                if (resultado == "Positivo") positivos++;
                                else if (resultado == "Negativo") negativos++;
                                else neutros++;
                            }
                            catch (ArgumentNullException ex)
                            {
                                Console.WriteLine($"Erro: {ex.Message}");
                            }
                            break;

                        case "2":
                            string[] avaliacoes = {
                        "Adorei o produto, muito bom!",
                        "Horrível, chegou quebrado.",
                        "Entrega dentro do prazo.",
                        "Não gostei, mas fui atendido.",
                        "Excelente atendimento!",
                        "Nada demais."
                    };

                            Console.WriteLine("Processando lote de avaliações...");
                            ProcessarLote(avaliacoes, ref positivos, ref negativos, ref neutros);
                            Console.WriteLine("Lote processado.");
                            break;

                        case "3":
                            Console.WriteLine("\n--- Estatísticas da Sessão ---");
                            Console.WriteLine($"Positivas: {positivos}");
                            Console.WriteLine($"Negativas: {negativos}");
                            Console.WriteLine($"Neutras: {neutros}");
                            break;

                        case "4":
                            executando = false;
                            Console.WriteLine("Encerrando SentimentAI...");
                            break;

                        default:
                            Console.WriteLine("Opção inválida.");
                            break;
                    }
                }
            }

            // Função que analisa o sentimento de uma frase simples
            static string AnalisarSentimento(string avaliacao)
            {
                if (string.IsNullOrWhiteSpace(avaliacao))
                    throw new ArgumentNullException("A avaliação não pode ser nula ou vazia.");

                string texto = avaliacao.ToLower();

                // Listas simples de palavras-chave (poderia ser melhorado com NLP real)
                string[] palavrasPositivas = { "bom", "excelente", "ótimo", "adorei", "perfeito", "gostei", "maravilhoso" };
                string[] palavrasNegativas = { "ruim", "horrível", "péssimo", "terrível", "quebrado", "lento", "não gostei" };

                foreach (var palavra in palavrasPositivas)
                {
                    if (texto.Contains(palavra))
                        return "Positivo";
                }

                foreach (var palavra in palavrasNegativas)
                {
                    if (texto.Contains(palavra))
                        return "Negativo";
                }

                return "Neutro";
            }

            // Função para processar um lote de textos e atualizar contadores
            static void ProcessarLote(string[] avaliacoes, ref int positivos, ref int negativos, ref int neutros)
            {
                foreach (var avaliacao in avaliacoes)
                {
                    try
                    {
                        string resultado = AnalisarSentimento(avaliacao);
                        Console.WriteLine($"\"{avaliacao}\" → {resultado}");

                        if (resultado == "Positivo") positivos++;
                        else if (resultado == "Negativo") negativos++;
                        else neutros++;
                    }
                    catch (ArgumentNullException ex)
                    {
                        Console.WriteLine($"Erro ao analisar: {ex.Message}");
                    }
                }
            }
        }

    }
