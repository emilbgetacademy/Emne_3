namespace WordPuzzle;
class Program
{
    public static string _language = "Norwegian";
    public static readonly Random _rnd = new();
    static void Main()
    {
        var wordlist = new WordList(_language);

        foreach (string w in wordlist.AllWords()) Console.WriteLine(w);

        string random_word = wordlist.GetWordByIndex( _rnd.Next(0, wordlist.WordCount()) );
        Console.WriteLine($"Random word: {random_word}");

        bool overlap = WordCheck.OverlapBy3("ww", "sd");
        if (overlap) Console.WriteLine("Words overlap!");
    }
}
