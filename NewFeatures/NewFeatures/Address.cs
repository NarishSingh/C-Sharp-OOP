namespace NewFeatures;

public class Address
{
    public string State { get; set; }
    public string City { get; set; }
    public string Freeform { get; set; } //addr no + st name

    public static decimal ComputerSalesTax(Address location, decimal salePrice) =>
        location switch
        {
            { State: "WA" } => salePrice * 0.06m,
            { State: "MN" } => salePrice * 0.075m,
            { State: "MI" } => salePrice * 0.05m,
            _ => 0m
        };
}