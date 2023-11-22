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

    public bool MoveNumber(int number)
    {
        int n = number;
        Console.WriteLine("MoveNumber() needs implementing like user input etc.");

        if (Board.IsSolved()) return true;
        return false;
    }

    public void Display()
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
