using System;
using NUnit.Framework;
using Calculator.BLL;

namespace Calculator.Tests
{
    [TestFixture]
    public class SimpleMathTests
    {
        private SimpleMath math;
        
        [SetUp]
        public void Init()
        {
            math = new SimpleMath();
        }

        [TearDown]
        public void Cleanup()
        {
            
        }
        
        [Test]
        public void IntDivision()
        {
            // SimpleMath math = new SimpleMath();
            int div = math.Divide(5, 2);

            Assert.AreEqual(2, div);
        }

        [TestCase(4, 2, 2)]
        [TestCase(13, 6, 2)]
        [TestCase(-20, 5, -4)]
        public void IntDivisionCases(int x, int y, int expected)
        {
            // SimpleMath math = new SimpleMath();
            int actual = math.Divide(x, y);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DivideByZeroTest()
        {
            // SimpleMath math = new SimpleMath();
            Assert.Throws<DivideByZeroException>(() => math.Divide(5, 0));
        }
    }
}