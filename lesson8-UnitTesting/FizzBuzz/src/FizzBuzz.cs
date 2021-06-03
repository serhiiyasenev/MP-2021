using System;

namespace FizzBuzzProj
{
    public class FizzBuzz
    {
        public static string Generate(int number)
        {
            if (number < 1 || number > 100)
            {
                throw new ArgumentOutOfRangeException(number.ToString());
            }

            return (number % 3 == 0, number % 5 == 0) switch
            {
                (true, true) => "FizzBuzz",
                (true, _) => "Fizz",
                (_, true) => "Buzz",
                _ => number.ToString()
            };
        }
    }
}