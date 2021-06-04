using NUnit.Framework;
using System;

namespace FizzBuzz.Core.Tests
{
    [TestFixture]
    public class FizzBuzzTests
    {
        [Test]
        [TestCase(1, "1")]
        [TestCase(3, "Fizz")]
        [TestCase(4, "4")]
        [TestCase(5, "Buzz")]
        [TestCase(15, "FizzBuzz")]
        [TestCase(90, "FizzBuzz")]
        [TestCase(95, "Buzz")]
        [TestCase(99, "Fizz")]
        [TestCase(100, "Buzz")]
        public void Generate_ShouldReturnExpected_ForNumberWithinRange(int input, string expectedResult)
        {
            var actualResult = FizzBuzz.Generate(input);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [TestCase(0)]
        [TestCase(101)]
        public void Generate_ThrowsArgumentOutOfRangeException_ForNumberOutsideRange(int input)
        {
            Assert.Catch<ArgumentOutOfRangeException>(() => FizzBuzz.Generate(input));
        }
    }
}