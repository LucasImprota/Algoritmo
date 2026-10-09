using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.Write("Digite o caminho da pasta: ");
        string caminho = Console.ReadLine();

        if (Directory.Exists(caminho))
        {
            ListarArquivosRecursivo(caminho);
        }
        else
        {
            Console.WriteLine("Pasta não encontrada!");
        }
    }

    static void ListarArquivosRecursivo(string pasta)
    {
        try
        {
            // Lista todos os arquivos da pasta atual
            string[] arquivos = Directory.GetFiles(pasta);
            foreach (var arquivo in arquivos)
            {
                Console.WriteLine(arquivo);
            }

            // Para cada subpasta, chama recursivamente
            string[] subpastas = Directory.GetDirectories(pasta);
            foreach (var subpasta in subpastas)
            {
                ListarArquivosRecursivo(subpasta);
            }
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine($"Acesso negado à pasta: {pasta}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao acessar a pasta {pasta}: {ex.Message}");
        }
    }
}
