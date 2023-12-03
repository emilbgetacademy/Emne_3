namespace AoC.Day3;

class Part1
{
    private static string[]? _puzzle_input;
    private static int _row_count = 0;
    private static int _col_count = 0;

    public static string Run(string[] puzzle_input)
    {
        _puzzle_input = puzzle_input;

        // we treat the whole input as a matrix - each line is a row and each character is a column
        _row_count = _puzzle_input.Length;
        _col_count = _puzzle_input[0].Length; // each line has the exact same char count, we count first line

        return HandlePuzzleInput();
    }

    private static string HandlePuzzleInput()
    {
        if (_puzzle_input == null) Environment.Exit(1);

        int total = 0;
        for (int row = 0; row < _row_count; row++)
        {
            int col = 0;
            while (col < _col_count)
            {
                int total_digits = 0;
                int start_col = col;

                // this triggers on the first char that is a digit and ends on the last
                while (char.IsNumber(_puzzle_input[row][col]))
                {
                    total_digits++;
                    if (col + 1 == _col_count) break; // do not go to next col if this is the last col
                    col++;
                }

                // having any digits means we have a number, lets see if it is a valid part number before adding it
                if (total_digits > 0)
                {
                    int end_col = start_col + total_digits - 1;
                    string number = _puzzle_input[row].Substring(start_col, total_digits);
                    if (ValidPartNumber(row, start_col, end_col)) total += int.Parse(number);
                } 

                col++;
            }
        }

        return total.ToString();
    }

    private static bool ValidPartNumber(int row, int start_col, int end_col)
    {
        if (_puzzle_input == null) Environment.Exit(1);

        // check above characters
        if (row > 0)
        {
            for (int col = start_col; col <= end_col; col++)
            {
                if (SymbolIsValid(_puzzle_input[row - 1][col])) return true;
            }
        }

        // check below characters
        if (row < _row_count - 1)
        {
            for (int col = start_col; col <= end_col; col++)
            {
                if (SymbolIsValid(_puzzle_input[row + 1][col])) return true;
            }
        }

        // check left character
        if (start_col > 0)
        {
            if (SymbolIsValid(_puzzle_input[row][start_col - 1])) return true;
        }

        // check right character
        if (end_col < _col_count - 1)
        {
            if (SymbolIsValid(_puzzle_input[row][end_col + 1])) return true;
        }

        // check character above left
        if (row > 0 && start_col > 0)
        {
            if (SymbolIsValid(_puzzle_input[row - 1][start_col - 1])) return true;
        }

        // check character above right
        if (row > 0 && end_col < _col_count - 1)
        {
            if (SymbolIsValid(_puzzle_input[row - 1][end_col + 1])) return true;
        }

        // check character below left
        if (row < _row_count - 1 && start_col > 0)
        {
            if (SymbolIsValid(_puzzle_input[row + 1][start_col - 1])) return true;
        }

        // check character below right
        if (row < _row_count - 1 && end_col < _col_count - 1)
        {
            if (SymbolIsValid(_puzzle_input[row + 1][end_col + 1])) return true;
        }

        return false;
    }

    private static bool SymbolIsValid(char c)
    {
        if (c == '.') return false; // periods makes invalid
        if (char.IsNumber(c)) return false; // if by chance, there is a number adjacent; thats invalid too

        // any other symbol makes it valid
        return true;
    }
}
