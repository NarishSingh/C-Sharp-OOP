using System;
using System.Linq;

namespace LinqToDb
{
    class Program
    {
        static void Main(string[] args)
        {
            using CustomerContext dbContext = new CustomerContext();
            
            IQueryable<string> query = dbContext.Customers
                .Where(c => c.Name.Contains("a"))
                .OrderBy(c => c.Name.Length)
                .Select(c => c.Name.ToUpper());

            foreach (string name in query)
            {
                Console.WriteLine(string.Join(",", name));
            }
        }
    }
}