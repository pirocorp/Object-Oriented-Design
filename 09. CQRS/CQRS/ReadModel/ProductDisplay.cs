namespace CQRS.ReadModel;

public class ProductDisplay
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public decimal UnitPrice { get; set; }

    public bool IsOutOfStock { get; set; }

    public double UserRating { get; set; }
}
