using Factorizer2.BLL;
using NUnit.Framework;

namespace Factorizer2.Tests
{
    [TestFixture]
    public class PerfectCheckerTests
    {
        [SetUp]
        public void Init()
        {
            
        }

        [TestCase(6, true)]
        [TestCase(28, true)]
        [TestCase(100, false)]
        public void IsPerfectTest(int n, bool expected)
        {
            bool actual = PerfectChecker.IsPerfect(n);
            
            Assert.AreEqual(expected, actual);
        }
    }
}