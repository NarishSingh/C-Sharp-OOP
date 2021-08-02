using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqToDb
{
    static class Program
    {
        static void Main(string[] args)
        {
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