using System;

namespace Factorizer2.UI
{
    public class ConsoleInput
    {
        /// <summary>
        /// Read and validate a positive integer from user
        /// </summary>
        /// <returns>int above 0</returns>
        public static int ReadInt()
        {
            while (true)
            {
                Console.Clear();
                Console.Write("Enter an integer: ");
                string input = Console.ReadLine();

                int output;
                if (int.TryParse(input, out output) && output > 0)
                {
                    return output;
                }
                else
                {
                    Console.WriteLine("Invalid number for factoring");
                    Console.WriteLine("Press ENTER to continue. . .");
                    Console.ReadKey();
                }
            }
        }
    }
}