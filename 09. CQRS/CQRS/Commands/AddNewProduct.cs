namespace CQRS.Commands;

using System;

public class AddNewProduct : ICommand
{
    public AddNewProduct()
    {
        this.Id = Guid.NewGuid();
    }

    public Guid Id { get; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public decimal UnitPrice { get; set; }

    public int CurrentStock { get; set; }
}
