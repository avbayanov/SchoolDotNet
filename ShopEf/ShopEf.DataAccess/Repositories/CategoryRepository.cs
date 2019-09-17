using System.Data.Entity;
using ShopEf.DataAccess.Models;

namespace ShopEf.DataAccess
{
    public class CategoryRepository : BaseEfRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DbContext db) : base(db)
        {
        }
    }
}