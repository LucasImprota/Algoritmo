using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Gestão
{
    class Program
    {
        const int MAX_ALUNOS = 40;
        const int TOTAL_DISCIPLINAS = 4;

        static string[] nomes = new string[MAX_ALUNOS];
        static double[,] notas = new double[MAX_ALUNOS, TOTAL_DISCIPLINAS]; // linhas = alunos, colunas = disciplinas
        static int totalAlunos = 0;

        static string[] disciplinas = { "Matemática", "Português", "História", "Ciências" };

        static void Main()
        {
            int opcao;
            do
            {
                Console.Clear();
                Console.WriteLine("=== SISTEMA DE GESTÃO DE NOTAS ===");
                Console.WriteLine("1. Cadastrar aluno");
                Console.WriteLine("2. Inserir notas de um aluno");
                Console.WriteLine("3. Consultar notas de um aluno");
                Console.WriteLine("4. Calcular média de um aluno");
                Console.WriteLine("5. Relatório geral da turma");
                Console.WriteLine("6. Estatísticas por disciplina");
                Console.WriteLine("7. Alunos aprovados/reprovados");
                Console.WriteLine("8. Sair");
                Console.Write("Escolha uma opção: ");

                // <-- Adicionado tratamento
                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.WriteLine("Entrada inválida. Digite um número entre 1 e 8.");
                    opcao = 0;
                }

                try
                {
                    switch (opcao)
                    {
                        case 1: CadastrarAluno(); break;
                        case 2: InserirNotas(); break;
                        case 3: ConsultarNotas(); break;
                        case 4: CalcularMedia(); break;
                        case 5: RelatorioGeral(); break;
                        case 6: EstatisticasDisciplina(); break;
                        case 7: AprovadosReprovados(); break;
                        case 8: Console.WriteLine("Encerrando o programa."); break;
                        default: Console.WriteLine("Opção inválida."); break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ocorreu um erro: {ex.Message}");
                }

                if (opcao != 8)
                {
                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcao != 8);
        }

        static void CadastrarAluno()
        {
            if (totalAlunos >= MAX_ALUNOS)
            {
                Console.WriteLine("Limite máximo de alunos atingido.");
                return;
            }

            Console.Write("Digite o nome do aluno: ");
            string nome = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(nome))
            {
                Console.WriteLine("Nome inválido.");
                return;
            }

            nomes[totalAlunos] = nome;

            for (int i = 0; i < TOTAL_DISCIPLINAS; i++)
                notas[totalAlunos, i] = -1;

            totalAlunos++;
            Console.WriteLine("Aluno cadastrado com sucesso!");
        }

        static int BuscarAluno()
        {
            Console.Write("Digite o nome do aluno: ");
            string nome = Console.ReadLine();

            for (int i = 0; i < totalAlunos; i++)
            {
                if (nomes[i].Equals(nome, StringComparison.OrdinalIgnoreCase))
                    return i;
            }

            Console.WriteLine("Aluno não encontrado.");
            return -1;
        }

        static void InserirNotas()
        {
            int index = BuscarAluno();
            if (index == -1) return;

            for (int i = 0; i < TOTAL_DISCIPLINAS; i++)
            {
                double nota;
                bool valida;

                do
                {
                    Console.Write($"Digite a nota de {disciplinas[i]} (0-10): ");
                    string entrada = Console.ReadLine();
                    valida = double.TryParse(entrada, out nota) && nota >= 0 && nota <= 10;

                    if (!valida)
                        Console.WriteLine("Nota inválida. Digite um número entre 0 e 10.");
                } while (!valida);

                notas[index, i] = nota;
            }

            Console.WriteLine("Notas inseridas com sucesso!");
        }

        static void ConsultarNotas()
        {
            int index = BuscarAluno();
            if (index == -1) return;

            Console.WriteLine($"\nNotas de {nomes[index]}:");
            for (int i = 0; i < TOTAL_DISCIPLINAS; i++)
            {
                if (notas[index, i] >= 0)
                    Console.WriteLine($"{disciplinas[i]}: {notas[index, i]:F1}");
                else
                    Console.WriteLine($"{disciplinas[i]}: Sem nota");
            }
        }

        static void CalcularMedia()
        {
            int index = BuscarAluno();
            if (index == -1) return;

            double soma = 0;
            bool faltandoNota = false;

            for (int i = 0; i < TOTAL_DISCIPLINAS; i++)
            {
                if (notas[index, i] < 0)
                {
                    faltandoNota = true;
                    break;
                }
                soma += notas[index, i];
            }

            if (faltandoNota)
                Console.WriteLine("Este aluno ainda não possui todas as notas.");
            else
                Console.WriteLine($"Média de {nomes[index]}: {soma / TOTAL_DISCIPLINAS:F2}");
        }

        static void RelatorioGeral()
        {
            for (int i = 0; i < totalAlunos; i++)
            {
                Console.WriteLine($"\nAluno: {nomes[i]}");
                double soma = 0;
                bool faltando = false;

                for (int j = 0; j < TOTAL_DISCIPLINAS; j++)
                {
                    if (notas[i, j] >= 0)
                    {
                        Console.WriteLine($"{disciplinas[j]}: {notas[i, j]:F1}");
                        soma += notas[i, j];
                    }
                    else
                    {
                        Console.WriteLine($"{disciplinas[j]}: Sem nota");
                        faltando = true;
                    }
                }

                Console.WriteLine("Média: " + (faltando ? "N/A" : $"{(soma / TOTAL_DISCIPLINAS):F2}"));
            }
        }

        static void EstatisticasDisciplina()
        {
            for (int i = 0; i < TOTAL_DISCIPLINAS; i++)
                Console.WriteLine($"{i + 1}. {disciplinas[i]}");

            Console.Write("Escolha a disciplina: ");
            if (!int.TryParse(Console.ReadLine(), out int opcao) || opcao < 1 || opcao > TOTAL_DISCIPLINAS)
            {
                Console.WriteLine("Disciplina inválida.");
                return;
            }

            opcao--; // Ajustar índice

            double soma = 0;
            int cont = 0;
            double maior = -1, menor = 11;

            for (int i = 0; i < totalAlunos; i++)
            {
                double nota = notas[i, opcao];
                if (nota >= 0)
                {
                    soma += nota;
                    cont++;

                    if (nota > maior) maior = nota;
                    if (nota < menor) menor = nota;
                }
            }

            if (cont == 0)
            {
                Console.WriteLine("Nenhuma nota cadastrada para essa disciplina.");
                return;
            }

            Console.WriteLine($"\nEstatísticas de {disciplinas[opcao]}:");
            Console.WriteLine($"Média: {soma / cont:F2}");
            Console.WriteLine($"Maior nota: {maior:F1}");
            Console.WriteLine($"Menor nota: {menor:F1}");
            Console.WriteLine($"Alunos com nota: {cont}");
        }

        static void AprovadosReprovados()
        {
            Console.WriteLine("\nAlunos Aprovados:");
            for (int i = 0; i < totalAlunos; i++)
            {
                double soma = 0;
                bool completo = true;

                for (int j = 0; j < TOTAL_DISCIPLINAS; j++)
                {
                    if (notas[i, j] < 0)
                    {
                        completo = false;
                        break;
                    }
                    soma += notas[i, j];
                }

                if (completo && (soma / TOTAL_DISCIPLINAS) >= 5)
                    Console.WriteLine($"{nomes[i]} - Média: {(soma / TOTAL_DISCIPLINAS):F2}");


            }
        }
    }
}