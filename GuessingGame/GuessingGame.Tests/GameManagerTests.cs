using NUnit.Framework;
using GuessingGame.BLL;

namespace GuessingGame.Tests
{
    [TestFixture]
    public class GameManagerTests
    {
        private GameManager game;
        
        [SetUp]
        public void Setup()
        {
            game = new GameManager();
        }

        [Test]
        public void InvalidGuess()
        {
            game.Start();

            GuessResult actual = game.ProcessGuess(152);
            
            Assert.AreEqual(GuessResult.Invalid, actual);
        }

        [Test]
        public void HigherGuess()
        {
            game.Start(10);

            GuessResult actual = game.ProcessGuess(8);
            
            Assert.AreEqual(GuessResult.Higher, actual);
        }

        [Test]
        public void LowerGuess()
        {
            game.Start(10);

            GuessResult actual = game.ProcessGuess(12);
            
            Assert.AreEqual(GuessResult.Lower, actual);
        }

        [Test]
        public void WinningGuess()
        {
            game.Start(10);

            GuessResult actual = game.ProcessGuess(10);
            
            Assert.AreEqual(GuessResult.Win, actual);
        }
    }
}