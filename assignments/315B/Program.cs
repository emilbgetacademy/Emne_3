using System.Runtime.CompilerServices;

class Program
{        
    private static readonly int _range = 250;
    private static readonly int[] _counts = new int[_range];
    
    static int Main()
    {
        while (true)
        {
            string text = InputUserText();

            if (string.IsNullOrWhiteSpace(text))
            {
                Console.WriteLine("Ferdig!");
                return 0;
            }

            CountCharacters(text);
            PrintCountedCharacters(text);
        }
    }

    static string InputUserText()
    {
        Console.Write("Skriv noe [blank for å avslutte]: ");
        string text = Console.ReadLine() ?? "";
        return text.ToLower();
    }

    static void CountCharacters(string text)
    {
        foreach (var c in text)
        {
            int index = (int)c;
            _counts[index]++;
        }
    }

    static void PrintCountedCharacters(string text)
    {
        for (var i = 0; i < _range; i++)
        {
            int sum = _counts[i];
            if (sum == 0) continue;

            char letter = (char)i;
            Console.WriteLine(letter + " - " + sum);
        }
    }

}
