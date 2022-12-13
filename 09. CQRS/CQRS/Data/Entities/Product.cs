namespace CQRS.Data.Entities;

using System.Collections.Generic;

public class Product : EntityBase
{
    public Product()
    { }

    private Product(
        string name, 
        string description,
        decimal unitPrice,
        int currentStock)
    {
        this.Name = name;
        this.Description = description;
        this.UnitPrice = unitPrice;
        this.CurrentStock = currentStock;
    }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public decimal UnitPrice { get; set; }

    public int CurrentStock { get; set; }

    public ICollection<Rating> Ratings { get; } = new List<Rating>();

    public static Product Create(
        string name,
        string description,
        decimal unitPrice,
        int currentStock)
        => new(name, description, unitPrice, currentStock);

    public void RateProduct(int score)
    {
        var rating = Rating.Create(score);
        this.Ratings.Add(rating);
    }

    public void AddToInventory(int count)
        => this.CurrentStock += count;

    public void ShipProducts(int count)
        => this.CurrentStock -= count;

    public void UpdateStock(int count)
        => this.CurrentStock = count;
}
