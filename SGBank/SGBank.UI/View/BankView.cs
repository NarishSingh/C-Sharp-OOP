using System;
using System.Text.RegularExpressions;
using SGBank.Models;

namespace SGBank.UI.View
{
    public class BankView
    {
        private const string Bar =
            "===========================================================================================";

        /*MAIN MENU*/
        /// <summary>
        /// Display main menu banner for UI
        /// </summary>
        public void PrintMainMenu()
        {
            Console.Clear();
            Console.WriteLine("SG Bank");
            Console.WriteLine(Bar);
            Console.WriteLine("1. Lookup Account");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("\nQ - Quit");
            Console.WriteLine(Bar);
        }

        /// <summary>
        /// Get menu choice from user
        /// </summary>
        /// <param name="min">int for minimum number select</param>
        /// <param name="max">int for maximum number select</param>
        /// <returns>int corresponding to user action</returns>
        public int GetMenuChoice(int min, int max)
        {
            while (true)
            {
                Console.Write("Enter choice: ");
                string input = Console.ReadLine();
                int output;

                if (input.Equals("Q") || input.Equals("q"))
                {
                    return 0;
                }
                else if (int.TryParse(input, out output) && output <= max && output >= min)
                {
                    return output;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please choose again");
                }
            }
        }

        /*LOOKUP*/
        /// <summary>
        /// Get an account number from user for read
        /// </summary>
        /// <returns>string for a user account</returns>
        public string GetNumForLookup()
        {
            return GetRequiredString("Enter Account Number: ");
        }

        /// <summary>
        /// Display Account details
        /// </summary>
        /// <param name="a">Well formed Account obj</param>
        public void DisplayAcctDetails(Account a)
        {
            Console.WriteLine($"Account Number: {a.AcctNum}");
            Console.WriteLine($"Name: {a.Name}");
            Console.WriteLine($"Account Type: {a.Type}");
            Console.WriteLine($"Balance: ${a.Balance:C}");

            ViewConfirm();
        }

        /*EXIT MESSAGE*/
        /// <summary>
        /// Exit banner for app quit
        /// </summary>
        public void DisplayExitMsg()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("***Thank you for banking with SG***");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /*View Error*/
        /// <summary>
        /// Display error message to UI
        /// </summary>
        /// <param name="eMsg">string from the exception/error message</param>
        public void DisplayErrorMsg(string eMsg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(eMsg);
            Console.ForegroundColor = ConsoleColor.Gray;

            ViewConfirm();
        }

        /*HELPERS*/
        /// <summary>
        /// Display closing banner and prompt for any view
        /// </summary>
        private static void ViewConfirm()
        {
            Console.WriteLine();
            Console.WriteLine(Bar);
            Console.WriteLine();
            Console.WriteLine("Press any key to continue. . .");
            Console.ReadKey();
        }

        /// <summary>
        /// Display opening banners for UI
        /// </summary>
        /// <param name="header">string for banner header</param>
        public void DisplayOpeningBanner(string header)
        {
            Console.WriteLine(header);
            Console.WriteLine(Bar);
        }

        /// <summary>
        /// Read and validate string input
        /// </summary>
        /// <param name="prompt">string specifying input data and format</param>
        /// <returns>the validated string</returns>
        private static string GetRequiredString(string prompt)
        {
            Regex r = new Regex(@"\d{5}");

            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (r.Match(input).Success)
                {
                    return input.Trim();
                }
                else if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Please enter valid text");
                    Console.WriteLine("Press any key to continue. . .");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Please enter valid Account Number");
                    Console.WriteLine("Press any key to continue. . .");
                    Console.ReadKey();
                }
            }
        }
    }
}