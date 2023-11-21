class SlideBoardGame
{
    public static void Start()
    {
        int row_count = 5;
        int col_count = 6;

        var board_model   = new SlideBoardModel(row_count, col_count);
        var board_cations = new SlideBoardActions(board_model);

        board_cations.ShuffleNumbers();

        int tries = 3;
        int i = 0;
        bool solved = false;
        while (!solved)
        {
            i++;
            board_cations.Display();
            if (i == tries)
            {
                Console.WriteLine($"Exit on {tries} tries");
                Environment.Exit(0);
            }
            solved = board_cations.MoveNumber(4);
        }
    }


}
