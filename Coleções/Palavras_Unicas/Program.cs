using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palavras_Unicas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> palavras = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            string entrada;

            Console.WriteLine("Digite palavras (digite 'fim' para encerrar):");

            while (true)
            {
                Console.Write("Palavra: ");
                entrada = Console.ReadLine().Trim();

                if (entrada.Equals("fim", StringComparison.OrdinalIgnoreCase))
                    break;

                if (!string.IsNullOrWhiteSpace(entrada))
                    palavras.Add(entrada);
            }

            Console.WriteLine("\n📋 Palavras únicas inseridas:");
            if (palavras.Count == 0)
            {
                Console.WriteLine("Nenhuma palavra foi inserida.");
            }
            else
            {
                foreach (string palavra in palavras)
                {
                    Console.WriteLine($"- {palavra}");
                }
            }
            Console.ReadKey();
        }
    }
}
