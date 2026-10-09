using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manipulacao_Arquivos
{
    using System;
    using System.IO;

    class GerenciadorArquivos
    {
        static void Main()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== GERENCIADOR DE ARQUIVOS ===");
                Console.WriteLine("1. Verificar existência de arquivo/pasta");
                Console.WriteLine("2. Criar pasta");
                Console.WriteLine("3. Renomear pasta");
                Console.WriteLine("4. Criar arquivo de texto");
                Console.WriteLine("5. Renomear arquivo");
                Console.WriteLine("6. Excluir arquivo");
                Console.WriteLine("7. Ler arquivo de texto");
                Console.WriteLine("8. Editar e salvar arquivo de texto");
                Console.WriteLine("9. Listar arquivos e pastas");
                Console.WriteLine("10. Mover arquivo/pasta");
                Console.WriteLine("11. Copiar arquivo/pasta");
                Console.WriteLine("12. Mostrar informações de arquivo/pasta");
                Console.WriteLine("0. Sair");
                Console.Write("Escolha uma opção: ");

                string opcao = Console.ReadLine();
                Console.WriteLine();

                try
                {
                    switch (opcao)
                    {
                        case "1": VerificarExistencia(); break;
                        case "2": CriarPasta(); break;
                        case "3": RenomearPasta(); break;
                        case "4": CriarArquivo(); break;
                        case "5": RenomearArquivo(); break;
                        case "6": ExcluirArquivo(); break;
                        case "7": LerArquivo(); break;
                        case "8": EditarArquivo(); break;
                        case "9": ListarConteudo(); break;
                        case "10": Mover(); break;
                        case "11": Copiar(); break;
                        case "12": MostrarInformacoes(); break;
                        case "0": return;
                        default: Console.WriteLine("Opção inválida!"); break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro: {ex.Message}");
                }

                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }

        static void VerificarExistencia()
        {
            Console.Write("Digite o caminho do arquivo ou pasta: ");
            string caminho = Console.ReadLine();

            if (File.Exists(caminho))
                Console.WriteLine("O arquivo existe.");
            else if (Directory.Exists(caminho))
                Console.WriteLine("A pasta existe.");
            else
                Console.WriteLine("Arquivo ou pasta não encontrado.");
        }

        static void CriarPasta()
        {
            Console.Write("Digite o caminho da nova pasta: ");
            string caminho = Console.ReadLine();

            if (!Directory.Exists(caminho))
            {
                Directory.CreateDirectory(caminho);
                Console.WriteLine("Pasta criada com sucesso.");
            }
            else
            {
                Console.WriteLine("A pasta já existe.");
            }
        }

        static void RenomearPasta()
        {
            Console.Write("Digite o caminho da pasta atual: ");
            string caminhoAtual = Console.ReadLine();

            Console.Write("Digite o novo caminho da pasta: ");
            string novoCaminho = Console.ReadLine();

            if (Directory.Exists(caminhoAtual))
            {
                Directory.Move(caminhoAtual, novoCaminho);
                Console.WriteLine("Pasta renomeada com sucesso.");
            }
            else
            {
                Console.WriteLine("A pasta não existe.");
            }
        }

        static void CriarArquivo()
        {
            Console.Write("Digite o caminho do novo arquivo (com .txt): ");
            string caminho = Console.ReadLine();

            if (!File.Exists(caminho))
            {
                File.WriteAllText(caminho, "");
                Console.WriteLine("Arquivo criado com sucesso.");
            }
            else
            {
                Console.WriteLine("O arquivo já existe.");
            }
        }

        static void RenomearArquivo()
        {
            Console.Write("Digite o caminho do arquivo atual: ");
            string caminhoAtual = Console.ReadLine();

            Console.Write("Digite o novo caminho do arquivo: ");
            string novoCaminho = Console.ReadLine();

            if (File.Exists(caminhoAtual))
            {
                File.Move(caminhoAtual, novoCaminho);
                Console.WriteLine("Arquivo renomeado com sucesso.");
            }
            else
            {
                Console.WriteLine("O arquivo não existe.");
            }
        }

        static void ExcluirArquivo()
        {
            Console.Write("Digite o caminho do arquivo: ");
            string caminho = Console.ReadLine();

            if (File.Exists(caminho))
            {
                File.Delete(caminho);
                Console.WriteLine("Arquivo excluído com sucesso.");
            }
            else
            {
                Console.WriteLine("O arquivo não existe.");
            }
        }

        static void LerArquivo()
        {
            Console.Write("Digite o caminho do arquivo: ");
            string caminho = Console.ReadLine();

            if (File.Exists(caminho))
            {
                string conteudo = File.ReadAllText(caminho);
                Console.WriteLine("Conteúdo do arquivo:\n");
                Console.WriteLine(conteudo);
            }
            else
            {
                Console.WriteLine("Arquivo não encontrado.");
            }
        }

        static void EditarArquivo()
        {
            Console.Write("Digite o caminho do arquivo: ");
            string caminho = Console.ReadLine();

            if (File.Exists(caminho))
            {
                string conteudo = File.ReadAllText(caminho);
                Console.WriteLine("Conteúdo atual:");
                Console.WriteLine(conteudo);

                Console.WriteLine("\nDigite o novo conteúdo:");
                string novoConteudo = Console.ReadLine();

                File.WriteAllText(caminho, novoConteudo);
                Console.WriteLine("Arquivo editado com sucesso.");
            }
            else
            {
                Console.WriteLine("Arquivo não encontrado.");
            }
        }

        static void ListarConteudo()
        {
            Console.Write("Digite o caminho da pasta: ");
            string caminho = Console.ReadLine();

            if (Directory.Exists(caminho))
            {
                Console.WriteLine("Pastas:");
                foreach (string dir in Directory.GetDirectories(caminho))
                    Console.WriteLine(dir);

                Console.WriteLine("\nArquivos:");
                foreach (string file in Directory.GetFiles(caminho))
                    Console.WriteLine(file);
            }
            else
            {
                Console.WriteLine("A pasta não existe.");
            }
        }

        static void Mover()
        {
            Console.Write("Digite o caminho de origem: ");
            string origem = Console.ReadLine();

            Console.Write("Digite o caminho de destino: ");
            string destino = Console.ReadLine();

            if (File.Exists(origem))
            {
                File.Move(origem, destino);
                Console.WriteLine("Arquivo movido com sucesso.");
            }
            else if (Directory.Exists(origem))
            {
                Directory.Move(origem, destino);
                Console.WriteLine("Pasta movida com sucesso.");
            }
            else
            {
                Console.WriteLine("Origem não encontrada.");
            }
        }

        static void Copiar()
        {
            Console.Write("Digite o caminho de origem: ");
            string origem = Console.ReadLine();

            Console.Write("Digite o caminho de destino: ");
            string destino = Console.ReadLine();

            if (File.Exists(origem))
            {
                File.Copy(origem, destino, overwrite: true);
                Console.WriteLine("Arquivo copiado com sucesso.");
            }
            else if (Directory.Exists(origem))
            {
                CopiarPasta(origem, destino);
                Console.WriteLine("Pasta copiada com sucesso.");
            }
            else
            {
                Console.WriteLine("Origem não encontrada.");
            }
        }

        static void CopiarPasta(string origem, string destino)
        {
            Directory.CreateDirectory(destino);
            foreach (string file in Directory.GetFiles(origem))
            {
                string destFile = Path.Combine(destino, Path.GetFileName(file));
                File.Copy(file, destFile, true);
            }
            foreach (string dir in Directory.GetDirectories(origem))
            {
                string destDir = Path.Combine(destino, Path.GetFileName(dir));
                CopiarPasta(dir, destDir);
            }
        }

        static void MostrarInformacoes()
        {
            Console.Write("Digite o caminho do arquivo ou pasta: ");
            string caminho = Console.ReadLine();

            if (File.Exists(caminho))
            {
                FileInfo fi = new FileInfo(caminho);
                Console.WriteLine($"Tamanho: {fi.Length} bytes");
                Console.WriteLine($"Criado em: {fi.CreationTime}");
                Console.WriteLine($"Última modificação: {fi.LastWriteTime}");
            }
            else if (Directory.Exists(caminho))
            {
                DirectoryInfo di = new DirectoryInfo(caminho);
                Console.WriteLine($"Criado em: {di.CreationTime}");
                Console.WriteLine($"Última modificação: {di.LastWriteTime}");
            }
            else
            {

                Console.WriteLine("Arquivo ou pasta não encontrado.");

            }
        }
    }
}