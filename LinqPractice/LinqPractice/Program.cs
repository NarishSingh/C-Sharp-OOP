using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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

            //remove all vowels and select only the names >2 len
            IEnumerable<string> noVowels = names.Select(n => Regex.Replace(n, "[aeiou]", ""))
                .Where(n => n.Length > 2)
                .OrderBy(n => n);
            Console.WriteLine($"Vowels removed, >2 length: {string.Join(",", noVowels)}");

            Console.WriteLine("-------");

            //Anonymous types = require the use of the var keyword
            var vowelless = from n in names
                select new
                {
                    Original = n,
                    Vowelless = Regex.Replace(n, "[aeiou]", "")
                };

            // var vowelless = names.Select(n => new {Original = n, Vowelless = Regex.Replace(n, "[aeiou]", "")}); //fluent syntax

            IEnumerable<string> noVowelsAnon = vowelless.Where(item => item.Vowelless.Length > 2)
                .Select(item => item.Original);

            Console.WriteLine(
                $"Anon Type version, >2 length when stripped of vowels: {string.Join(",", noVowelsAnon)}");

            Console.WriteLine("-------");
        }
    }
}