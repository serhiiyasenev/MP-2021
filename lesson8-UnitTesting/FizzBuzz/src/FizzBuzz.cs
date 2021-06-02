using System;

namespace FizzBuzz
{
    public class FizzBuzzClass
    {
        public static string FizzBuzzResult(int x)
        {
            if (x < 1 || x > 100)
            {
                throw new ArgumentOutOfRangeException(x.ToString());
            }

            return (x % 3 == 0, x % 5 == 0) switch
            {
                (true, true) => "FizzBuzz",
                (true, _) => "Fizz",
                (_, true) => "Buzz",
                _ => x.ToString()
            };
        }
    }
}