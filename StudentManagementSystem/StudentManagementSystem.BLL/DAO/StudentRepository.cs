using System;
using System.Collections.Generic;
using System.IO;
using StudentManagementSystem.BLL.DTO;

namespace StudentManagementSystem.BLL.DAO
{
    public class StudentRepository
    {
        private string _path;

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
                string line = $"{s.FirstName},{s.LastName},{s.Major},{s.GPA}";

                w.WriteLine(line);
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
                // sr.ReadLine(); //skip header row
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

        public void UpdateStudent(Student s, int idx)
        {
            throw new NotImplementedException();
        }

        public bool DeleteStudent(int idx)
        {
            throw new NotImplementedException();
        }
    }
}