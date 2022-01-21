using System;

namespace Math
{
    class Program
    {
        static int SumOfDigits(int i)
        {
            //num = 125
            var h = (i - i % 100) / 100; //hundreds: h = (125 - 125%100)/100 = (125-25)/100 = 1
            var d = (i % 100 - i % 10) / 10; //dozens: d =(125%100 - 125%10)/10 = (25-125%10)/10 = (25-5)/10 = 2
            var e = i % 10; //Last digit: e = 125%10 = 5
            var sum = h + d + e; //sum = 1+2+5 = 8
            return sum;
        }

        static void NumberDivisibleWithoutRemainder(int divider = 15)
        {
            Console.WriteLine("===============NumberDivisibleWithoutRemainder===============");
            for (var i = 0; i < 100; i++)
            {
                var result = SumOfDigits(i) % divider;

                if (result == 0 && i > 0) Console.WriteLine($"The sum of the digits of the number '{i}' is divisible by '{divider}' without a remainder");
            }
            Console.WriteLine("===============NumberDivisibleWithoutRemainder===============");
        }


        static void Main(string[] args)
        {
            NumberDivisibleWithoutRemainder(7);
            Console.WriteLine();
            MultiplyMatrix();
            Console.ReadLine();
        }

        static void MultiplyMatrix()
        {
            int[,] a = {
                { 5 , 10, 13, -4, 10 },
                { 20, 2 , 9 , 9 , -1 },
                { 5 , 10, 4 , 8 , 14 },
                { 6 , 1 , 2 , 6 , 10 },
                { 95, 5 , 10, 10, 2  }
            };

            int[,] b = {
                { 5 , 10, 8, -4, 62 },
                { 20, 2 , 9, 9 , -1 },
                { 5 , 10, 1, 8 , 1  },
                { 6 , 1 , 2, 6 , -5 },
                { 95, 5 , 1, 3 , 2  }
            };

            var c = new int[5, 5];

            for (var i = 0; i < 5; i++)
            {
                for (var j = 0; j < 5; j++)
                {
                    c[i, j] = 0;
                    for (var k = 0; k < 5; k++)
                    {
                        c[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            Console.WriteLine("===============MultiplyMatrix===============");
            for (var i = 0; i < 5; i++)
            {
                for (var j = 0; j < 5; j++)
                {
                    var result = c[i, j].ToString();
                    result = "|" + result + new string(' ', 4 - result.Length) + "|";
                    Console.Write(result);
                }
                Console.WriteLine();
            }
            Console.WriteLine("===============MultiplyMatrix===============");
        }
    }
}
