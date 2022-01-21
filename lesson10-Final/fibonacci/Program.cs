using System;
using System.Collections.Generic;

namespace fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            var fibonacciNumbers = new List<int>{1, 1};

            while (fibonacciNumbers.Count <= 10)
            {
                var index = ^1;
                var current = fibonacciNumbers[index];
                var previous = fibonacciNumbers[^2];

                fibonacciNumbers.Add(current + previous);
            }

            fibonacciNumbers.ForEach(Console.WriteLine);
            Console.Read();
        }
    }
}
