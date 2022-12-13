namespace CQRS.ReadModel;

using System;
using System.Collections.Generic;
using System.Linq;

using CQRS.Data.Entities;
using CQRS.Data.Repositories;

public class ProductsDao : IProductsDao
{
    private readonly IRepository<Product> productsRepo;

    public ProductsDao(IRepository<Product> productsRepo)
    {
        this.productsRepo = productsRepo;
    }

    public ProductDisplay? FindById(int productId)
    {
        var product = this.productsRepo.GetById(productId);

        if (product == null)
        {
            throw new InvalidOperationException("Product not found!");
        }

        return this.Map(product);
    }

    public ICollection<ProductDisplay> FindByName(string name)
        => this.productsRepo
            .List()
            .Where(p => p.Name == name)
            .Select(this.Map)
            .ToList();

    public ICollection<ProductInventory> FindOutOfStockProducts()
        => this.productsRepo
            .List()
            .Where(p => p.CurrentStock == 0)
            .Select(p => new ProductInventory()
            {
                Id = p.Id,
                CurrentStock = p.CurrentStock,
                Name = p.Name,
            })
            .ToList();

    private ProductDisplay Map(Product product)
        => new()
        {
            Id = product.Id,
            Description = product.Description,
            IsOutOfStock = product.CurrentStock == 0,
            UnitPrice = product.UnitPrice,
            Name = product.Name,
            UserRating = product.Ratings.Any() 
                ? product.Ratings.Average(x => x.Score)
                : 0
        };
}
