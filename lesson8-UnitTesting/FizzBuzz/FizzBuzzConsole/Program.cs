using System;
using System.Linq;

namespace FizzBuzzConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            static string Generate(int number)
            {
                return (number % 3 == 0, number % 5 == 0) switch
                {
                    (true, true) => "FizzBuzz",
                    (true, _) => "Fizz",
                    (_, true) => "Buzz",
                    _ => number.ToString()
                };
            }

            Enumerable.Range(1, 100).Select(Generate).ToList().ForEach(Console.WriteLine);
        }
    }
}
