using System;
using System.Collections.Generic;
using DvdLibrary.BLL.DTO;

namespace DvdLibrary.UI.View
{
    public class DvdLibraryView
    {
        public static string Bar = "=========================================================================";
        public static string RecordFormat = "{0, -20} {1, 10} {2, -20} {3, -20} {4, 5} {5, 5}";
        public static string IndexedFormat = "{0, -2} {1, -20} {2, 10} {3, -20} {4, -20} {5, 5} {6, 5}";
        
        /*Main Menu*/
        /// <summary>
        /// Display main menu banner for UI
        /// </summary>
        public void PrintMainMenu()
        {
            Console.Clear();
            Console.WriteLine("DVD Library");
            Console.WriteLine(Bar);
            Console.WriteLine("1. View Library");
            Console.WriteLine("2. Add DVD");
            Console.WriteLine("3. Remove DVD");
            Console.WriteLine("4. Edit DVD");
            Console.WriteLine("5. Search Library");
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
        
        /*View Library*/
        /// <summary>
        /// Display opening library banner for UI
        /// </summary>
        public void DisplayLibraryBanner()
        {
            Console.WriteLine("Library");
            Console.WriteLine(Bar);
        }
        
        /*Add DVD*/
        /// <summary>
        /// Display opening add dvd banner for UI
        /// </summary>
        public void DisplayAddBanner()
        {
            Console.WriteLine("Add DVD to Library");
            Console.WriteLine(Bar);
        }

        /// <summary>
        /// Create a new DVD obj for addition to library
        /// </summary>
        /// <returns>Partially formed DVD obj request</returns>
        public DVD newDvd()
        {
            string title = GetRequiredString("Title: ");
            DateTime release = GetRequiredDate("Release Date [MM-dd-yyyy]: ");
            string dir = GetRequiredString("Director: ");
            string studio = GetRequiredString("Studio: ");
            string mpaa = GetRequiredString("Age Rating (US/Int'l allowed: ");
            string userRate = GetRequiredString("User Rating /10: ");

            return new DVD
            {
                Title = title,
                ReleaseDate = release,
                Director = dir,
                Studio = studio,
                MpaaRating = mpaa,
                UserRating = userRate
            };
        }

        /*EXIT MESSAGE*/
        /// <summary>
        /// Exit banner for app quit
        /// </summary>
        public void DisplayExitMsg()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("***Thank you for using DVD Library Manager***");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        
        /*View Error*/
        public void DisplayErrorMsg(string eMsg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(eMsg);
            Console.ForegroundColor = ConsoleColor.Gray;

            ViewConfirm();
        }

        /*HELPERS*/
        /// <summary>
        /// List DVDs to UI
        /// </summary>
        /// <param name="dvds">Valid List of DVDs for display</param>
        public void ListDvds(List<DVD> dvds)
        {
            foreach (DVD d in dvds)
            {
                Console.WriteLine(RecordFormat, d.Title, d.ReleaseDate, d.Director, d.Studio, d.MpaaRating);
            }
            ViewConfirm();
        }
        
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
        /// Read and validate string input
        /// </summary>
        /// <param name="prompt">string specifying input data and format</param>
        /// <returns>the validated string</returns>
        private static string GetRequiredString(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Please enter valid text");
                    Console.WriteLine("Press any key to continue. . .");
                    Console.ReadKey();
                }
                else
                {
                    return input.Trim();
                }
            }
        }
        
        /// <summary>
        /// Read and validate a date from user
        /// </summary>
        /// <param name="prompt">String specifying input data and formats</param>
        /// <returns>DateTime obj</returns>
        private static DateTime GetRequiredDate(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                DateTime output;

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Please enter valid text");
                    Console.WriteLine("Press any key to continue. . .");
                    Console.ReadKey();
                } else if (DateTime.TryParse(input, out output))
                {
                    return output;
                }
                else
                {
                    Console.WriteLine("Please enter a valid date in MM-dd-yyyy formatting");
                    Console.WriteLine("Press any key to continue. . .");
                    Console.ReadKey();
                }
            }
        }
    }
}