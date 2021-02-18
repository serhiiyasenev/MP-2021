using StandardTask2;
using System;
using System.Linq;

namespace ConsoleApp_Task1_Core
{
    class Program
    {
        static void Main(string[] args)
        {
            var name = args.Any() ? args[0] : "Empty Name";
            var greetings = Utilities.EnrichString(name);
            Console.WriteLine(greetings);
            //Console.ReadKey();
        }
    }
}
