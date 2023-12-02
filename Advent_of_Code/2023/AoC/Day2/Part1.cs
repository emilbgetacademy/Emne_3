namespace AoC.Day2;

class Part1
{
    private static Tuple<int, string, bool>[]? GameData;
    private static bool print_this = false;
    private static int print_this_at_iteration = 36;
    public static string Run(string[] puzzle_input)
    {
        GameData = new Tuple<int, string, bool>[puzzle_input.Length];

        for (int i = 0; i < puzzle_input.Length; i++)
        {
            print_this = (i == print_this_at_iteration);

            // extract the game id for each line
            string line = puzzle_input[i];

            Tuple<int, string, bool> tuple = ExtractGameTuple(line);

            // add the game id and false to the array before doing more stuff
            GameData[i] = tuple;

            if (print_this) Console.WriteLine($"|{tuple.Item1}|, |{tuple.Item2}, {tuple.Item3}|");
           
        }

        return String.Empty;
    }

    private static Tuple<int, string, bool> ExtractGameTuple(string line)
    {
        string[] colon_split = line.Split(":");

        string string_game_id = colon_split[0].Split(" ")[1];
        bool game_id_extracted = int.TryParse(string_game_id, out int game_id);
        if (!game_id_extracted) Environment.Exit(1);

        string game_record = colon_split[1];

        bool is_possible = GameIsPossible(game_record);

        return Tuple.Create(game_id, game_record, is_possible);
    }

    private static bool GameIsPossible(string game_record)
    {
        foreach (string set in game_record.Split(";"))
        {
            if (print_this) Console.Write("\n");
            foreach(string subset in set.Split(","))
            {
                // remove leading and trailing whitespace
                string trimmed_subset = subset.Trim();

                string string_number = trimmed_subset.Split(" ")[0];
                string color = trimmed_subset.Split(" ")[1];

                bool is_numeric = int.TryParse(string_number, out int number);
                if (!is_numeric) Environment.Exit(1);

                if (print_this) Console.WriteLine($"{number} {color}");
               
                bool not_possible = color switch
                {
                    "red" => number > 12,
                    "green" => number > 13,
                    "blue" => number > 14,
                    _ => false,
                };

                if (not_possible) return false;
            }
        }

        return true;
    }

}
