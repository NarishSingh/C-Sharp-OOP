using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQonCollections
{
    class Program
    {
        public class Student
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Major { get; set; }

            public Student(int id, string firstName, string lastName, string major)
            {
                Id = id;
                FirstName = firstName;
                LastName = lastName;
                Major = major;
            }

            public override string ToString()
            {
                return string.Join(", ", Id, FirstName, LastName, Major);
            }
        }

        public class StudentCourse
        {
            public int StudentId { get; set; }
            public string CourseName { get; set; }

            public StudentCourse(int studentId, string courseName)
            {
                StudentId = studentId;
                CourseName = courseName;
            }
        }

        static void Main(string[] args)
        {
            List<int> nums = new List<int>
            {
                4, 2, 3, 7, 15, 20, 6
            };

            List<int> odds = new List<int>();

            //declarative/query syntax
            IEnumerable<int> oddQuery = from n in nums
                where n % 2 == 1
                select n;

            foreach (int o in oddQuery)
            {
                Console.WriteLine(o);
            }

            //imperative/method form
            IEnumerable<int> theOdds = nums.Where(n => n % 2 == 1);
            foreach (int odd in theOdds)
            {
                Console.WriteLine(odd);
            }
            //^ returns enumeration

            //scalar type returns just one value, capture w a primitive or ref type
            int numOdds = nums.Count(n => n % 2 == 1);
            Console.WriteLine($"Total Odds: {numOdds}");

            //cast enumeration to List
            List<int> oddList = nums.Where(n => n % 2 == 1).ToList();
            Console.WriteLine(string.Join(", ", oddList));

            //cast to dict
            List<Student> students = new List<Student>
            {
                new(1, "Narish", "Singh", "Computer Science"),
                new(2, "Second", "Singh", "Biology"),
                new(3, "Third", "Singh", "Chemistry"),
                new(4, "First", "Bhim", "Biology"),
                new(5, "Second", "Bhim", "Computer Science")
            };

            Dictionary<int, Student> singhsInClass = students
                .Where(s => s.LastName.Equals("Singh"))
                .ToDictionary(s => s.Id, s => s);

            Dictionary<int, Student>.KeyCollection singhKeys = singhsInClass.Keys;
            foreach (int key in singhKeys)
            {
                Console.WriteLine(singhsInClass[key].FirstName);
            }

            /*declarative query operations*/
            List<StudentCourse> courses = new List<StudentCourse>
            {
                new(1, "C# 101"),
                new(1, ".ASP 102"),
                new(1, "Java 101"),
                new(1, "CSS 101")
            };

            //joins return neither type, but an anon type, need a select clause to specify the return obj
            var joinQuery = from s in students
                join c in courses
                    on s.Id equals c.StudentId
                select new
                {
                    StudentID = s.Id,
                    LastName = s.LastName,
                    CourseName = c.CourseName
                };
            foreach (var sc in joinQuery)
            {
                Console.WriteLine(sc.ToString());
            }

            Console.WriteLine();

            //where and ordering
            var singhQuery = from s in students
                join c in courses
                    on s.Id equals c.StudentId
                where s.LastName == "Singh"
                orderby c.CourseName descending
                select new
                {
                    StudentID = s.Id,
                    LastName = s.LastName,
                    CourseName = c.CourseName
                };
            foreach (var singh in singhQuery)
            {
                Console.WriteLine(singh);
            }

            Console.WriteLine();

            //grouping
            var groupMajor = from s in students
                orderby s.Major, s.LastName
                group s by s.Major;
            foreach (var sm in groupMajor)
            {
                Console.WriteLine(sm.Key);

                foreach (Student student in sm)
                {
                    Console.WriteLine(student.ToString());
                }
            }
        }
    }
}