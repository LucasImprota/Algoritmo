using System;

class Program
{
    static void Main()
    {
        Console.Write("Digite um número inteiro positivo: ");
        int num = int.Parse(Console.ReadLine());

        int qtdDigitos = ContarDigitos(num);
        Console.WriteLine($"Número de dígitos: {qtdDigitos}");
    }

    static int ContarDigitos(int n)
    {
        // Caso base: se o número é menor que 10, tem 1 dígito
        if (n < 10)
            return 1;

        // Passo recursivo: 1 + dígitos do número sem o último dígito
        return 1 + ContarDigitos(n / 10);
    }
}
