class SlideBoardGame
{
    public static void Start()
    {
        int row_count = 5;
        int col_count = 6;

        var board   = new SlideBoardModel(row_count, col_count);
        var actions = new SlideBoardActions(board);

        actions.ShuffleNumbers();

        int selected_number;
        bool solved = false;
        while (!solved)
        {
            actions.PrintBoard();
            selected_number = actions.SelectNumber();
            solved = actions.MoveNumber(selected_number);
        }
        actions.PrintBoard();
        Console.WriteLine($"Congratulations, you completed the board!");
    }
}
