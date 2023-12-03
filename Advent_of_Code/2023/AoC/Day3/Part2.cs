namespace AoC.Day3;

class Part2
{
    private static string[] _puzzle_input = Array.Empty<string>();
    private static bool _print_line = false; 
    private static int _print_line_at = 61; 
    private static int _last_row = 0;
    private static int _last_col = 0;

    public static string Run(string[] puzzle_input)
    {
        _puzzle_input = puzzle_input;

        // we treat the whole input as a matrix - each line is a row and each character is a column
        _last_row = _puzzle_input.Length - 1;
        _last_col = _puzzle_input[0].Length - 1; // each line has the exact same char count, we count first line

        return HandlePuzzleInput();
    }

    private static string HandlePuzzleInput()
    {
        if (_puzzle_input == null) Environment.Exit(1);

        int total = 0;

        // start from 2nd row
        for (int row = 1; row < _last_row; row++)
        {
            _print_line = _print_line_at == row;


            if (_print_line)
            {
                Console.WriteLine($"row {row-1} - {_puzzle_input[row-1]}");
                Console.WriteLine($"row {row} - {_puzzle_input[row]}");
                Console.WriteLine($"row {row+1} - {_puzzle_input[row+1]}");
            } 

            // start from 2nd column
            for (int col = 1; col < _last_col; col++)
            {
                if (!IsStar(row, col)) continue;
                if (AdjacentNumbers(row, col) < 2) continue;
                total += ExtractGearRatio(row, col);
            }
        }

        return total.ToString();
    }

    private static int AdjacentNumbers(int row, int col)
    {
        int row_up = row - 1;
        int col_left = col - 1;
        int col_right = col + 1;
        int row_down = row + 1;

        int total = 0;

        int total_above = 0;
        if (char.IsNumber(_puzzle_input[row_up][col_left]))
        {
            total_above += 1;
        }
        if (char.IsNumber(_puzzle_input[row_up][col_right]))
        {
            total_above += 1;
        }
        if (total_above == 2 && char.IsNumber(_puzzle_input[row_up][col]))
        {
            total_above -= 1;
        }
        total += total_above;

        if (char.IsNumber(_puzzle_input[row][col_left]))
        {
            total += 1;
        }
        if (char.IsNumber(_puzzle_input[row][col_right]))
        {
            total += 1;
        }

        int total_below = 0;
        if (char.IsNumber(_puzzle_input[row_down][col_left]))
        {
            total_below += 1;
        }
        if (char.IsNumber(_puzzle_input[row_down][col_right]))
        {
            total_below += 1;
        }
        if (total_below == 2 && char.IsNumber(_puzzle_input[row_down][col]))
        {
            total_below -= 1;
        }

        total += total_below;

        if (_print_line)
        {
            Console.WriteLine($"row {row} - total {total}");

        } 
        return total;


        // var adjacent_characters = new bool[8];

        // adjacent_characters[0] = char.IsNumber(_puzzle_input[row_up][col_left]);
        // adjacent_characters[1] = char.IsNumber(_puzzle_input[row_up][col]);
        // adjacent_characters[2] = char.IsNumber(_puzzle_input[row_up][col_right]);

        // adjacent_characters[3] = char.IsNumber(_puzzle_input[row][col_left]);
        // adjacent_characters[4] = char.IsNumber(_puzzle_input[row][col_right]);

        // adjacent_characters[5] = char.IsNumber(_puzzle_input[row_down][col_left]);
        // adjacent_characters[6] = char.IsNumber(_puzzle_input[row_down][col]);
        // adjacent_characters[7] = char.IsNumber(_puzzle_input[row_down][col_right]);

        // int count = 0;
        // foreach (bool is_number in adjacent_characters)
        // {
        //     if (is_number) count++;
        // }
        // return count;
    }

    private static bool IsStar(int row, int col)
    {
        return _puzzle_input[row][col] == '*';
    }

    private static int ExtractGearRatio(int row, int col)
    {
        int left_number = ExtractLeftNumber(row, col);
        int right_number = ExtractRightNumber(row, col);
        int above_number = ExtractAboveNumber(row, col);
        int below_number = ExtractBelowNumber(row, col);

        if (_print_line)  Console.WriteLine($"row {row} - {left_number} | {right_number} | {above_number} | {below_number}");
        return left_number * right_number * above_number * below_number;
    }

    private static int ExtractLeftNumber(int row, int col)
    {
        string number = String.Empty;

        if (char.IsNumber(_puzzle_input[row][col - 1]))
        {
            int start_col = 0;
            int new_col = col - 1;
            while(new_col >= 0)
            {
                char c = _puzzle_input[row][new_col];
                if (!char.IsNumber(c)) break;
                start_col = new_col;
                new_col--;
            }
            number = _puzzle_input[row].Substring(start_col, col - start_col);
        }

        if (number == String.Empty) return 1;
        return int.Parse(number);
    }

    private static int ExtractRightNumber(int row, int col)
    {
        string number = String.Empty;

        if (char.IsNumber(_puzzle_input[row][col + 1]))
        {
            int new_col = col + 1;
            while(new_col <= _last_col)
            {
                char c = _puzzle_input[row][new_col];
                if (!char.IsNumber(c)) break;

                number += c.ToString();
                new_col++;
            }
        }

        if (number == String.Empty) return 1;
        return int.Parse(number);
    }

    private static int ExtractAboveNumber(int row, int col)
    {
        string number = String.Empty;

        char up_left = _puzzle_input[row - 1][col - 1];
        if (char.IsNumber(up_left))
        {
            int start_col_left = col;
            int new_col_left = col - 1;
            while(new_col_left >= 0)
            {
                char c = _puzzle_input[row - 1][new_col_left];
                if (!char.IsNumber(c)) break;
                start_col_left = new_col_left;
                new_col_left--;
            }

            if (start_col_left != col)
            {
                string line = _puzzle_input[row - 1];
                number += line.Substring(start_col_left, col - start_col_left);
            }
        }

        char up = _puzzle_input[row - 1][col];
        if (char.IsNumber(up)) number += up;

        char up_right = _puzzle_input[row - 1][col + 1];
        if (char.IsNumber(up_right))
        {
            int new_col_right = col + 1;
            while(new_col_right <= _last_col)
            {
                char c = _puzzle_input[row - 1][new_col_right];
                if (char.IsNumber(c)) number += c.ToString();
                else break;
                new_col_right++;
            }
        }

        if (number == String.Empty) return 1;
        return int.Parse(number);
    }

    private static int ExtractBelowNumber(int row, int col)
    {
        string number = String.Empty;

        char down_left = _puzzle_input[row + 1][col - 1];
        if (char.IsNumber(down_left))
        {
            int start_col_left = col;
            int new_col_left = col - 1;
            while(new_col_left >= 0)
            {
                char c = _puzzle_input[row + 1][new_col_left];
                if (!char.IsNumber(c)) break;
                start_col_left = new_col_left;
                new_col_left--;
            }
            if (start_col_left != col)
            {
                string line = _puzzle_input[row + 1];
                number += line.Substring(start_col_left, col - start_col_left);
            }
        }

        char down = _puzzle_input[row + 1][col];
        if (char.IsNumber(down)) number += down;

        char down_right = _puzzle_input[row + 1][col + 1];
        if (char.IsNumber(down_right))
        {
            int new_col_right = col + 1;
            while(new_col_right <= _last_col)
            {
                char c = _puzzle_input[row + 1][new_col_right];
                if (char.IsNumber(c)) number += c.ToString();
                else break;
                new_col_right++;
            }
        }

        if (number == String.Empty) return 1;
        return int.Parse(number);
    }
}
