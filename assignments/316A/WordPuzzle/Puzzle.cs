namespace WordPuzzle;
class Puzzle
{
    public static readonly Random Rnd = new();
    private WordLists _wordlist;

    public Puzzle(WordLists wordlist)
    {
        _wordlist = wordlist;
    }
    
    public void Run(int _word_puzzle_count, int _max_overlap, int _min_overlap)
    {
        List<string> overlapping_parts = new();

        string string_to_print = String.Empty; // temporary for printing results

        while (_word_puzzle_count > 0)
        {
            int random_index = Rnd.Next(0, _wordlist.WordCount());
            string current_word = _wordlist.GetWordByIndex(random_index);

            bool found_overlap = false;
            foreach (string new_word in _wordlist.AllWords())
            {
                if (WordLib.CountShortestOverlap(_min_overlap, _max_overlap, current_word, new_word) >= _min_overlap)
                {
                    found_overlap = true;

                    string part_that_overlaps = WordLib.ExtractShortestOverlappingPart(_min_overlap, current_word, new_word);

                    if (_wordlist.WordInlist(part_that_overlaps))
                    {
                        overlapping_parts.Add(part_that_overlaps);
                    }

                    string_to_print += $"{current_word} - {new_word} -> ";
                    string_to_print += $"{part_that_overlaps}\n";
                    string_to_print += $"{part_that_overlaps.Length} bokstaver\n\n";
                    _word_puzzle_count--;
                    break;
                }
            }
            if (!found_overlap) string_to_print += $"{current_word}\n<fant ikke match>\n\n";
        }

        Console.WriteLine(string_to_print);

        foreach (string part in overlapping_parts)
        {
            Console.WriteLine($"overlapping parts: {part}");
        }
    }
}
