using System.Linq;

namespace FizzBuzz.Console
{
    class Program
    {
        static void Main()
        {
            Enumerable.Range(1, 100).Select(Core.FizzBuzz.Generate).ToList().ForEach(System.Console.WriteLine);
        }
    }
}
