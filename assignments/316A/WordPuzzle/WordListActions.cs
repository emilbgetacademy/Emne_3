class WordListActions
{
    private readonly string[] _wordlist;

    public WordListActions(string[] wordlist)
    {
        _wordlist = wordlist;
    }

    public void PrintAllLines()
    {
        // print all content to console
        foreach (string line in _wordlist) Console.WriteLine(line);
    }
}
