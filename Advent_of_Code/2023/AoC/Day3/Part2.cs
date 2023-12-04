namespace AoC.Day3;

class Part2
{
    private static string[] _puzzle_input = Array.Empty<string>();
    private static bool _print_line = false; 
    private static int _print_line_at = 34; 
    private static int _last_row = 0;
    private static int _last_col = 0;

    public static string Run(string[] puzzle_input)
    {
        _puzzle_input = puzzle_input;

        // we treat the whole input as a matrix - each line is a row and each character is a column
        _last_row = _puzzle_input.Length - 1;
        _last_col = _puzzle_input[0].Length - 1; // each line has the exact same char count, we count first line

        int result = HandlePuzzleInput();

        return result.ToString();
    }

    private static int HandlePuzzleInput()
    {
        if (_puzzle_input == null) Environment.Exit(1);

        int total = 0;

        for (int row = 0; row < _last_row; row++)
        {
            _print_line = _print_line_at == row;

            if (_print_line)
            {
                Console.WriteLine($"row {row} - {_puzzle_input[row]}");
            }

            for (int col = 0; col < _last_col; col++)
            {
                if (!IsStar(row, col)) continue;

                total += GetRatio(row, col);
            }
        }

        return total;
    }

    private static bool IsStar(int row, int col)
    {
        return _puzzle_input[row][col] == '*';
    }

    private static int GetRatio(int row, int col)
    {
        int ratio = 0;
        return ratio;
    }
}
