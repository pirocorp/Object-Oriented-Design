namespace CQRS.Commands;

using System;

public class ConfirmProductsShipped : ICommand
{
    public ConfirmProductsShipped()
    {
        this.Id = Guid.NewGuid();
    }

    public Guid Id { get; }

    public int ProductId { get; set; }

    public int Count { get; set; }
}
