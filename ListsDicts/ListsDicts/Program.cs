using System;
using System.Collections.Generic;

namespace ListsDicts
{
    class Program
    {
        static void Main(string[] args)
        {
            /*lists*/
            List<int> l = new List<int>();
            l.Add(1);
            l.Add(2);
            l.Add(3);
            int[] addMulti = {4, 5, 6, 7, 8, 9, 10, 11};
            l.AddRange(addMulti);

            for (int i = 0; i < l.Count; i++)
            {
                Console.Write($"{l[i]} "); //access like an arr
            }

            l.Insert(2, 20);
            l.InsertRange(5, addMulti);
            Console.WriteLine("\n" + string.Join(", ", l));

            l.Remove(1);
            l.RemoveAll(n => n >= 10); //remove all w val's >=10
            l.RemoveAt(0);
            Console.WriteLine(string.Join(", ", l));

            //auto-init
            List<string> strL = new List<string>
            {
                "Apple", "Pear", "Banana", "Pineapple"
            };
            
            //for each loops
            foreach (string s in strL)
            {
                Console.WriteLine(s);
            }
            
            /*dictionary*/
            //auto init
            Dictionary<int, String> students = new Dictionary<int, string>
            {
                [1] = "Narish",
                [2] = "Singh"
            };
            
            students.Add(3, "Another Student");

            //access like an arr, but must use key
            for (int i = 1; i <= students.Count; i++)
            {
                Console.WriteLine($"{i} - {students[i]}");
            }

            Console.WriteLine(students.ContainsKey(0));
            Console.WriteLine(students.ContainsKey(3));

            students.Remove(1);
            Console.WriteLine(students.ContainsKey(1));
        }
    }
}