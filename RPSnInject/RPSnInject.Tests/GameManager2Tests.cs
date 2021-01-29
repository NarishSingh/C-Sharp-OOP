using Ninject;
using NUnit.Framework;
using RPSnInject.BLL.DTO;
using RPSnInject.BLL.Service;
using RPSnInject.Tests.Stubs;

namespace RPSnInject.Tests
{
    [TestFixture]
    public class GameManager2Tests
    {
        [Test]
        public void PaperPropertyInjTests()
        {
            //get the binding from the kernel we set up in the module
            var kernel = new StandardKernel();
            kernel.Load(new AlwaysPaperModule());

            var gm = kernel.Get<GameManager2>();

            Assert.AreEqual(GameResult.Loss, gm.PlayRound(Choice.Rock).Player1Result);
            Assert.AreEqual(GameResult.Tie, gm.PlayRound(Choice.Paper).Player1Result);
            Assert.AreEqual(GameResult.Win, gm.PlayRound(Choice.Scissors).Player1Result);
        }
    }
}