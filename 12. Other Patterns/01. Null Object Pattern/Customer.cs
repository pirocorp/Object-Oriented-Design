namespace NullObjectPattern;

public class Customer
{
    public string Name { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    public int OrderCount { get; set; }

    public decimal TotalSales { get; set; }

    public static Customer NotFound =
        new ()
        {
            OrderCount = 0, 
            TotalSales = 0, 
            Name = string.Empty,
            Phone = string.Empty
        };
}
