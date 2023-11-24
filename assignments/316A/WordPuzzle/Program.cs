namespace WordPuzzle;
class Program
{
    private static readonly string _language = "Norwegian";

    public static readonly int WordPuzzleCount = 200;
    public static readonly int MaxOverlap = 5;
    public static readonly int MinOverlap = 3;
    static void Main()
    {
        var wordlist = new WordLists(_language);

        var puzzle = new Puzzle(wordlist);

        puzzle.Run(WordPuzzleCount, MaxOverlap, MinOverlap);
    }
}
