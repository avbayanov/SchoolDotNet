using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ShopEf.DataAccess.Models;

namespace ShopEf.DataAccess
{
    public class ProductRepository : BaseEfRepository<Product>, IProductRepository
    {
        public ProductRepository(DbContext db) : base(db)
        {
        }

        public List<Product> GetProductsWithPrice(int price)
        {
            return _dbSet
                .Where(product => product.Price == price)
                .ToList();
        }
    }
}