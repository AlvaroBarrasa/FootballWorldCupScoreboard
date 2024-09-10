using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using FootballWorldCupScoreboard;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace First_test
{
    [TestClass]
    public class UnitTest1
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
            
            var scoreBoard = new ScoreBoard();
            scoreBoard.StartGame("Mexico", "Canada");

            scoreBoard.UpdateScore("Mexico", "Canada", 1, 2);

            var summary = scoreBoard.GetSummary();
            Assert.AreEqual(1, summary[0].HomeScore);
            Assert.AreEqual(2, summary[0].AwayScore);
        }

        [TestMethod]
        public void GetSummary_ShouldReturnMatchesOrderedByTotalScore()
        {
            
            var scoreBoard = new ScoreBoard();
            scoreBoard.StartGame("Mexico", "Canada");
            scoreBoard.UpdateScore("Mexico", "Canada", 0, 5);

            scoreBoard.StartGame("Spain", "Brazil");
            scoreBoard.UpdateScore("Spain", "Brazil", 10, 2);

            scoreBoard.StartGame("Germany", "France");
            scoreBoard.UpdateScore("Germany", "France", 2, 2);

            var summary = scoreBoard.GetSummary();
            
            Assert.AreEqual("Spain", summary[0].HomeTeam);
            Assert.AreEqual("Germany", summary[2].HomeTeam);
        }
    }

}