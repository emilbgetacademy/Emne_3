namespace AoC.Day1;

partial class CalibrationDocument
{
    private static string[] _spelled_digits = new string[]
    {
        "one",
        "two",
        "three",
        "four",
        "five",
        "six",
        "seven",
        "eight",
        "nine",
    };

    public static int? FirstDigitFromString(string s)
    {
        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];
            if (char.IsNumber(c))
            {
                int digit = c - '0';
                return digit;
            }
        }

        return null;
    }

    public static int? LastDigitFromString(string s)
    {
        for (int i = s.Length-1; i >= 0; i--)
        {
            char c = s[i];
            if (char.IsNumber(c))
            {
                int digit = c - '0';
                return digit;
            }
        }

        return null;
    }

    public static int? FirstNumericDigitOrSpelledDigitFromString(string s)
    {
        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];
            if (char.IsNumber(c))
            {
                int digit = c - '0';
                return digit;
            }

            foreach (string spelled in _spelled_digits)
            {
                int last_index = i + spelled.Length;

                if (last_index > s.Length) continue;

                if (s.Substring(i, spelled.Length) == spelled)
                {
                    return spelled switch
                    {
                        "one" => 1,
                        "two" => 2,
                        "three" => 3,
                        "four" => 4,
                        "five" => 5,
                        "six" => 6,
                        "seven" => 7,
                        "eight" => 8,
                        "nine" => 9,
                        _ => null,
                    };
                }
            }
        }

        return null;
    }

    public static int? LastNumericDigitOrSpelledDigitFromString(string s)
    {
        for (int i = s.Length; i >= 0; i--)
        {
            char c = s[i-1];
            if (char.IsNumber(c))
            {
                int digit = c - '0';
                return digit;
            }

            foreach (string spelled in _spelled_digits)
            {
                int first_index = i - spelled.Length;

                if (first_index < 0) continue;

                if (s.Substring(first_index, spelled.Length) == spelled)
                {
                    return spelled switch
                    {
                        "one" => 1,
                        "two" => 2,
                        "three" => 3,
                        "four" => 4,
                        "five" => 5,
                        "six" => 6,
                        "seven" => 7,
                        "eight" => 8,
                        "nine" => 9,
                        _ => null,
                    };
                }
            }
        }

        return null;
    }
}
