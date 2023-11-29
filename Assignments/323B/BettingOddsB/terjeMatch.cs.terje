using System;
using System.Collections.Generic;
using System.Text;

namespace FootballBetting12
{
    class Match
    {
        private int _homeGoals;
        private int _awayGoals;
        private readonly string _bet;
        public bool IsRunning { get; private set; }

        public Match(string bet)
        {
            _bet = bet;
            IsRunning = true;
        }

        public void AddGoal(bool isHomeTeam)
        {
            if (isHomeTeam) _homeGoals++;
            else _awayGoals++;
        }

        public bool IsBetCorrect()
        {
            var result = _homeGoals == _awayGoals ? "U" : _homeGoals > _awayGoals ? "H" : "B";
            return _bet.Contains(result);
        }

        public void Stop()
        {
            IsRunning = false;
        }

        public string GetScore()
        {
            return _homeGoals + "-" + _awayGoals;
        }
    }
}
