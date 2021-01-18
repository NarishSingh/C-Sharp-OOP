using System;
using System.Collections.Generic;
using StudentManagementSystem.BLL.DTO;

namespace StudentManagementSystem.UI.View
{
    public class SMSView
    {
        public static string Bar = "===============================================";
        public static string StudentLineFormat = "{0, -20} {1, -20} {2, 5}";
        public static string IndexedLineFormat = "{0, -2} {1, -20} {2, -20} {3, 5}";

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
        /// <summary>
        /// Display opening List banner
        /// </summary>
        public void DisplayListBanner()
        {
            Console.WriteLine("Student List");
            Console.WriteLine(Bar);
        }

        /// <summary>
        /// List students from memory
        /// </summary>
        /// <param name="students">List of students to display</param>
        public void ListAllStudents(List<Student> students)
        {
            DisplayStudentListHeader();
            foreach (Student s in students)
            {
                Console.WriteLine(StudentLineFormat, s.LastName + ", " + s.FirstName, s.Major, s.GPA);
            }

            ViewConfirm();
        }

        /// <summary>
        /// Message for no students to list
        /// </summary>
        public void ListEmpty()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No active students...");
            Console.ForegroundColor = ConsoleColor.Gray;

            ViewConfirm();
        }

        /*ADD STUDENT*/
        /// <summary>
        /// Display opening add student banner
        /// </summary>
        public void DisplayAddStudentBanner()
        {
            Console.WriteLine("Add Student");
            Console.WriteLine(Bar);
        }

        /// <summary>
        /// Validate a new Student obj for add
        /// </summary>
        /// <returns>Well formed Student obj</returns>
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

        /// <summary>
        /// Prompt user to confirm student addition
        /// </summary>
        /// <param name="s">Student to confirm</param>
        /// <returns>True to confirm addition, false to discard</returns>
        public bool AddConfirmation(Student s)
        {
            Console.WriteLine();
            DisplayStudentListHeader();
            Console.WriteLine(StudentLineFormat, s.LastName + ", " + s.FirstName, s.Major, s.GPA);
            Console.WriteLine();

            return GetUserConfirmation("Add Student?");
        }

        /// <summary>
        /// Success banner for Student add
        /// </summary>
        public void StudentAddedSuccess()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Student successfully added.");
            Console.ForegroundColor = ConsoleColor.Gray;
            ViewConfirm();
        }

        /// <summary>
        /// Cancellation banner for Student add
        /// </summary>
        public void StudentAddCanceled()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Add canceled");
            Console.ForegroundColor = ConsoleColor.Gray;
            ViewConfirm();
        }

        /*REMOVE STUDENT*/
        /// <summary>
        /// Display opening remove student banner
        /// </summary>
        public void DisplayRemoveStudentBanner()
        {
            Console.WriteLine("Remove Student");
            DisplayOffsetStudentListHeader();
        }

        /// <summary>
        /// Display an indexed list of students
        /// </summary>
        /// <param name="students">list of Students</param>
        public void DisplayIndexedStudentList(List<Student> students)
        {
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine(IndexedLineFormat, i + 1, students[i].LastName + ", " + students[i].FirstName,
                    students[i].Major, students[i].GPA);
            }

            Console.WriteLine();
            Console.WriteLine(Bar + "===");
        }

        /// <summary>
        /// Read and validate a student selection for removal
        /// </summary>
        /// <param name="max">int for the maximum index to choose from</param>
        /// <returns>int for the Student to be removed</returns>
        public int ChooseStudentForRemoval(int max)
        {
            return GetRequiredIndex("Enter number of student to remove: ", max);
        }

        /// <summary>
        /// Confirm removal of student
        /// </summary>
        /// <param name="s">Student to be removed</param>
        /// <returns>True if confirmed, false if cancelled</returns>
        public bool RemoveConfirmation(Student s)
        {
            return GetUserConfirmation($"Remove {s.FirstName} {s.LastName}?");
        }

        /// <summary>
        /// Display success banner for student removal
        /// </summary>
        public void StudentRemovedSuccess()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Student successfully removed.");
            Console.ForegroundColor = ConsoleColor.Gray;
            ViewConfirm();
        }

        /// <summary>
        /// Display cancel banner for student removal
        /// </summary>
        public void StudentRemoveCancelled()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Remove canceled");
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
            Console.WriteLine("***Thank you for using SMS***");
            Console.ForegroundColor = ConsoleColor.Gray;
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
        /// Display header for student info display
        /// </summary>
        private static void DisplayStudentListHeader()
        {
            Console.WriteLine(StudentLineFormat, "Name", "Major", "GPA");
            Console.WriteLine(Bar);
        }

        /// <summary>
        /// Display header for student info display
        /// </summary>
        private static void DisplayOffsetStudentListHeader()
        {
            Console.WriteLine(IndexedLineFormat, "", "Name", "Major", "GPA");
            Console.WriteLine("   " + Bar);
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
                    return input;
                }
            }
        }

        /// <summary>
        /// Read and validate a decimal input
        /// </summary>
        /// <param name="prompt">string specifying input data and format</param>
        /// <returns>validated decimal</returns>
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

        /// <summary>
        /// Read and validate an index number from user
        /// </summary>
        /// <param name="prompt">string specifying input data and format</param>
        /// <param name="maxIdx">int corresponding to the max index of student list</param>
        /// <returns>int corresponding to the student to be selected</returns>
        private static int GetRequiredIndex(string prompt, int maxIdx)
        {
            int output;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (!int.TryParse(input, out output))
                {
                    Console.WriteLine("Please enter a valid index for an active student");
                    Console.WriteLine("Press any key to continue. . .");
                    Console.ReadKey();
                }
                else
                {
                    //validate that GPA is 0.0 - 4.0
                    if (output < 1 || output > maxIdx)
                    {
                        Console.WriteLine("Please choose an existing student");
                        Console.WriteLine("Press any key to continue. . .");
                        Console.ReadKey();
                        continue;
                    }

                    return output;
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
    }
}