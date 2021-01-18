using System;
using System.Collections.Generic;
using StudentManagementSystem.BLL.DAO;
using StudentManagementSystem.BLL.DTO;
using StudentManagementSystem.UI.View;

namespace StudentManagementSystem.UI.Controller
{
    public class SMSController
    {
        private StudentRepository dao;
        private SMSView view;

        public SMSController(StudentRepository dao, SMSView view)
        {
            this.dao = dao;
            this.view = view;
        }

        /// <summary>
        /// App's run loop
        /// </summary>
        public void Run()
        {
            bool running = true;
            int menuSelection;
            
            while (running)
            {
                Console.Clear();
                view.PrintMainMenu();
                menuSelection = GetMenuSelection();

                switch (menuSelection)
                {
                    case 1:
                        ListAll();
                        break;
                    case 2:
                        AddStudent();
                        break;
                    case 3:
                        RemoveStudent();
                        break;
                    case 4:
                        EditStudent();
                        break;
                    case 0:
                        running = false;
                        break;
                }
            }

            ExitMsg();
        }

        /// <summary>
        /// Get user menu selection
        /// </summary>
        /// <returns>int 0-4</returns>
        private int GetMenuSelection()
        {
            return view.GetMenuChoice();
        }

        /// <summary>
        /// Print all active students
        /// </summary>
        private void ListAll()
        {
            Console.Clear();
            view.DisplayListBanner();

            List<Student> students = dao.ReadAllStudents();
            if (students.Count == 0)
            {
                view.ListEmpty();
            }
            else
            {
                view.ListAllStudents(students);
            }
        }

        /// <summary>
        /// Create a new student and persist to file if confirmed
        /// </summary>
        private void AddStudent()
        {
            Console.Clear();
            view.DisplayAddStudentBanner();

            Student newStudent = view.NewStudent();
            if (view.AddConfirmation(newStudent))
            {
                dao.CreateStudent(newStudent);
                view.StudentAddedSuccess();
            }
            else
            {
                view.StudentAddCanceled();
            }
        }

        /// <summary>
        /// Remove a student and persist changes if confirmed
        /// </summary>
        private void RemoveStudent()
        {
            Console.Clear();
            view.DisplayRemoveStudentBanner();

            List<Student> students = dao.ReadAllStudents();
            view.DisplayIndexedStudentList(students);
            int i = view.ChooseStudentForRemoval(students.Count);
            i--; //dao will index from 0 not 1

            if (view.RemoveConfirmation(students[i]))
            {
                dao.DeleteStudent(i);
                view.StudentRemovedSuccess();
            }
            else
            {
                view.StudentRemoveCancelled();
            }
        }

        /// <summary>
        /// Edit a student and persist changes if confirmed
        /// </summary>
        private void EditStudent()
        {
            Console.Clear();
            view.DisplayEditStudentBanner();

            List<Student> students = dao.ReadAllStudents();
            view.DisplayIndexedStudentList(students);
            int i = view.ChooseStudentForUpdate(students.Count);
            i--;

            Student edit = view.EditStudent(students[i]);
            if (view.EditConfirmation(edit))
            {
                dao.UpdateStudent(edit, i);
                view.EditStudentSuccess();
            }
            else
            {
                view.EditStudentCanceled();
            }
        }

        /// <summary>
        /// Display exit banner for app
        /// </summary>
        private void ExitMsg()
        {
            view.DisplayExitMsg();
        }
    }
}