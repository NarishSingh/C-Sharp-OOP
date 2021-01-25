using System;
using System.Collections.Generic;
using DvdLibrary.BLL.DTO;

namespace DvdLibrary.UI.View
{
    public class DvdLibraryView
    {
        public static string Bar =
            "===========================================================================================";

        public static string RecordFormat = "{0, -20} {1, -10} {2, -20} {3, -20} {4, 5} {5, 5}";
        public static string IndexedFormat = "{0, -2} {1, -20} {2, -10} {3, -20} {4, -20} {5, 5} {6, 5}";

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
            DisplayDvdRecordHeader();
        }

        /// <summary>
        /// Display header for List view
        /// </summary>
        public void DisplayDvdRecordHeader()
        {
            Console.WriteLine();
            Console.WriteLine(RecordFormat, "Title", "Release", "Director", "Studio", "MPAA", "Rate");
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
            string mpaa = GetRequiredString("Age Rating (US/Int'l): ");
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

        /// <summary>
        /// Confirm new DVD record
        /// </summary>
        /// <param name="request">DVD request</param>
        /// <returns>True to confirm, false to cancel</returns>
        public bool ConfirmAdd(DVD request)
        {
            Console.WriteLine();
            DisplayDvdRecordHeader();
            Console.WriteLine(RecordFormat, request.Title, request.ReleaseDate.ToString("MM/dd/yyyy"),
                request.Director, request.Studio, request.MpaaRating, request.UserRating);

            return GetUserConfirmation("Add DVD?");
        }

        /// <summary>
        /// Success banner for DVD add
        /// </summary>
        public void DvdAddedSuccess()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("DVD successfully added.");
            Console.ForegroundColor = ConsoleColor.Gray;
            ViewConfirm();
        }

        /// <summary>
        /// Cancellation banner for DVD add
        /// </summary>
        public void DvdAddCanceled()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Add canceled");
            Console.ForegroundColor = ConsoleColor.Gray;
            ViewConfirm();
        }

        /*REMOVE DVD*/
        /// <summary>
        /// Display opening add dvd banner for UI
        /// </summary>
        public void DisplayRemoveBanner()
        {
            Console.WriteLine("Remove DVD from Library");
            Console.WriteLine(Bar);
        }

        /// <summary>
        /// Select the index for removal from library
        /// </summary>
        /// <param name="min">int for the minimum id to select from</param>
        /// <param name="max">int for the maximum id to select from</param>
        /// <returns>int for the index of DVD to be removed</returns>
        public int SelectForRemoval(int min, int max)
        {
            return GetRequiredIndex("Enter index of DVD to be removed: ", min, max);
        }

        /// <summary>
        /// Confirm deletion of record
        /// </summary>
        /// <param name="d">DVD obj to be deleted or kept</param>
        /// <returns>True on user confirmation, false otherwise</returns>
        public bool RemoveConfirmation(DVD d)
        {
            return GetUserConfirmation($"Remove {d.Title}?");
        }

        /// <summary>
        /// Display closing removal success banner
        /// </summary>
        public void RemoveSuccess()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("DVD successfully removed.");
            Console.ForegroundColor = ConsoleColor.Gray;
            ViewConfirm();
        }

        /// <summary>
        /// Display closing removal failure banner
        /// </summary>
        public void RemoveCanceled()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Delete canceled");
            Console.ForegroundColor = ConsoleColor.Gray;
            ViewConfirm();
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
                Console.WriteLine(RecordFormat, d.Title, d.ReleaseDate.ToString("MM/dd/yyyy"), d.Director, d.Studio,
                    d.MpaaRating, d.UserRating);
            }

            ViewConfirm();
        }

        /// <summary>
        /// List DVDs to UI
        /// </summary>
        /// <param name="dvds">Valid List of DVDs for display</param>
        public void ListIndexedDvds(List<DVD> dvds)
        {
            foreach (DVD d in dvds)
            {
                Console.WriteLine(IndexedFormat, d.Id, d.Title, d.ReleaseDate.ToString("MM/dd/yyyy"), d.Director,
                    d.Studio,
                    d.MpaaRating, d.UserRating);
            }
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
                }
                else if (DateTime.TryParse(input, out output))
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

        /// <summary>
        /// Read and validate user confirmation or cancellation
        /// </summary>
        /// <param name="prompt">string specifying input data and format</param>
        /// <returns>True if confirmed, false to cancel action</returns>
        private bool GetUserConfirmation(string prompt)
        {
            while (true)
            {
                Console.Write(prompt + " [Y/N]: ");
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Please enter Y/N.");
                    Console.WriteLine("Press any key to continue. . .");
                    Console.ReadKey();
                }
                else
                {
                    if (input.Equals("Y") || input.Equals("y"))
                    {
                        return true;
                    }
                    else if (input.Equals("N") || input.Equals("n"))
                    {
                        return false;
                    }
                    else
                    {
                        Console.WriteLine("Please enter Y/N.");
                        Console.WriteLine("Press any key to continue. . .");
                        Console.ReadKey();
                    }
                }
            }
        }

        /// <summary>
        /// Read and validate an index number from user
        /// </summary>
        /// <param name="prompt">string specifying input data and format</param>
        /// <param name="minIdx">int corresponding to the minimum index of DVD list</param>
        /// <param name="maxIdx">int corresponding to the maximum index of DVD list</param>
        /// <returns>int corresponding to the id of the DVD to be selected</returns>
        private static int GetRequiredIndex(string prompt, int minIdx, int maxIdx)
        {
            int output;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (!int.TryParse(input, out output))
                {
                    Console.WriteLine("Please enter a valid index for DVD in library");
                    Console.WriteLine("Press any key to continue. . .");
                    Console.ReadKey();
                }
                else
                {
                    //validate that index is 1-list index maximum
                    if (output < minIdx || output > maxIdx)
                    {
                        Console.WriteLine("Please choose an existing DVD");
                        Console.WriteLine("Press any key to continue. . .");
                        Console.ReadKey();
                        continue;
                    }

                    return output;
                }
            }
        }
    }
}