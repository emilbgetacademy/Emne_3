namespace AoC.Day4;

class Part1
{
    private static int _card_number_count = 0;
    private static int _winning_number_count = 0;
    public static string Run(string[] puzzle_input)
    {
        Console.WriteLine("Running day 4 part 1");

        _card_number_count = CalculateCardNumberCount(puzzle_input);
        _winning_number_count = CalculateWinningNumberCount(puzzle_input);

        Console.WriteLine($" should be 5 got {_card_number_count}");
        Console.WriteLine($" should be 8 got {_winning_number_count}");

        int result = HandlePuzzleInput(puzzle_input);

        return result.ToString();
    }

    private static int HandlePuzzleInput(string[] puzzle_input)
    {
        // string card = String.Empty;
        foreach (string line in puzzle_input)
        {
            string card_numbers = String.Empty;
            string winning_numbers = String.Empty;

            string all_numbers = line.Split(":")[1];

            card_numbers = all_numbers.Split("|")[0];
            winning_numbers = all_numbers.Split("|")[1];
            // Console.WriteLine(card_numbers);
            // Console.WriteLine(winning_numbers);
            // Console.WriteLine();
        }
        return 0;
    }

    private static int CalculateCardNumberCount(string[] puzzle_input)
    {
        // each card has a fixe amount of numbers, lets get that..
        string first_line = puzzle_input[2];
        string card_numbers = first_line.Split(":")[1].Split("|")[0].Trim();
        return card_numbers.Split(" ").Length;
    }
    private static int CalculateWinningNumberCount(string[] puzzle_input)
    {
        // each card has a fixe amount of winning numbers, lets get that..
        string first_line = puzzle_input[2];
        string card_numbers = first_line.Split(":")[1].Split("|")[1].Trim();
        // Console.WriteLine(first_line.Split(":")[1].Split("|")[1]);
        // foreach (char l in card_numbers)
        // {
        //     Console.WriteLine(l);

        // }
        return card_numbers.Split(" ").Length;
    }
}
