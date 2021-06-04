using NUnit.Framework;
using System;

namespace BinaryGap.Tests
{
    [TestFixture]
    public class BinaryGapUnitTest
    {
        [Test]
        [TestCase(9, 2)]
        [TestCase(529, 4)]
        [TestCase(15, 0)]
        [TestCase(1041, 5)]
        [TestCase(int.MaxValue - 1, 0)]
        [TestCase(int.MaxValue, 0)]
        public void TestOnPositiveNumbers(int n, int expectedBinaryGap)
        {
            Assert.AreEqual(expectedBinaryGap, BinarySolver.Solve(n));
        }

        [Test]
        [TestCase(int.MinValue)]
        [TestCase(0)]
        [TestCase(-1)]
        public void NegativeOrZeroNumbersTest(int n)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => BinarySolver.Solve(n));
        }
    }
}