using System;

namespace FootballBetting12
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Gyldig tips: \r\n - H, U, B\r\n - halvgardering: HU, HB, UB\r\n - helgardering: HUB\r\nSkriv inn dine 12 tips med komma mellom: ");
            var betsText = Console.ReadLine();
            var matches = new TwelveMatches(betsText);
            while (true)
            {
                Console.Write("Skriv kampnr. 1-12 for scoring eller X for alle kampene er ferdige\r\nAngi kommando: ");
                var command = Console.ReadLine();
                if (command == "X") break;
                var matchNo = Convert.ToInt32(command);
                Console.Write($"Scoring i kamp {matchNo}. \r\nSkriv H for hjemmelag eller B for bortelag: ");
                var team = Console.ReadLine();
                matches.AddGoal(matchNo, team == "H");
                matches.ShowAllScores();
                matches.ShowCorrectCount();
            }
        }
    }
}
