
class Program
{
    static void Main()
    {
        // country ..only norwegian exists though, but we like to structure our apps nicely :)
        string language = "Norwegian";

        // wordlists are compressed (compression ratio for text is great) and we get them from here ..we like to save space :)
        string word_list = WordLists.Get(language);

        // lets start..
        var word_list_actions = new WordListActions(word_list);

        // ..print everyting in console so we know wether everything works or not :)
        word_list_actions.PrintAllLines();
    }
}
