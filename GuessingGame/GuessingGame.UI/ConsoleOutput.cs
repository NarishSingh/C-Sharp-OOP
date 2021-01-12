/*
 * View - output
 */
using System;
using GuessingGame.BLL;

namespace GuessingGame.UI
{
    public class ConsoleOutput
    {
        /// <summary>
        /// Display user greeting
        /// </summary>
        public static void DisplayTitle()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Guessing Game!");
            Console.WriteLine("Press any key to begin. . .");
            Console.ReadKey();
        }
        
        /// <summary>
        /// Display the corresponding message for the user's guess
        /// </summary>
        /// <param name="result">the GuessResult for the guess</param>
        public static void DisplayGuessResult(GuessResult result){
            switch (result)
            {
                case GuessResult.Invalid:
                    DisplayInvalid();
                    break;
                case GuessResult.Higher:
                    DisplayHigher();
                    break;
                case GuessResult.Lower:
                    DisplayLower();
                    break;
                case  GuessResult.Win:
                    DisplayVictory();
                    break;
            }
        }
        
        /*private methods*/
        /// <summary>
        /// Display win message
        /// </summary>
        private static void DisplayVictory()
        {
            Console.WriteLine("You got it!");
            Console.WriteLine("Press ENTER to continue. . .");
            Console.ReadKey();
        }

        /// <summary>
        /// Display fail message for a higher guess
        /// </summary>
        private static void DisplayLower()
        {
            Console.WriteLine("Too high!");
            Console.WriteLine("Press ENTER to continue. . .");
            Console.ReadKey();
        }

        /// <summary>
        /// Display fail message for a lower guess
        /// </summary>
        private static void DisplayHigher()
        {
            Console.WriteLine("Too low!");
            Console.WriteLine("Press ENTER to continue. . .");
            Console.ReadKey();
        }

        /// <summary>
        /// Display fail message for an invalid guess
        /// </summary>
        private static void DisplayInvalid()
        {
            Console.WriteLine("Invalid guess. Enter an integer value between 1-20");
            Console.WriteLine("Press ENTER to continue. . .");
            Console.ReadKey();
        }
    }
}