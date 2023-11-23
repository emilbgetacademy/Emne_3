
class Program
{
    static void Main()
    {
        // country ..only norwegian exists though, but we like to structure our apps nicely :)
        string language = "Norwegian";

        // wordlists are compressed (compression ratio for text is great) and we get them from here ..we like to save space :)
        List<string> wordlist = WordLists.Get(language);

        // lets start..
        var wordlist_actions = new WordListActions(wordlist);

        // ..print everyting in console so we know wether everything works or not :)
        wordlist_actions.PrintAllLines();
    }
}
