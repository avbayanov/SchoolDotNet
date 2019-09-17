using System.Collections.Generic;
using ShopEf.DataAccess.Models;

namespace ShopEf.DataAccess
{
    public interface IProductRepository : IRepository<Product>
    {
        List<Product> GetProductsWithPrice(int price);
    }
}