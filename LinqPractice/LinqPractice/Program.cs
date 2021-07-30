using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqPractice
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string[] names = {"Tom", "Dick", "Harry", "Mary", "Jay"};

            //Select the shortest names = order by length so we can select the shortest length, which will be first
            IEnumerable<string> shortestNames = names.Where(
                n => n.Length == names.OrderBy(n2 => n2.Length)
                    .Select(n2 => n2.Length)
                    .First()
            );
            Console.WriteLine($"Shortest Names: {string.Join(", ", shortestNames)}");
            
            //or use .Min(this, selector)
            IEnumerable<string> shortestNames2 = names.Where(n => n.Length == names.Min(n2 => n2.Length));
            Console.WriteLine($"Shortest Names (aggregate version): {string.Join(", ", shortestNames2)}");

            Console.WriteLine("-------");
            
            
        }
    }
}