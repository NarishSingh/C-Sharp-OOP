using System;

namespace Ex2FixxBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 101; i++)
            {
                Console.Write($"{i}");

                if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.Write(" fizzbuzz");
                }
                else if (i % 3 == 0)
                {
                    Console.Write(" fizz");
                }
                else if (i % 5 == 0)
                {
                    Console.Write(" buzz");
                }

                Console.WriteLine();
            }
        }
    }
}