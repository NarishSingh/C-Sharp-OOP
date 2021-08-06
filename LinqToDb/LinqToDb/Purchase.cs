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

        public override string ToString()
        {
            return
                $"{nameof(Id)}: {Id}, {nameof(CustomerId)}: {CustomerId}, {nameof(Date)}: {Date.ToShortDateString()}, "
                + $"{nameof(Description)}: {Description}, {nameof(Price)}: {Price}, {nameof(Customer)}: {Customer}";
        }
    }
}