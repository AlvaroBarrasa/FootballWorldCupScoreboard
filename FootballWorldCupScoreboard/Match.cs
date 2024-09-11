namespace FootballWorldCupScoreboard
{
    public class Match
    {
        public string HomeTeam { get; private set; }
        public string AwayTeam { get; private set; }
        public int HomeScore { get; private set; }
        public int AwayScore { get; private set; }
        public DateTime StartTime { get; private set; }

        public Match(string homeTeam, string awayTeam)
        {
            if (string.IsNullOrWhiteSpace(homeTeam) || string.IsNullOrWhiteSpace(awayTeam))
                throw new ArgumentException("Teams must have valid names.");

            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
            HomeScore = 0;
            AwayScore = 0;
            StartTime = DateTime.Now;
        }

        public void UpdateScore(int homeScore, int awayScore)
        {
            if (homeScore < 0 || awayScore < 0)
                throw new ArgumentException("Scores cannot be negative.");

            HomeScore = homeScore;
            AwayScore = awayScore;
        }

        public int TotalScore => HomeScore + AwayScore;

        public string MatchResult
        {
            get
            {
                return $"{HomeTeam} {HomeScore} - {AwayTeam} {AwayScore}";
            }
        }
    }

}
