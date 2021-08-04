using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Channels;

namespace LinqToDb
{
    static class Program
    {
        static void Main(string[] args)
        {
            /*STANDARD LINQ PRACTICE*/
            string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };

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
            Console.WriteLine("-------");

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

            Console.WriteLine("-------");

            //SelectMany -> can be used to flatten an output
            //ex. split full names, and map to one collection
            //split returns an string[], but SelectMany will map it to one IEnumerable
            string[] fullNames = { "Abigail Williams", "John Doe", "Ramsingh Sharma" };
            IEnumerable<string> namesSplit = fullNames.SelectMany(n => n.Split());
            Console.WriteLine(string.Join("|", namesSplit));
            Console.WriteLine("-------");

            //using multiple range variables
            IEnumerable<string> splitOrigins = fullNames.SelectMany(full =>
                full.Split()
                    .Select(split => split + " came from " + full)); //Select within the SelectMany 
            Console.WriteLine(string.Join(",", splitOrigins));

            IEnumerable<string> splitOriginsOrdered = fullNames
                .SelectMany(full => full.Split().Select(name => new { name, full })
                    .OrderBy(x => x.full)
                    .ThenBy(x => x.name)
                    .Select(x => x.name + " came from " + x.full)
                );
            Console.WriteLine(string.Join(",", splitOriginsOrdered));
            Console.WriteLine("-------");

            //Cross Join with SelectMany -> use a select from the same source within the SelectMany
            //i.e. for every element1, reiterate the collection for element2, and select element1 vs element2
            string[] players = { "Tom", "Dom", "Yom", "Pom" };
            IEnumerable<string> matchups = players.SelectMany(p1 => players.Select(p2 => p1 + " vs " + p2));
            foreach (string round in matchups) Console.WriteLine(round);
            Console.WriteLine("-------");


            Console.WriteLine("-------");
            
            Console.WriteLine("*******");

            /*LINQ TO DB WITH EF CORE PRACTICE*/

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

            //Left join
            var purchasesQuery = dbContext.Customers
                .Select(c => new
                {
                    c.Name,
                    Purchases = dbContext.Purchases
                        .Where(p => p.CustomerId == c.Id && p.Price > 100)
                        .Select(p => new { p.Description, p.Price })
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

            //Cross join with SelectMany - both syntactic versions
            IQueryable<string> crossJoinQuery = from c in dbContext.Customers
                from p in dbContext.Purchases
                select c.Name + " might have bought a " + p.Description;

            IQueryable<string> crossJoinQuery2 = dbContext.Customers.SelectMany(c => dbContext.Purchases,
                (c, p) => c.Name + " might have bought a " + p.Description);

            Console.WriteLine(string.Join("\n", crossJoinQuery2));
            Console.WriteLine("-------");

            //inner join - both syntactic versions
            IQueryable<string> innerJoinQuery = from c in dbContext.Customers
                from p in dbContext.Purchases
                where c.Id == p.CustomerId
                select c.Name + " bought a " + p.Description;

            IQueryable<string> innerJoinQuery2 = dbContext.Customers
                .SelectMany(c => dbContext.Purchases, (c, p) => new { c, p })
                .Where(t => t.c.Id == t.p.CustomerId)
                .Select(t => t.c.Name + " bought a " + t.p.Description);

            Console.WriteLine(string.Join("\n", innerJoinQuery2));
            Console.WriteLine("-------");

            //Left join with SelectMany -> will switch to inner join, must use DefaultIfEmpty
            var leftJoinFlatQuery = from c in dbContext.Customers
                from p in c.Purchases.DefaultIfEmpty()
                select new
                {
                    c.Name,
                    Description = p == null ? null : p.Description,
                    Price = p == null ? (decimal?)null : p.Price
                };

            var leftJoinFlatQuery2 = dbContext.Customers
                .SelectMany(c => c.Purchases.DefaultIfEmpty(), (c, p) =>
                    new
                    {
                        c.Name,
                        Description = p == null ? null : p.Description,
                        Price = p == null ? (decimal?)null : p.Price
                    });

            Console.WriteLine("Customers, and purchases:");
            foreach (var allCustOptionalPur in leftJoinFlatQuery2)
            {
                Console.Write($"{allCustOptionalPur.Name}");
                Console.Write(allCustOptionalPur.Description != null
                    ? $" - {allCustOptionalPur.Description} | ${allCustOptionalPur.Price:C}\n"
                    : "\n");
            }

            Console.WriteLine("-------");

            //left join with filtering -> must be done before DefaultIfEmpty

            var leftJoinFlatQueryFiltered = from c in dbContext.Customers
                from p in c.Purchases.Where(p => p.Price > 1000).DefaultIfEmpty()
                select new
                {
                    c.Name,
                    Description = p == null ? null : p.Description,
                    Price = p == null ? (decimal?)null : p.Price
                };

            var leftJoinFlatQueryFiltered2 = dbContext.Customers
                .SelectMany(
                    c => c.Purchases.Where(p => p.Price > 1000).DefaultIfEmpty(),
                    (c, p) =>
                        new
                        {
                            c.Name,
                            Description = p == null ? null : p.Description,
                            Price = p == null ? (decimal?)null : p.Price
                        }
                );

            Console.WriteLine("Customers, and purchases:");
            foreach (var allCustOptionalPur in leftJoinFlatQueryFiltered2)
            {
                Console.Write($"{allCustOptionalPur.Name}");
                Console.Write(allCustOptionalPur.Description != null
                    ? $" - {allCustOptionalPur.Description} | ${allCustOptionalPur.Price:C}\n"
                    : "\n");
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