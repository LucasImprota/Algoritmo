using System;

class Program
{
    static void Main()
    {
        string original = "algoritmo";
        string invertida = InverterString(original);
        Console.WriteLine(invertida);  // Saída: omtirogla
    }

    static string InverterString(string s)
    {
        if (s.Length <= 1)
            return s;

        return InverterString(s.Substring(1)) + s[0];
    }
}
