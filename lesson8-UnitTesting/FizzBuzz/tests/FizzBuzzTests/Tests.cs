using FizzBuzz;
using NUnit.Framework;
using System;

namespace FizzBuzzTests
{
    public class Tests
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
        public void Calc(int input, string expectedResult)
        {
            var actualResult = FizzBuzzClass.FizzBuzzResult(input);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [TestCase(0)]
        [TestCase(101)]
        public void ThrowArgumentOutOfRangeException(int input)
        {

            Assert.Catch<ArgumentOutOfRangeException>(() => FizzBuzzClass.FizzBuzzResult(input));
        }
    }
}