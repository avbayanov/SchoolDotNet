using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ShopEf.DataAccess.Models;

namespace ShopEf.DataAccess.Repositories
{
    public class ProductRepository : BaseEfRepository<Product>, IProductRepository
    {
        public ProductRepository(DbContext db) : base(db)
        {
        }

        public Product GetProductByName(string name)
        {
            return _dbSet
                .FirstOrDefault(product => product.Name == name);
        }

        public List<Product> GetProductsWithPrice(int price)
        {
            return _dbSet
                .Where(product => product.Price == price)
                .ToList();
        }

        public List<Product> GetMostPopularProducts()
        {
            var productMaxOrders = _dbSet
                .Max(product => product.ProductOrders
                    .Sum(orderProduct => orderProduct.Quantity));

            return _dbSet
                .Where(product => product.ProductOrders
                    .Sum(orderProduct => orderProduct.Quantity) == productMaxOrders)
                .ToList();
        }
    }
}