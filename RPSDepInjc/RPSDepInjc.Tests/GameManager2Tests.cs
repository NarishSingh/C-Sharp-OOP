using NUnit.Framework;
using RPSDepInjc.BLL;
using RPSDepInjc.BLL.Service;
using RPSDepInjc.Tests.Stubs;

namespace RPSDepInjc.Tests
{
    [TestFixture]
    public class GameManager2Tests
    {
        [Test]
        public void AllTheTests()
        {
            GameManager2 gm = new GameManager2();
            // property injection
            gm.Chooser = new AlwaysScissors();

            Assert.AreEqual(GameResult.Win, gm.PlayRound(Choice.Rock).Player1Result);
            Assert.AreEqual(GameResult.Loss, gm.PlayRound(Choice.Paper).Player1Result);
            Assert.AreEqual(GameResult.Tie, gm.PlayRound(Choice.Scissors).Player1Result);

            gm.Chooser = new AlwaysPaper();

            Assert.AreEqual(GameResult.Loss, gm.PlayRound(Choice.Rock).Player1Result);
            Assert.AreEqual(GameResult.Tie, gm.PlayRound(Choice.Paper).Player1Result);
            Assert.AreEqual(GameResult.Win, gm.PlayRound(Choice.Scissors).Player1Result);

            gm.Chooser = new AlwaysRock();

            Assert.AreEqual(GameResult.Tie, gm.PlayRound(Choice.Rock).Player1Result);
            Assert.AreEqual(GameResult.Win, gm.PlayRound(Choice.Paper).Player1Result);
            Assert.AreEqual(GameResult.Loss, gm.PlayRound(Choice.Scissors).Player1Result);
        }
    }
}