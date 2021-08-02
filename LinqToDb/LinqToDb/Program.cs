using System;
using System.Linq;

namespace LinqToDb
{
    class Program
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
            foreach (Customer c in salaryQuery100k)
            {
                Console.WriteLine($"{c.Name} - {c.Salary:C}/yr");
            }
        }
    }
}