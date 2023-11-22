class SlideBoardActions
{
    private readonly SlideBoardModel Board;

    public SlideBoardActions(SlideBoardModel board)
    {
        Board = board;
    }

    public void ShuffleNumbers()
    {
        Board.Numbers[0] = 5;
        Board.Numbers[4] = 1;
        Console.WriteLine("ShuffleNumbers() needs implementing");
    }

    public int SelectNumber()
    {
        // blank tile (repr. the largest number) is returned if we get a non valid value from user
        int blank_tile = Board.LargestNumber;

        Console.Write("Select number to slide: ");
        string user_input = Console.ReadLine() ?? "";

        if (user_input == "") return blank_tile;

        if (int.TryParse(user_input, out int number))
        {
            if (number < 1 || number >= blank_tile)
            {
                Console.WriteLine($"Choose a number between 1 and {Board.LargestNumber - 1}");
                return blank_tile;
            }
            Console.WriteLine($"inserted: {number}");


            return number;
        }
        else
        {
            Console.WriteLine($"'{user_input}' is not a number, please type a number from the board");
            return blank_tile;
        }
    }

    public bool MoveNumber(int number)
    {
        // ignore moving when largest number (which is the blank tile) is selected
        if (number == Board.LargestNumber) return false;

        int row = Board.GetRow(number);
        int col = Board.GetCollumn(number);
        Console.WriteLine($"CellRow: {row}");
        Console.WriteLine($"CellCollumn: {col}");

        if (Board.IsSolved()) return true;
        return false;
    }

    public void PrintBoard()
    {
        // Console.Clear();
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
