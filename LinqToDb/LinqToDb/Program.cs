using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace LinqToDb
{
    static class Program
    {
        static void Main(string[] args)
        {
            /*STANDARD LINQ PRACTICE*/
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
            Console.WriteLine($"Anon Type version, >2 length, stripped of vowels: {string.Join(",", noVowelsAnon)}");

            Console.WriteLine("-------");

            //use the indexer of .Where to skip even elements
            IEnumerable<string> oddsOnly = names.Where((n, i) => i % 2 == 0);
            Console.WriteLine($"Odd indexed names only: {string.Join(",", oddsOnly)}");

            //Subqueries and obj hierarchies -> can use queries within other queries
            string tempPath = Path.GetTempPath();
            DirectoryInfo[] dirs = new DirectoryInfo(tempPath).GetDirectories();

            var fileQuery = dirs
                .Where(d => (d.Attributes & FileAttributes.System) == 0)
                .Select(d => new
                {
                    DirectoryName = d.FullName,
                    Created = d.CreationTime,
                    Files = d.GetFiles()
                        .Where(f => (f.Attributes & FileAttributes.Hidden) == 0)
                        .Select(f => new
                        {
                            FileName = f.Name, f.Length
                        })
                }); //since we are using an anon type, must use var

            foreach (var dirFiles in fileQuery)
            {
                Console.WriteLine($"Dir: {dirFiles.DirectoryName}");
                foreach (var file in dirFiles.Files)
                {
                    Console.WriteLine($" {file.FileName} Len: {file.Length}");
                }
            }

            /*LINQ TO DB WITH EF CORE PRACTICE*/
            Console.WriteLine("*******");

            using CustomerContext dbContext = new CustomerContext();

            //Get names that contain a, capitalize
            IQueryable<string> namesQueryA = dbContext.Customers
                .Where(c => c.Name.Contains("a"))
                .OrderBy(c => c.Name.Length)
                .Select(c => c.Name.ToUpper());

            Console.WriteLine("Names with A, capitalized:");
            Console.WriteLine(string.Join(",", namesQueryA));
            Console.WriteLine("-------");

            //Get salaries below 100k
            IQueryable<Customer> salaryQuery100k = dbContext.Customers
                .Where(c => c.Salary < 100000)
                .OrderBy(c => c.Salary)
                .Select(c => c);

            Console.WriteLine("Customers with salaries below 100k:");
            foreach (Customer c in salaryQuery100k) Console.WriteLine($"{c.Name} - {c.Salary:C}/yr");
            Console.WriteLine("-------");

            //combining local and interpreted queries - make sure the interpreted are on the inside
            IEnumerable<string> mixedQuery = dbContext.Customers
                .Select(c => c.Name.ToUpper())
                .OrderBy(c => c)
                .Pair() //local from now on
                .Select((c, i) => $"Pair {i} = {c}");

            Console.WriteLine("Customers, paired:");
            foreach (string pairs in mixedQuery) Console.WriteLine(pairs);
            Console.WriteLine("-------");

            var purchasesQuery = dbContext.Customers
                .Select(c => new
                {
                    c.Name,
                    Purchases = dbContext.Purchases
                        .Where(p => p.CustomerId == c.Id && p.Price > 100)
                        .Select(p => new {p.Description, p.Price})
                        .ToList()
                });
            foreach (var namePurchases in purchasesQuery)
            {
                Console.WriteLine($"Customer: {namePurchases.Name}");
                foreach (var buyDetail in namePurchases.Purchases)
                {
                    Console.WriteLine($" - {buyDetail.Description} | $$$: {buyDetail.Price}");
                }
            }
            Console.WriteLine("-------");
        }

        /// <summary>
        /// Extension method - pair up consecutive strings in collection
        /// </summary>
        /// <param name="source">IEnumerable of string</param>
        /// <returns></returns>
        private static IEnumerable<string> Pair(this IEnumerable<string> source)
        {
            string firstHalf = null;
            foreach (string s in source)
            {
                if (firstHalf == null)
                {
                    firstHalf = s;
                }
                else
                {
                    //yield indicates its an iterator extension method -> yield return means return one at a time
                    yield return firstHalf + ", " + s;
                    firstHalf = null;
                }
            }
        }
    }
}