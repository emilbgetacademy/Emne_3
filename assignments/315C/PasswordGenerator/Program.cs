namespace PasswordGenerator;
class Program
{
    private static readonly string _allowed_letters = "lLsd";
    private static readonly string _lower_case_alphabet = "abcdefghijklmopqrstuvwxyzæøå";
    private static readonly string _upper_case_alphabet = "ABCDEFGHIJKLMOPQRSTUVWXYZÆØÅ";
    private static readonly string _special_characters = "(!\"#\u00a4%&/(){}[]";
    private readonly static Random _random = new();
    private static string _generated_password = "";

    static void Main(string[] args)
    {
        if (args.Length != 2) ShowInstructionsAndQuit();

        int characters_remaining = GetFirstArgument(args[0]);
        string password_options = GetSecondArgument(args[1]);

        if (!NumberIsGreaterOrEqualToWordLength(characters_remaining, password_options))
        {
            ShowInstructionsAndQuit();
        }

        Console.WriteLine($"password length: {characters_remaining}");
        Console.WriteLine($"password_options: {password_options}");

        char[] arr_password_options = password_options.ToCharArray();
        bool[] arr_options_satisfied = new bool[password_options.Length];
        int round = 1;
        while (characters_remaining > 0)
        {
            int char_index = _random.Next(0, password_options.Length);
            char char_option = password_options[char_index];

            arr_password_options[char_index] = char_option;
            arr_options_satisfied[char_index] = true;

            _generated_password += GetCharacter(char_option);

            Console.WriteLine($"round {round}: option {char_index} - {char_option}");

            round ++;
            characters_remaining--;
        }

       for (var i = 0; i < arr_password_options.Length; i++)
       {
            char c = arr_password_options[i];
            string satisfied = arr_options_satisfied[i] ? "true" : "false";

            Console.WriteLine($"index: {i}, c: {c}, satisfied: {satisfied}");
       }
        Console.WriteLine($"password: {_generated_password}");
    }

    private static char GetCharacter(char c)
    {
        return c switch
        {
            'L' => GetRandomUpperCaseCharacter(),
            'l' => GetRandomLowerCaseCharacter(),
            's' => GetRandomSpecialCharacter(),
            'd' => GetRandomDigitCharacter(),

            // if none above -> default (..just for runtime safety)
            _ => GetRandomLowerCaseCharacter(),
        };
    }

    private static char GetRandomLowerCaseCharacter()
    {
        int index = _random.Next(0, _lower_case_alphabet.Length);
        return _lower_case_alphabet[index];
    }

    private static char GetRandomUpperCaseCharacter()
    {
        int index = _random.Next(0, _upper_case_alphabet.Length);
        return _upper_case_alphabet[index];
    }

    private static char GetRandomSpecialCharacter()
    {
        int index = _random.Next(0, _special_characters.Length);
        return _special_characters[index];
    }

    private static char GetRandomDigitCharacter()
    {
        int random_number = _random.Next(0, 10);
        // NOTE: we have to add the random number to the ASCII value of '0' to convert to char
        return (char)('0' + random_number);
    }

    private static int GetFirstArgument(string argument)
    {
        foreach (char c in argument)
        {
            if (!char.IsDigit(c)) ShowInstructionsAndQuit();
        }
        return Convert.ToInt32(argument);
    }

    private static string GetSecondArgument(string word)
    {
        foreach (var c in word)
        {
            if (!_allowed_letters.Contains(c)) ShowInstructionsAndQuit();;
        }
        return word;
    }

    private static bool NumberIsGreaterOrEqualToWordLength(int length, string word)
    {
        return length >= word.Length;
    }

    private static void ShowInstructionsAndQuit()
    {
        Console.WriteLine("FEIL: Argumenter\n");
        Console.WriteLine("Første argument er lengden på passord:");
        Console.WriteLine("  <N>");
        Console.WriteLine("Andre argument skal inneholde en eller flere bokstaver (må være kortere eller like mange som lengden):");
        Console.WriteLine("  l = liten bokstav");
        Console.WriteLine("  L = stor bokstav");
        Console.WriteLine("  d = siffer");
        Console.WriteLine("  s = spesialtegn \"!#¤%&/(){}[]");
        Console.WriteLine("Eksempel:");
        Console.WriteLine("  <command> 14 lLssdd");
        Environment.Exit(1);
    }
}
