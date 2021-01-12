using Factorizer2.BLL;
using NUnit.Framework;

namespace Factorizer2.Tests
{
    [TestFixture]
    public class PrimeCheckerTests
    {
        [SetUp]
        public void Init()
        {
            
        }

        [TestCase(7, true)]
        [TestCase(9, false)]
        [TestCase(11, true)]
        public void IsPrimeTest(int n, bool expected)
        {
            bool actual = PrimeChecker.IsPrime(n);
            
            Assert.AreEqual(expected, actual);
        }
    }
}