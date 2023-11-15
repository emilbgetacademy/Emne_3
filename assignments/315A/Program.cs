class Program
{        
    static void Main(string[] arguments)
    {
        var range = 250;
        var counts = new int[range];

        string text = "something";

        while (!string.IsNullOrWhiteSpace(text))
        {
            Console.Write("Skriv noe [la være blank for å avslutte]: ");
            text = Console.ReadLine() ?? "";
            text = text.ToLower();

            foreach (var character in text)
            {
                counts[(int)character]++;
            }

            for (var i = 0; i < range; i++)
            {
                if (counts[i] > 0)
                {
                    var character = (char)i;
                    Console.WriteLine(character + " - " + counts[i]);
                }
            }

        }
    }
}
