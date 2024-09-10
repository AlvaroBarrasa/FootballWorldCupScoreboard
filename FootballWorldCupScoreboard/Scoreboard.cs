using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballWorldCupScoreboard
{
    public class ScoreBoard
    {
        private List<Match> _matches;

        public ScoreBoard()
        {
            _matches = new List<Match>();
        }

        public void StartGame(string homeTeam, string awayTeam)
        {
            var match = new Match(homeTeam, awayTeam);
            _matches.Add(match);
        }

        public void FinishGame(string homeTeam, string awayTeam)
        {
            var match = _matches.FirstOrDefault(m => m.HomeTeam == homeTeam && m.AwayTeam == awayTeam);
            if (match != null)
            {
                _matches.Remove(match);
            }
        }

        public void UpdateScore(string homeTeam, string awayTeam, int homeScore, int awayScore)
        {
            var match = _matches.FirstOrDefault(m => m.HomeTeam == homeTeam && m.AwayTeam == awayTeam);
            if (match != null)
            {
                match.UpdateScore(homeScore, awayScore);
            }
        }

        public List<Match> GetSummary()
        {
            return _matches
                .OrderByDescending(m => m.TotalScore)
                .ThenByDescending(m => m.StartTime)
                .ToList();
        }
    }
}