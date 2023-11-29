using System;
using System.Collections.Generic;
using System.Text;

namespace FootballBetting12
{
    class TwelveMatches
    {
        private Match[] _matches;

        public TwelveMatches(string betsText)
        {
            var bets = betsText.Split(',');
            _matches = new Match[12];
            for (var i = 0; i < 12; i++)
            {
                _matches[i] = new Match(bets[i]);
            }
        }

        public void AddGoal(int matchNo, bool isHomeTeam)
        {
            var selectedIndex = matchNo - 1;
            var selectedMatch = _matches[selectedIndex];
            selectedMatch.AddGoal(isHomeTeam);
        }

        public void ShowAllScores()
        {
            for (var index = 0; index < _matches.Length; index++)
            {
                var match = _matches[index];
                var matchNo = index + 1;
                var isBetCorrect = match.IsBetCorrect();
                var isBetCorrectText = isBetCorrect ? "riktig" : "feil";
                Console.WriteLine($"Kamp {matchNo}: {match.GetScore()} - {isBetCorrectText}");
            }
        }

        public void ShowCorrectCount()
        {
            var correctCount = 0;
            foreach (var match in _matches)
            {
                if (match.IsBetCorrect()) correctCount++;
            }
            Console.WriteLine($"Du har {correctCount} rette.");
        }
    }
}
