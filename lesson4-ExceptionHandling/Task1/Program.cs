using System;
using System.IO;

namespace Task1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string input = null;
            do
            {
                Console.WriteLine("To finish the program, please, input STOP, to proceed - any other");
                Console.WriteLine("Please, input your string:");


                try
                {
                    input = Console.ReadLine();
                    Console.WriteLine(input[0]);
                }
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine(e);
                }
                catch (NullReferenceException e)
                {
                    Console.WriteLine(e);
                }
                catch (IOException e)
                {
                    Console.WriteLine(e);
                }
                catch (OutOfMemoryException e)
                {
                    Console.WriteLine(e);
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine(e);
                }

            } while (input != null && !input.Equals("STOP"));

        }
    }
}