using System;

namespace ConsoleApp10
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------START---------");
            Console.WriteLine();

            var words = new[] {"true", "kazak", "potop", "radar", "zakaz", "madam", "nurses run", "Palindrome", "TESTS", "false"};

            foreach (var word in words)
            {
                Console.WriteLine($"Is Palindrome '{word}': {IsPalindrome(word)}");
            }

            Console.Read();
        }

        static bool IsPalindrome(string inputString)
        {
            var str = inputString.Replace(" ", string.Empty);

            var firstPart = str.Substring(0, str.Length / 2);
            char[] arrChars = str.ToCharArray();
            
            //Array.Reverse(arrChars);

            for (int i = 0; i < arrChars.Length / 2; i++)
            {
                var temp = arrChars[i];
                arrChars[i] = arrChars[arrChars.Length - i - 1];
                arrChars[arrChars.Length - i - 1] = temp;
            }

            var secondPart = new string(arrChars);
            secondPart = secondPart.Substring(0, secondPart.Length / 2);

            return firstPart.Equals(secondPart);
        }
    }
}
