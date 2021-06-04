using NUnit.Framework;
using System;

namespace Sudoku.Tests
{
    [TestFixture]
    public class SudokuTests
    {
        private readonly int[,] _validSolution = 
        {
            {5,3,4,6,7,8,9,1,2},
            {6,7,2,1,9,5,3,4,8},
            {1,9,8,3,4,2,5,6,7},
            {8,5,9,7,6,1,4,2,3},
            {4,2,6,8,5,3,7,9,1},
            {7,1,3,9,2,4,8,5,6},
            {9,6,1,5,3,7,2,8,4},
            {2,8,7,4,1,9,6,3,5},
            {3,4,5,2,8,6,1,7,9}
        };

        [Test]
        public void FunctionReturnTrueOnValidSolution()
        {
            var isValid = Sudoku.IsValid(_validSolution);
            Assert.True(isValid);
        }

        [Test]
        public void FailOnZeroInSolution()
        {
            var solutionWithZero =  _validSolution;
            solutionWithZero[0, 0] = 0;
            Assert.False(Sudoku.IsValid(solutionWithZero));
        }
        
        [Test]
        public void ThrowExceptionIfArgumentIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => Sudoku.IsValid(null));
        }

        [Test]
        public void ReturnFalseOnInvalidSolution()
        {
            var invalidSolution = _validSolution;
            invalidSolution[1, 1] = _validSolution[2, 2];
            invalidSolution[2, 2] = _validSolution[1, 1];
            Assert.False(Sudoku.IsValid(invalidSolution));
        }
        
        [Test]
        public void ThrowsArgumentExceptionIfArrayIsNotSquare()
        {
            var invalidSolution = new int[2,3];
            Assert.Throws<ArgumentException>(() => Sudoku.IsValid(invalidSolution));
        }
    }
}