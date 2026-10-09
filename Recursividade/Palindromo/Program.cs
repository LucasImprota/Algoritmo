using System;

class Program
{
    static void Main()
    {
        Console.Write("Digite uma palavra: ");
        string palavra = Console.ReadLine();

        bool ehPalindromo = EhPalindromo(palavra, 0, palavra.Length - 1);
        Console.WriteLine(ehPalindromo ? "É palíndromo" : "Não é palíndromo");
    }

    static bool EhPalindromo(string s, int inicio, int fim)
    {
        // Caso base: se cruzou os índices ou se estão iguais, é palíndromo
        if (inicio >= fim)
            return true;

        // Se os caracteres nas pontas forem diferentes, não é palíndromo
        if (s[inicio] != s[fim])
            return false;

        // Chamada recursiva para os caracteres internos
        return EhPalindromo(s, inicio + 1, fim - 1);
    }
}
