using System;

namespace StudentManagementSystem.UI.View
{
    public class MainMenu
    {
        private const string Bar = "===============================================";

        /// <summary>
        /// Display main menu banner for UI
        /// </summary>
        public void PrintMainMenu()
        {
            Console.Clear();
            Console.WriteLine("Student Management System");
            Console.WriteLine(Bar);
            Console.WriteLine("1. List Students");
            Console.WriteLine("2. Add Student");
            Console.WriteLine("3. Remove Student");
            Console.WriteLine("4. Edit Student");
            Console.WriteLine("\nQ - Quit");
            Console.WriteLine(Bar);
        }

        /// <summary>
        /// Get menu choice from user
        /// </summary>
        /// <returns>int corresponding to user action</returns>
        public int GetMenuChoice()
        {
            while (true)
            {
                Console.Write("Enter choice: ");
                string input = Console.ReadLine();
                int output;

                if (input.Equals("Q") || input.Equals("q"))
                {
                    return 0; //TODO remember this for later in controller
                }
                else if (int.TryParse(input, out output) && output <= 4 && output >= 1)
                {
                    return output;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please choose again");
                }
            }
        }
    }
}