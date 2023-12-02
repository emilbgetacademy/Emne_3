namespace AoC.Day2;

class Part1
{
    public static string Run(string[] puzzle_input)
    {
        var GameData = new Tuple<int, bool>[puzzle_input.Length];
        for (int i = 0; i < puzzle_input.Length; i++)
        {
            GameData[i] = ExtractGameTuple(puzzle_input[i]);
        }

        int result = 0;
        foreach (var tuple in GameData)
        {
            int game_id = tuple.Item1;
            bool game_is_possible = tuple.Item2;
            if (game_is_possible) result += game_id;
        }

        return result.ToString();
    }

    private static Tuple<int, bool> ExtractGameTuple(string line)
    {
        string[] colon_split = line.Split(":");

        string string_game_id = colon_split[0].Split(" ")[1];
        bool game_id_extracted = int.TryParse(string_game_id, out int game_id);
        if (!game_id_extracted) Environment.Exit(1);

        string game_record = colon_split[1];

        bool game_possible = GameIsPossible(game_record);

        return Tuple.Create(game_id, game_possible);
    }

    private static bool GameIsPossible(string game_record)
    {
        foreach (string set in game_record.Split(";"))
        {
            foreach(string subset in set.Split(","))
            {
                // remove leading and trailing whitespace
                string trimmed_subset = subset.Trim();

                bool is_numeric = int.TryParse(trimmed_subset.Split(" ")[0], out int cube_count);
                if (!is_numeric) Environment.Exit(1);

                string cube_color = trimmed_subset.Split(" ")[1];

                bool not_possible = cube_color switch
                {
                    "red" => cube_count > 12,
                    "green" => cube_count > 13,
                    "blue" => cube_count > 14,
                    _ => false,
                };

                if (not_possible) return false;
            }
        }

        return true;
    }
}
