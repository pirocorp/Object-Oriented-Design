namespace CQRS.Commands.Handlers;

using CQRS.Commands;
using CQRS.Data.Entities;
using CQRS.Data.Repositories;

public class ProductsCommandHandler :
    ICommandHandler<AddNewProduct>,
    ICommandHandler<RateProduct>,
    ICommandHandler<AddToInventory>,
    ICommandHandler<ConfirmProductsShipped>,
    ICommandHandler<UpdateStockFromInventoryRecount>
{
    private readonly IRepository<Product> productsRepo;

    public ProductsCommandHandler(IRepository<Product> productsRepo)
    {
        this.productsRepo = productsRepo;
    }

    public void Handle(AddNewProduct command)
    {
        var product = Product.Create(
            command.Name,
            command.Description,
            command.UnitPrice,
            command.CurrentStock);

        productsRepo.Add(product);
        productsRepo.SaveChanges();
    }

    public void Handle(RateProduct command)
    {
        var product = productsRepo.GetById(command.ProductId);
        product?.RateProduct(command.Rating);

        productsRepo.SaveChanges();
    }

    public void Handle(AddToInventory command)
    {
        var product = productsRepo.GetById(command.ProductId);

        product?.AddToInventory(command.Stock);
        productsRepo.SaveChanges();
    }

    public void Handle(ConfirmProductsShipped command)
    {
        var product = productsRepo.GetById(command.ProductId);
        product?.ShipProducts(command.Count);

        productsRepo.SaveChanges();
    }

    public void Handle(UpdateStockFromInventoryRecount command)
    {
        var product = productsRepo.GetById(command.ProductId);
        product?.UpdateStock(command.Count);

        productsRepo.SaveChanges();
    }
}
