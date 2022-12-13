namespace CQRS.ReadModel;

using System.Collections.Generic;

/// <summary>
/// Products Data Access Object Interface
/// </summary>
public interface IProductsDao
{
    ProductDisplay? FindById(int productId);

    ICollection<ProductDisplay> FindByName(string name);

    ICollection<ProductInventory> FindOutOfStockProducts();
}
