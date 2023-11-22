class SlideBoardModel
{
    // properties
    public readonly int Width;
    public readonly int Height;
    public readonly int Size;
    public readonly int LargestNumber;
    public readonly int[] Numbers;

    // constructor
    public SlideBoardModel(int width, int height)
    {
        Width = width;
        Height = height;
        Size = width * height;
        LargestNumber = Size;
        Numbers = new int[Size];
        for (int i = 0; i < Size; i++)
        {
            Numbers[i] = i + 1;
        }
    }

    public IEnumerable<int> Rows()
    {
        // iterator for iterating over the boards rows
        int row = 1;
        while (row <= Height)
            yield return row++;
    }

    public IEnumerable<int> Columns()
    {
        // iterator for iterating over the boards collumns
        int col = 1;
        while (col <= Width)
            yield return col++;
    }

    public int GetNumber(int row, int col)
    {
        // user of this interface expects rows and columns to start from 1, we adjust for that
        row--;
        col--;
        // the index for the one dimensional array is calculated using row and col
        int index = (row * Width) + col;
        return Numbers[index];
    }

    public void SetNumber(int row, int col, int number)
    {
        // user of this interface expects rows and columns to start from 1, we adjust for that
        row--;
        col--;
        // the index for the one dimensional array is calculated using row and col
        int index = (row * Width) + col;
        Numbers[index] = number;
    }

    public int GetRow(int number)
    {
        int index = Array.IndexOf(Numbers, number);
        int row = (index / Width) + 1;
        return row;
    }

    public int GetCollumn(int number)
    {
        int index = Array.IndexOf(Numbers, number);
        int col = (index % Width) + 1;
        return col;
    }

    public bool IsSolved()
    {
        for (int i = 0; i < Numbers.Length - 1; i++)
        {
            if (Numbers[i] > Numbers[i + 1]) return false;
        }
        return true;
    }
}
