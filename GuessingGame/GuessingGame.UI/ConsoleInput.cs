/*
 * View - input
 */
using System;

namespace GuessingGame.UI
{
    public class ConsoleInput
    {
        /// <summary>
        /// Read and validate a guess from user
        /// </summary>
        /// <returns>int from 1-20</returns>
        public static int ReadGuess()
        {
            Console.Clear();
            int output;
            string input;

            while (true)
            {
                Console.Write("Enter a number between 1-20: ");
                input = Console.ReadLine();

                if (int.TryParse(input, out output))
                {
                    return output;
                }
                else
                {
                    Console.WriteLine("Invalid number. Press ENTER to continue. . .");
                    Console.ReadKey();
                }
            }
        }
    }
}