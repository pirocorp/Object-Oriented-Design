namespace CQRS.ReadModel;

public class ProductInventory
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public int CurrentStock { get; set; }
}
