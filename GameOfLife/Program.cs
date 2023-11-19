namespace GameOfLife;
class Program
{
    private static readonly int _window_witdh = Console.WindowWidth;
    private static readonly int _window_height = Console.WindowHeight - 1;
    private static char[] _cell_window = new char[_window_witdh * _window_height];

    static void Main(string[] args)
    {
        Random random_number = new();

        // first populate the window with living or dead cells first, 'O' or ' ' respectively
        for (int i = 0; i < _cell_window.Length; i++)
        {
            _cell_window[i] = (random_number.Next(0, 2) == 1) ? 'O' : ' ';
        }

        // then start the simulation
        while (true)
        {
            EvolveCells();
            Console.Clear();
            Console.WriteLine(_cell_window);
            Thread.Sleep(50);
        }
    }

    private static void EvolveCells()
    {
        char[] new_cell_window = new char[_cell_window.Length];

        for (var index = 0; index < _cell_window.Length; index++)
        {
            // store the condition of the old cell and its neighbours
            bool this_cell_is_alive = _cell_window[index] == 'O';
            bool this_cell_is_dead = _cell_window[index] == ' ';
            int total_living_neighbours = TotalLivingNeighbours(index);

            // if conditions are satisfied, next cell is living, if not; next cell is dead
            char new_cell = ' ';
            if (this_cell_is_alive && total_living_neighbours is 2 or 3) new_cell = 'O';
            if (this_cell_is_dead  && total_living_neighbours is 3) new_cell = 'O';

            // apply the new cell
            new_cell_window[index] = new_cell;
        }

        // apply the new generation of cells by overwriting the cells array
        _cell_window = new_cell_window;
    }

    private static int TotalLivingNeighbours(int index)
    {
        // get a calculated row and column index from the one dimensional array
        int row_index = OneDimArrayIndexToRowIndex(index);
        int col_index = OneDimArrayIndexToColumnIndex(index);

        int total_living_neighbours = 0;
        if (CellIsAlive(row_index - 1, col_index - 1)) total_living_neighbours += 1;
        if (CellIsAlive(row_index - 1, col_index    )) total_living_neighbours += 1;
        if (CellIsAlive(row_index - 1, col_index + 1)) total_living_neighbours += 1;
        if (CellIsAlive(row_index,     col_index - 1)) total_living_neighbours += 1;
        if (CellIsAlive(row_index,     col_index + 1)) total_living_neighbours += 1;
        if (CellIsAlive(row_index + 1, col_index - 1)) total_living_neighbours += 1;
        if (CellIsAlive(row_index + 1, col_index    )) total_living_neighbours += 1;
        if (CellIsAlive(row_index + 1, col_index + 1)) total_living_neighbours += 1;

        return total_living_neighbours;
    }

    private static int OneDimArrayIndexToRowIndex(int index) {
        int row_index = index / _window_witdh;
        return row_index;
    }

    private static int OneDimArrayIndexToColumnIndex(int index) {
        int col_index = index % _window_witdh;
        return col_index;
    }

    private static int RowAndColumnToOneDimArrayIndex(int row_index, int col_index) {
        int index = col_index + (row_index * _window_witdh);
        return index;
    }

    private static bool CellIsAlive(int row_index, int col_index)
    {
        // if index is outside the bounds of the array, evaluate as cell being dead
        if (row_index < 0) return false;
        if (col_index < 0) return false;
        if (row_index == _window_height) return false;
        if (col_index == _window_witdh) return false;

        // at this point, we are within the borders of the console window
        int index = RowAndColumnToOneDimArrayIndex(row_index, col_index);

        return _cell_window[index] == 'O';
    }

}
