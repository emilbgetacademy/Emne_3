class SlideBoardGame
{
    public static void Start()
    {
        int row_count = 5;
        int col_count = 6;

        var board_model   = new SlideBoardModel(row_count, col_count);
        var board_actions = new SlideBoardActions(board_model);

        board_actions.ShuffleNumbers();

        int selected_number;
        int tries = 3;
        int i = 0;
        bool solved = false;
        while (!solved)
        {
            i++;

            board_actions.PrintBoard();
            selected_number = board_actions.SelectNumber();
            solved = board_actions.MoveNumber(selected_number);

            if (i == tries)
            {
                Console.WriteLine($"Exit on {tries} tries");
                Environment.Exit(0);
            }
        }
    }
}
