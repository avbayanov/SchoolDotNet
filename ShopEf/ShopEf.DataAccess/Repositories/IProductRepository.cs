using System.Collections.Generic;
using ShopEf.DataAccess.Models;

namespace ShopEf.DataAccess.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Product GetProductByName(string name);

        List<Product> GetProductsWithPrice(int price);

        List<Product> GetMostPopularProducts();
    }
}