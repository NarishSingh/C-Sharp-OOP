using System;

namespace Ex1Factorizer
{
    class Program
    {
        /// <summary>
        /// Prompt the user for an integer.  Make sure they enter a valid integer!
        /// 
        /// See the String Input lesson for TryParse() examples
        /// </summary>
        /// <returns>the user input as an integer</returns>
        static int GetNumberFromUser()
        {
            int output;

            Console.WriteLine("Enter an integer: ");

            while (true)
            {
                string input = Console.ReadLine();

                if (int.TryParse(input, out output))
                {
                    return output;
                }

                Console.WriteLine("Not an integer...");
            }
        }

        static void Main(string[] args)
        {
            int number = GetNumberFromUser();

            Calculator.PrintFactors(number);
            Calculator.IsPerfectNumber(number);
            Calculator.IsPrimeNumber(number);

            Console.WriteLine("Press any key to quit...");
            Console.ReadKey();
        }
    }
}