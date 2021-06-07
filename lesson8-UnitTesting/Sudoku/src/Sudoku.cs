using System;
using System.Collections.Generic;

namespace Sudoku
{
    public class Sudoku
    {
        private static readonly HashSet<int> ValidSet = new HashSet<int>{1, 2, 3, 4, 5, 6, 7, 8, 9};

        public static bool IsValid(int[,] solution)
        {
            if(solution == null)
                throw new ArgumentNullException();
            if(solution.GetLength(0) != solution.GetLength(1))
                throw new ArgumentException();
            
            for (var i = 0; i < solution.GetLength(0); i++)
            {
                var rowSet = new HashSet<int>();
                var columnSet = new HashSet<int>();
                for (var j = 0; j < solution.GetLength(1); j++)
                {
                    rowSet.Add(solution[i, j]);
                    columnSet.Add(solution[j, i]);
                }

                if (!rowSet.IsSupersetOf(ValidSet) || !columnSet.IsSupersetOf(ValidSet))
                    return false;
            }

            return true;
        }
    }
}