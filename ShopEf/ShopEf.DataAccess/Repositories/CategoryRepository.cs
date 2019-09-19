using System.Data.Entity;
using System.Linq;
using ShopEf.DataAccess.Models;

namespace ShopEf.DataAccess.Repositories
{
    public class CategoryRepository : BaseEfRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DbContext db) : base(db)
        {
        }

        public int GetSalesByCategory(Category category)
        {
            return category.Products
                .SelectMany(product => product.ProductOrders)
                .Select(orderProduct => orderProduct.Quantity)
                .DefaultIfEmpty(0)
                .Sum();
        }
    }
}