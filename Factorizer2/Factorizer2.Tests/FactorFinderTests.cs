using Factorizer2.BLL;
using NUnit.Framework;

namespace Factorizer2.Tests
{
    [TestFixture]
    public class FactorFinderTests
    {
        [TestCase(4, new int[] {1, 2})]
        [TestCase(6, new int[] {1, 2, 3})]
        [TestCase(9, new int[] {1, 3})]
        public void FactorsOfTest(int n, int[] expected)
        {
            int[] actual = FactorFinder.FactorsOf(n);

            Assert.AreEqual(expected, actual);
        }
    }
}