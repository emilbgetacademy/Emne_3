class SlideBoardActions
{
    private readonly SlideBoardModel Board;

    public SlideBoardActions(SlideBoardModel board)
    {
        Board = board;
    }

    public void ShuffleNumbers()
    {
        Random random = new();
        int shuffle_count = 1000;
        while (shuffle_count > 0)
        {
            int number = random.Next(1, Board.LargestNumber);
            if (Board.NumberCanMove(number))
            {
                MoveNumber(number);
                shuffle_count--;
            }
        }
    }

    public int SelectNumber()
    {
        Console.Write("Number to slide: ");
        while (true)
        {
            if (int.TryParse(Console.ReadLine() ?? "", out int number))
            {
                if (Board.NumberCanMove(number)) return number;
            }
            Console.WriteLine("Number must valid and adjacent to the blank tile");
        }
    }

    public bool MoveNumber(int selected_number)
    {
        int blank_tile = Board.LargestNumber;

        int selected_row = Board.GetRow(selected_number);
        int selected_col = Board.GetCollumn(selected_number);

        int blank_row = Board.GetRow(blank_tile);
        int blank_col = Board.GetCollumn(blank_tile);

        Board.SetNumber(selected_row, selected_col, blank_tile);
        Board.SetNumber(blank_row, blank_col, selected_number);

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
