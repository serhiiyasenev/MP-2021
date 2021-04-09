using System;
using System.Linq;

namespace Task2
{
    public class NumberParser : INumberParser
    {
        private const char Minus = '-';
        private const char Plus = '+';

        public int Parse(string stringValue)
        {
            long result = 0;
            var signlessValue = string.Empty;
            var positive = true;

            try
            {
                stringValue = stringValue.Trim();
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e);
                throw new ArgumentNullException(e.Message, e);
            }

            if (stringValue.Length == 0)
            {
                throw new FormatException("stringValue.Length == 0");
            }

            if (stringValue.Contains(Minus) || stringValue.Contains(Plus))
            {
                if (stringValue[0] == Minus) positive = false;
                signlessValue += stringValue.Remove(0, 1);
            }
            else
            {
                signlessValue += stringValue;
            }

            if (signlessValue.Length == 0 || signlessValue.Any(c => !char.IsNumber(c)))
            {
                throw new FormatException("stringValue doesn't contain any number");
            }

            foreach (var c in signlessValue)
            {
                result *= 10;
                result += c - '0';
            }

            checked
            {
                var test = positive ? result : -result;
                int number = (int)test;
                Console.WriteLine(number);
            }


            return positive ? (int)result : -(int)result;
        }
    }
}