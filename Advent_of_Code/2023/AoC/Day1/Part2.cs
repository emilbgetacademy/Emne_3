namespace AoC.Day1;

class Part2
{
    public static string Run(string[] puzzle_input)
    {
        string[] number_list = new string[puzzle_input.Length];

        for (int line = 0; line < puzzle_input.Length; line++)
        {
            string s = puzzle_input[line];

            int? first_digit = CalibrationDocument.FirstNumericDigitOrSpelledDigitFromString(s);
            int? last_digit = CalibrationDocument.LastNumericDigitOrSpelledDigitFromString(s);

            if (first_digit == null || last_digit == null) Environment.Exit(1);

            number_list[line] = first_digit.ToString() + last_digit.ToString();
        }

        int total = 0;

        foreach (string s in number_list)
        {
            bool is_numeric = int.TryParse(s, out int number);
            if (is_numeric) total += number;
        }

        return total.ToString();
    }
}
