namespace CQRS.Commands;

using System;

public class AddToInventory : ICommand
{
    public AddToInventory()
    {
        this.Id = Guid.NewGuid();
    }

    public Guid Id { get; }

    public int ProductId { get; set; }

    public int Stock { get; set; }
}
