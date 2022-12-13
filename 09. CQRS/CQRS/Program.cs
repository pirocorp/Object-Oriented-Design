namespace CQRS;

using System;

using CQRS.Commands;
using CQRS.Commands.Handlers;
using CQRS.Data.Repositories;
using CQRS.ReadModel;

public static class Program
{
    private static readonly ProductsCommandHandler ProductsCommandHandler;
    private static readonly ProductsDao ProductsDao;

    static Program()
    {
        var productsRepo = new ProductRepository();

        ProductsCommandHandler = new ProductsCommandHandler(productsRepo);
        ProductsDao = new ProductsDao(productsRepo);
    }

    public static void Main()
    {
        var product = ProductsDao.FindById(1);
        PrintProduct(product);

        ProductsCommandHandler.Handle(new AddNewProduct()
        {
            Name = "New Product",
            CurrentStock = 6,
            Description = "Best New Product",
            UnitPrice = 256.56M
        });

        product = ProductsDao.FindById(3);
        PrintProduct(product);

        ProductsCommandHandler.Handle(new UpdateStockFromInventoryRecount()
        {
            ProductId = 3,
            Count = 0
        });

        product = ProductsDao.FindById(3);
        PrintProduct(product);
    }

    private static void PrintProduct(ProductDisplay product)
    {
        Console.WriteLine($"{product.Id}: {product.Name}: ${product.UnitPrice} {(product.IsOutOfStock ? "- Out of Stock" : string.Empty)}");
    }
}
