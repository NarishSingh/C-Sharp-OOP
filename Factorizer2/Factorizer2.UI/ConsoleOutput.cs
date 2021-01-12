using System;

namespace Factorizer2.UI
{
    public class ConsoleOutput
    {
        /// <summary>
        /// Welcome banner for UI
        /// </summary>
        public static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to the (new and improved) Factorizer!!!");
            Console.WriteLine("Press ENTER to continue. . .");
            Console.ReadKey();
        }

        public static bool ExitPrompt()
        {
            Console.Write("Press any key to continue (Q to quit program): ");
            string input = Console.ReadLine();
            if (input.Equals("Q") || input.Equals("q"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}