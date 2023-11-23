class WordListActions
{
    private readonly string _wordlist;

    public WordListActions(string word_list)
    {
        _wordlist = word_list;
    }

    public void PrintAllLines()
    {
        // print all content to console
        Console.WriteLine(_wordlist);
    }
}
