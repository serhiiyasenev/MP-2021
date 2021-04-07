using System;

namespace Task1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string input;
            do
            {
                Console.WriteLine("To finish the program, please, input STOP, to proceed - any other");
                Console.WriteLine("Please, input your string:");

                input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input) || string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("String should NOT be null, empty or whitespace!");
                }
                else
                {
                    Console.WriteLine(input[0]);
                }
            } while (input != null && !input.Equals("STOP"));

        }
    }
}