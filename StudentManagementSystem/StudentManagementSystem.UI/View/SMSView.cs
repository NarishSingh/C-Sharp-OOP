using System;
using System.Collections.Generic;
using StudentManagementSystem.BLL.DTO;

namespace StudentManagementSystem.UI.View
{
    public class SMSView
    {
        public static string Bar = "===============================================";
        public static string StudentLineFormat = "{0, -20} {1, -20} {2, 5}";

        /*MAIN MENU*/
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
                    return 0;
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

        /*LIST STUDENTS*/
        public void DisplayListBanner()
        {
            Console.WriteLine("Student List");
            Console.WriteLine(Bar);
        }

        public void ListAllStudents(List<Student> students)
        {
            DisplayStudentListHeader();
            foreach (Student s in students)
            {
                Console.WriteLine(StudentLineFormat, s.LastName + ", " + s.FirstName, s.Major, s.GPA);
            }

            ViewConfirm();
        }

        public void ListEmpty()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No active students...");
            Console.ForegroundColor = ConsoleColor.Gray;

            ViewConfirm();
        }

        /*ADD STUDENT*/
        public void DisplayAddStudentBanner()
        {
            Console.WriteLine("Add Student");
            Console.WriteLine(Bar);
        }

        public Student NewStudent()
        {
            Console.Clear();
            Console.WriteLine("Add New Student");
            Console.WriteLine(Bar);
            Console.WriteLine();

            string firstName = GetRequiredString("First Name: ");
            string lastName = GetRequiredString("Last Name: ");
            string major = GetRequiredString("Major: ");
            decimal gpa = GetRequiredDecimal("GPA: ");

            return new Student
            {
                FirstName = firstName,
                LastName = lastName,
                Major = major,
                GPA = gpa
            };
        }

        public bool AddConfirmation(Student s)
        {
            DisplayStudentListHeader();
            Console.WriteLine();
            Console.WriteLine(StudentLineFormat, s.LastName + ", " + s.FirstName, s.Major, s.GPA);

            return GetUserConfirmation("Add Student?");
        }

        public void StudentAddedSuccess()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Student successfully added.");
            Console.ForegroundColor = ConsoleColor.Gray;
            ViewConfirm();
        }

        public void StudentAddCanceled()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Add canceled");
            Console.ForegroundColor = ConsoleColor.Gray;
            ViewConfirm();
        }
        
        /*EXIT MESSAGE*/
        public void DisplayExitMsg()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("***Thank you for using SMS***");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /*HELPERS*/
        private static void ViewConfirm()
        {
            Console.WriteLine();
            Console.WriteLine(Bar);
            Console.WriteLine();
            Console.WriteLine("Press any key to continue. . .");
            Console.ReadKey();
        }

        private static void DisplayStudentListHeader()
        {
            Console.WriteLine(StudentLineFormat, "Name", "Major", "GPA");
            Console.WriteLine(Bar);
        }

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
                    return input;
                }
            }
        }

        private static decimal GetRequiredDecimal(string prompt)
        {
            decimal output;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (!decimal.TryParse(input, out output))
                {
                    Console.WriteLine("Please enter a valid GPA");
                    Console.WriteLine("Press any key to continue. . .");
                    Console.ReadKey();
                }
                else
                {
                    //validate that GPA is 0.0 - 4.0
                    if (output < 0 || output > 4)
                    {
                        Console.WriteLine("GPA must be between 0.0 and 4.0.");
                        Console.WriteLine("Press any key to continue. . .");
                        Console.ReadKey();
                        continue;
                    }

                    return output;
                }
            }
        }

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
    }
}