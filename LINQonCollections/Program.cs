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

            public Student(int id, string firstName, string lastName)
            {
                Id = id;
                FirstName = firstName;
                LastName = lastName;
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
            List<Student> mathClass = new List<Student>
            {
                new Student(1, "Narish", "Singh"),
                new Student(2, "Second", "Singh"),
                new Student(3, "Third", "Singh"),
                new Student(4, "First", "Bhim"),
                new Student(5, "Second", "Bhim")
            };

            Dictionary<int, Student> singhsInClass = mathClass
                .Where(s => s.LastName.Equals("Singh"))
                .ToDictionary(s => s.Id, s => s);
            
            Dictionary<int, Student>.KeyCollection singhKeys = singhsInClass.Keys;
            foreach (int key in singhKeys)
            {
                Console.WriteLine(singhsInClass[key].FirstName);
            }
            
            /*declarative query operations*/
        }
    }
}