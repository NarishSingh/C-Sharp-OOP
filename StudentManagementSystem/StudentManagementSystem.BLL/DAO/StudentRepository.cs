using System;
using System.Collections.Generic;
using System.IO;
using StudentManagementSystem.BLL.DTO;

namespace StudentManagementSystem.BLL.DAO
{
    public class StudentRepository
    {
        private string _path;

        public StudentRepository()
        {
            _path = @"C:\Users\naris\Documents\Work\TECHHIRE\REPOSITORY\C-Sharp-OOP\StudentManagementSystem\StudentManagementSystem.UI\bin\Debug\net5.0\AppData\Students.txt";
        }

        public StudentRepository(string path)
        {
            this._path = path;
        }

        /// <summary>
        /// Create a new student in file
        /// </summary>
        /// <param name="s">well formed Student obj</param>
        public void CreateStudent(Student s)
        {
            using (StreamWriter w = new StreamWriter(_path, true))
            {
                w.WriteLine(FormatRecord(s));
            }
        }

        /// <summary>
        /// Read all students from file
        /// </summary>
        /// <returns>List of Student obj's constructed from records in file</returns>
        public List<Student> ReadAllStudents()
        {
            List<Student> students = new List<Student>();

            using (StreamReader sr = new StreamReader(_path))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    string[] cols = line.Split(",");

                    Student s = new Student
                    {
                        FirstName = cols[0],
                        LastName = cols[1],
                        Major = cols[2],
                        GPA = decimal.Parse(cols[3])
                    };

                    students.Add(s);
                }
            }

            return students;
        }

        /// <summary>
        /// Update a student record
        /// </summary>
        /// <param name="s">Updated Student obj</param>
        /// <param name="idx">index of the student update</param>
        public void UpdateStudent(Student s, int idx)
        {
            List<Student> students = ReadAllStudents();
            students[idx] = s; //just replace the elem in array
            PersistFile(students);
        }

        /// <summary>
        /// Delete a student record
        /// </summary>
        /// <param name="idx">index of the deletion</param>
        public void DeleteStudent(int idx)
        {
            List<Student> students = ReadAllStudents();
            students.RemoveAt(idx);
            PersistFile(students);
        }

        /*HELPERS*/
        /// <summary>
        /// Format the student record CSV style
        /// </summary>
        /// <param name="s">well formed Student obj</param>
        /// <returns>Comma delimted string representation of Student for persistence</returns>
        private string FormatRecord(Student s)
        {
            return $"{s.FirstName},{s.LastName},{s.Major},{s.GPA}";
        }

        /// <summary>
        /// Write the student list to file
        /// </summary>
        /// <param name="students">List of all students</param>
        private void PersistFile(List<Student> students)
        {
            if (File.Exists(_path))
            {
                File.Delete(_path);
            }

            using (StreamWriter w = new StreamWriter(_path))
            {
                foreach (Student s in students)
                {
                    w.WriteLine(FormatRecord(s));
                }
            }
        }
    }
}