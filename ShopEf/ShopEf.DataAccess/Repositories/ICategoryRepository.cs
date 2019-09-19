using ShopEf.DataAccess.Models;

namespace ShopEf.DataAccess.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        int GetSalesByCategory(Category category);
    }
}