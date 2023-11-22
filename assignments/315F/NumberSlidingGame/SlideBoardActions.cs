class SlideBoardActions
{
    private readonly SlideBoardModel Board;

    public SlideBoardActions(SlideBoardModel board)
    {
        Board = board;
    }

    public void ShuffleNumbers()
    {
        Console.WriteLine("ShuffleNumbers() needs implementing");
    }

    public int SelectNumber()
    {
        int selected_number = Board.LargestNumber;

        while (selected_number == Board.LargestNumber)
        {
            Console.Write("Select number to slide: ");
            string user_input = Console.ReadLine() ?? "";

            if (user_input == "")
            {
                Console.WriteLine("No input");
            }
            else if (int.TryParse(user_input, out int number))
            {
                if (number > 0 && number < Board.LargestNumber)
                {
                    selected_number = number;
                }
                else {
                    Console.WriteLine($"Must be a number between 1 and {Board.LargestNumber - 1}");
                }
            }
            else
            {
                Console.WriteLine($"'{user_input}' is not a number, chose a number from the board");
            }
        }

        return selected_number;
    }

    public bool MoveNumber(int number)
    {
        int blank_tile = Board.LargestNumber;
        int row = Board.GetRow(blank_tile);
        int col = Board.GetCollumn(blank_tile);

        int[] movable_numbers = new int[4];
        movable_numbers[0] = (row > 1) ? Board.GetNumber(row - 1, col) : blank_tile; 
        movable_numbers[1] = (col > 1) ? Board.GetNumber(row, col - 1) : blank_tile; 
        movable_numbers[2] = (row < Board.Height) ? Board.GetNumber(row + 1, col) : blank_tile; 
        movable_numbers[3] = (col < Board.Width) ? Board.GetNumber(row, col + 1) : blank_tile; 

        foreach (int movable_number in movable_numbers)
        {
            if (number == movable_number)
            {
                int selected_row = Board.GetRow(number);
                int selected_col = Board.GetCollumn(number);

                int blank_row = Board.GetRow(blank_tile);
                int blank_col = Board.GetCollumn(blank_tile);

                Board.SetNumber(selected_row, selected_col, blank_tile);
                Board.SetNumber(blank_row, blank_col, number);
            }
        }

        if (Board.IsSolved()) return true;
        else return false;
    }

    public void PrintBoard()
    {
        Console.Clear();
        Console.WriteLine("Board:");
        foreach (int row in Board.Rows())
        {
            string number_row = "|";
            foreach (int col in Board.Columns())
            {
                string tile = "";

                int number = Board.GetNumber(row, col);
                if (number < Board.LargestNumber) tile = number.ToString();

                tile = tile.PadLeft(Board.LargestNumber.ToString().Length, ' ');
                number_row += " " + tile + " | ";
            }
            if (row == 1) Console.WriteLine("".PadLeft(number_row.Length-1, '-'));
            Console.WriteLine(number_row);
            Console.WriteLine("".PadLeft(number_row.Length-1, '-'));
        }
    }
}
