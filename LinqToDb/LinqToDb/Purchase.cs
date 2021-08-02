using System;

namespace LinqToDb
{
    public class Purchase
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public virtual Customer Customer { get; set; }
    }
}