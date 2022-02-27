namespace NewFeatures;

public class SampleOrder : IOrder
{
    public DateTime Purchased { get; }
    public decimal Cost { get; }

    public SampleOrder(DateTime purchased, decimal cost)
    {
        Purchased = purchased;
        Cost = cost;
    }
}