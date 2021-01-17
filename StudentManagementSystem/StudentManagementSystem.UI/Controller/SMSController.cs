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

        /**
         * App's run loop
         */
        public void Run()
        {
            bool running = true;
            int menuSelection = 0;

            //TODO implement exceptions
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

        private void RemoveStudent()
        {
            throw new System.NotImplementedException();
        }

        private void EditStudent()
        {
            throw new System.NotImplementedException();
        }

        private void ExitMsg()
        {
            view.DisplayExitMsg();
        }
    }
}