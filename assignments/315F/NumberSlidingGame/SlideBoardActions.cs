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

        for (int i = 0; i < Board.Numbers.Length - 1; i++)
        {
            if (Board.Numbers[i] > Board.Numbers[i + 1]) return false;
        }
        return true;
    }

    public void Display()
    {
        // Console.Clear();
        Console.WriteLine("Display() needs proper formating (for multi digit numbers)..");
        Console.WriteLine("Board:");

        foreach (int row in Board.Rows())
        {
            foreach (int col in Board.Columns())
            {
                int number = Board.GetNumber(row, col);
                // write the number
                if (number < Board.LargestNumber) Console.Write($"{number} ");
                // or if largest number, substitute an empty tile
                else Console.Write($" ");
            }
            Console.Write("\n");
        }
    }
}
