using System;

namespace Task2
{
    public class NumberParser : INumberParser
    {
        private const char Minus = '-';
        private const char Plus = '+';
        private const string Numbers = "0123456789";

        public int Parse(string stringValue)
        {
            try
            {
                stringValue = stringValue.Trim();
                if (stringValue == string.Empty)
                    throw new FormatException();

                long result = 0;
                var signlessValue = string.Empty;
                var positive = true;


                if (stringValue.Contains(Minus) || stringValue.Contains(Plus))
                {
                    if (stringValue[0] == Minus) positive = false;
                    signlessValue += stringValue.Remove(0, 1);
                }
                else
                {
                    signlessValue += stringValue;
                }

                foreach (var c in signlessValue)
                {
                    if (!Numbers.Contains(c))
                        throw new FormatException();

                    result *= 10;
                    result += c - '0';
                }

                checked
                {
                    var xx = positive ? result : -result;
                    int i3 = (int)xx;
                    Console.WriteLine(i3);
                }

                return positive ? (int) result : -(int) result;
            }
            catch (NullReferenceException e)
            {
                throw new ArgumentNullException(e.Message, e);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            catch (OverflowException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}