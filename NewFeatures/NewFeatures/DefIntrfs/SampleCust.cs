namespace NewFeatures;

public class SampleCust : ICustomer
{
    public IEnumerable<IOrder> PreviousOrders => _allOrders;
    public DateTime Joined { get; }
    public DateTime? LastOrder { get; set; }
    public string Name { get; }
    public IDictionary<DateTime, string> Reminders => _reminders;

    private List<IOrder> _allOrders = new();
    private Dictionary<DateTime, string> _reminders = new();

    public void AddOrder(IOrder o)
    {
        if (o.Purchased > (LastOrder ?? DateTime.MinValue)) LastOrder = o.Purchased;

        _allOrders.Add(o);
    }

    public SampleCust(string name, DateTime joined)
    {
        Name = name;
        Joined = joined;
    }
}