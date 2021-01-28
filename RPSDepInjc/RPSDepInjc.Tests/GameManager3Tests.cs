using NUnit.Framework;
using RPSDepInjc.BLL;
using RPSDepInjc.BLL.Service;
using RPSDepInjc.Tests.Stubs;

namespace RPSDepInjc.Tests
{
    [TestFixture]
    public class GameManager3Tests
    {
        [Test]
        public void AllTheTests2()
        {
            GameManager3 gm = new GameManager3();
            // method injection
            gm.SetChoiceBehavior(new AlwaysScissors());

            Assert.AreEqual(GameResult.Win, gm.PlayRound(Choice.Rock).Player1Result);
            Assert.AreEqual(GameResult.Loss, gm.PlayRound(Choice.Paper).Player1Result);
            Assert.AreEqual(GameResult.Tie, gm.PlayRound(Choice.Scissors).Player1Result);

            gm.SetChoiceBehavior(new AlwaysPaper());

            Assert.AreEqual(GameResult.Loss, gm.PlayRound(Choice.Rock).Player1Result);
            Assert.AreEqual(GameResult.Tie, gm.PlayRound(Choice.Paper).Player1Result);
            Assert.AreEqual(GameResult.Win, gm.PlayRound(Choice.Scissors).Player1Result);

            gm.SetChoiceBehavior(new AlwaysRock());

            Assert.AreEqual(GameResult.Tie, gm.PlayRound(Choice.Rock).Player1Result);
            Assert.AreEqual(GameResult.Win, gm.PlayRound(Choice.Paper).Player1Result);
            Assert.AreEqual(GameResult.Loss, gm.PlayRound(Choice.Scissors).Player1Result);
        }
    }
}