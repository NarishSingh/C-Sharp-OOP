using System.Collections.Generic;

namespace LinqToDb
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public virtual List<Purchase> Purchases { get; set; } = new();

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}, {nameof(Salary)}: {Salary}"; //omitting purchases
        }
    }
}