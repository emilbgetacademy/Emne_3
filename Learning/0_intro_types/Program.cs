using System.Globalization;

namespace _0_intro_types;
class Program
{
    // TYPE         SIZE                    DESCRIPTION
    // ----         ----                    -----------
    // int          4 bytes                 Stores whole numbers from -2,147,483,648 to 2,147,483,647
    // long	        8 bytes                 Stores whole numbers from -9,223,372,036,854,775,808 to 9,223,372,036,854,775,807
    // float        4 bytes                 Stores fractional numbers. Sufficient for storing 6 to 7 decimal digits
    // double	    8 bytes                 Stores fractional numbers. Sufficient for storing 15 decimal digits
    // bool	        1 bit	                Stores true or false values
    // char	        2 bytes	                Stores a single character/letter, surrounded by single quotes
    // string	    2 bytes per character	Stores a sequence of characters, surrounded by double quotes
    static void Main(string[] args)
    {
        ExampleAskQuestions();
        ExampleCalculateNumbers();
    }

    private static void ExampleAskQuestions()
    {
        string name = AskQuestions.StringInStringOut("Hva heter du?");
        int age = AskQuestions.StringIn32IntOut("Hvor gammel er du?");
        bool likeProgramming = AskQuestions.StringInBoolOut("Liker du å programmere?");

        if (likeProgramming)
        {
            Console.WriteLine($"Ditt navn er {name} og du er {age} år gammel og liker programmering");
        } else {
            Console.WriteLine($"Ditt navn er {name} og du er {age} år gammel og liker ikke programmering");
        }
    }

    private static void ExampleCalculateNumbers()
    {
        int myNumber = 15;
        double myNumberMultiplied = CalculateNumbers.IntMultiplyWith10(myNumber);
        Console.WriteLine($"{myNumber} multiplisert med 10 er {myNumberMultiplied}");
        double myNumberDividedBy10 = CalculateNumbers.IntDivideBy10(myNumber);
        Console.WriteLine($"{myNumber} delt på 10 er {myNumberDividedBy10}");
    }
}
