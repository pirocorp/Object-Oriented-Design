namespace CQRS.Commands;

using System;

public class RateProduct : ICommand
{
    public RateProduct()
    {
        this.Id = Guid.NewGuid();
    }

    public Guid Id { get; }

    public int ProductId { get; set; }

    public int Rating { get; set; }
}
