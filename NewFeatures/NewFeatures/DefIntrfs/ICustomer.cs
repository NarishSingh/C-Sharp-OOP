namespace NewFeatures;

public interface ICustomer
{
    IEnumerable<IOrder> PreviousOrders { get; }
    DateTime Joined { get; }
    DateTime? LastOrder { get; set; }
    string Name { get; }
    IDictionary<DateTime, string> Reminders { get; }
    
    //default interface method
    public decimal ComputeLoyaltyDiscount()
    {
        if (Joined < DateTime.Now.AddYears(-2) && PreviousOrders.Count() > 10) return 0.10m;

        return 0;
    }
}

