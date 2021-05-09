using System;
using System.Linq;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            static string FizzBuzz(int x)
            {
                return (x % 3 == 0, x % 5 == 0) switch
                {
                    (true, true) => "FizzBuzz",
                    (true, _)    => "Fizz",
                    (_, true)    => "Buzz",
                     _           => x.ToString()
                };
            }

            Enumerable.Range(1, 100).Select(FizzBuzz).ToList().ForEach(Console.WriteLine);
        }
    }
}