// Commandline-argument for this application should be passed as follows
// dotnet run <day> <part>

// Example for day 1 and part 2: dotnet run 1 2
class Program
{
    private static readonly int _current_day = 3;

    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            // run all days up to (and including) _current_day
            for (int day = 1; day <= _current_day; day++)
            {
                for (int part = 1; part <= 2; part++)
                {
                    Puzzle(day.ToString(), part.ToString());
                }
            }
        }
        else if (args.Length == 1)
        {
            // run one day and both parts
            Puzzle(args[0], "1");
            Puzzle(args[0], "2");
        }
        else
        {
            // run one day and one part
            Puzzle(args[0], args[1]);
        }
    }

    private static void Puzzle(string _day, string _part)
    {
        var puzzle_io = new AoC.PuzzleIO(_day, _part);

        string[] puzzle_input = puzzle_io.ReadInput();

        string puzzle_output = (_day, _part) switch
        {
            ( "1", "1" ) => AoC.Day1.Part1.Run(puzzle_input),
            ( "1", "2" ) => AoC.Day1.Part2.Run(puzzle_input),
            ( "2", "1" ) => AoC.Day2.Part1.Run(puzzle_input),
            ( "2", "2" ) => AoC.Day2.Part2.Run(puzzle_input),
            ( "3", "1" ) => AoC.Day3.Part1.Run(puzzle_input),
            ( "3", "2" ) => AoC.Day3.Part2.Run(puzzle_input),

            _ => $"Day {_day} and part {_part} is not yet implemented",
        };

        if (puzzle_output != String.Empty) puzzle_io.WriteOutput(puzzle_output);
    }
}
