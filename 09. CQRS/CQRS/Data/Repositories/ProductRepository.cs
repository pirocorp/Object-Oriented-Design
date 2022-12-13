namespace CQRS.Data.Repositories;

using System.Collections.Generic;
using System.Linq;

using CQRS.Data.Entities;

public class ProductRepository : IRepository<Product>
{
    private readonly Dictionary<int, Product> products;

    public ProductRepository()
    {
        var p = new Product();

        this.products = new Dictionary<int, Product>()
        {
            {
                1, 
                new Product
                {
                    Id = 1,
                    Name = "Product 1",
                    Description = "Description of Product 1",
                    UnitPrice = 123,
                    CurrentStock = 555
                }
            },
            {
                2, 
                new Product
                {
                    Id = 2,
                    Name = "Product 2",
                    Description = "Description of Product 2",
                    UnitPrice = 333,
                    CurrentStock = 444
                }
            }
        };
    }

    public Product? GetById(int id)
    {
        this.products.TryGetValue(id, out var result);
        return result;
    }

    public IEnumerable<Product> List()
        => this.products
            .Select(p => p.Value)
            .ToList();

    public void Add(Product entity)
    {
        var newKey = this.products.Keys.Max() + 1;

        entity.Id = newKey;
        this.products[newKey] = entity;
    }

    public void Delete(Product entity)
    {
        this.products.Remove(entity.Id);
    }

    public void Edit(Product entity)
    {
        this.products[entity.Id] = entity;
    }

    public void SaveChanges()
    {
        return;
    }
}
