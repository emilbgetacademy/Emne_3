using System.Globalization;

namespace _0_intro_types;
class Program
{
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
