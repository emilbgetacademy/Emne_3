class WordListActions
{
    private readonly List<string> _wordlist;

    public WordListActions(List<string> wordlist)
    {
        _wordlist = wordlist;
    }

    public void PrintAllLines()
    {
        // print all content to console
        foreach (string line in _wordlist) Console.WriteLine(line);
    }
}
