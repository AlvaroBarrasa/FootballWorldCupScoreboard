using Microsoft.VisualStudio.TestTools.UnitTesting;
using FootballWorldCupScoreBoard; // Reference your library project here
using System;
using FootballWorldCupScoreboard;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace FootballWorldCupScoreBoard.Tests
{
    [TestClass]
    public class ScoreBoardTests
    {
        [TestMethod]
        public void StartGame_ShouldAddMatchToScoreBoard()
        {
            // Arrange
            var scoreBoard = new ScoreBoard();

            // Act
            scoreBoard.StartGame("Mexico", "Canada");

            // Assert
            var summary = scoreBoard.GetSummary();
            Assert.AreEqual(1, summary.Count);
            Assert.AreEqual("Mexico", summary[0].HomeTeam);
            Assert.AreEqual("Canada", summary[0].AwayTeam);
            Assert.AreEqual(0, summary[0].HomeScore);
            Assert.AreEqual(0, summary[0].AwayScore);
        }

        [TestMethod]
        public void FinishGame_ShouldRemoveMatchFromScoreBoard()
        {
            // Arrange
            var scoreBoard = new ScoreBoard();
            scoreBoard.StartGame("Mexico", "Canada");

            // Act
            scoreBoard.FinishGame("Mexico", "Canada");

            // Assert
            var summary = scoreBoard.GetSummary();
            Assert.AreEqual(0, summary.Count);
        }

        [TestMethod]
        public void UpdateScore_ShouldModifyMatchScore()
        {
            // Arrange
            var scoreBoard = new ScoreBoard();
            scoreBoard.StartGame("Mexico", "Canada");

            // Act
            scoreBoard.UpdateScore("Mexico", "Canada", 1, 2);

            // Assert
            var summary = scoreBoard.GetSummary();
            Assert.AreEqual(1, summary[0].HomeScore);
            Assert.AreEqual(2, summary[0].AwayScore);
        }

        [TestMethod]
        public void GetSummary_ShouldReturnMatchesOrderedByTotalScore()
        {
            // Arrange
            var scoreBoard = new ScoreBoard();
            scoreBoard.StartGame("Mexico", "Canada");
            scoreBoard.UpdateScore("Mexico", "Canada", 0, 5);

            scoreBoard.StartGame("Spain", "Brazil");
            scoreBoard.UpdateScore("Spain", "Brazil", 10, 2);

            scoreBoard.StartGame("Germany", "France");
            scoreBoard.UpdateScore("Germany", "France", 2, 2);

            // Act
            var summary = scoreBoard.GetSummary();

            // Assert
            Assert.AreEqual("Spain", summary[0].HomeTeam);
            Assert.AreEqual("Germany", summary[2].HomeTeam);
        }

        [TestMethod]
        public void MatchResult_ShouldReturnCorrectFormat()
        {
            // Arrange
            var match = new Match("Argentina", "Australia");

            // Act
            match.UpdateScore(3, 1);

            // Assert
            Assert.AreEqual("Argentina 3 - Australia 1", match.MatchResult);
        }

        [TestMethod]
        public void PrintSummary_ShouldDisplayMatchesInCorrectOrder()
        {
            // Arrange
            var scoreBoard = new ScoreBoard();

            // Add and update matches
            scoreBoard.StartGame("Mexico", "Canada");
            scoreBoard.UpdateScore("Mexico", "Canada", 0, 5);

            scoreBoard.StartGame("Spain", "Brazil");
            scoreBoard.UpdateScore("Spain", "Brazil", 10, 2);

            scoreBoard.StartGame("Germany", "France");
            scoreBoard.UpdateScore("Germany", "France", 2, 2);

            scoreBoard.StartGame("Uruguay", "Italy");
            scoreBoard.UpdateScore("Uruguay", "Italy", 6, 6);

            scoreBoard.StartGame("Argentina", "Australia");
            scoreBoard.UpdateScore("Argentina", "Australia", 3, 1);

            // Act
            var matches = scoreBoard.GetSummary();

            // Assert: Print summary in required format
            PrintSummary(matches);
        }

        public void PrintSummary(List<Match> matches)
        {
            int i = 1;
            foreach (var match in matches)
            {
                Console.WriteLine($"i. " + match.MatchResult + "\n");
            }

        }
    }
}
