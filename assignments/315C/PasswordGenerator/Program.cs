namespace PasswordGenerator;
class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            ShowInstructionsAndQuit();
        }
        string first_arg = args[0];
        string second_arg = args[1];
        Console.WriteLine($"{first_arg} {second_arg}");
    }

    private static void ShowInstructionsAndQuit()
    {
        Console.WriteLine("FEIL: Mangler argumenter");
        Console.WriteLine("Første argument er lengden på passord:");
        Console.WriteLine("  <N>");
        Console.WriteLine("Andre argument skal inneholde en eller flere bokstaver:");
        Console.WriteLine("  l = liten bokstav");
        Console.WriteLine("  L = stor bokstav");
        Console.WriteLine("  d = siffer");
        Console.WriteLine("  s = spesialtegn (!\"#¤%&/(){}[]");
        Console.WriteLine("Eksempel:");
        Console.WriteLine("  <command> 14 lLssdd");
        Environment.Exit(1);
    }
}
