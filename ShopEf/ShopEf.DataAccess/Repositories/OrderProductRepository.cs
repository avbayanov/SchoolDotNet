using System.Data.Entity;
using ShopEf.DataAccess.Models;

namespace ShopEf.DataAccess.Repositories
{
    public class OrderProductRepository : BaseEfRepository<OrderProduct>, IOrderProductRepository
    {
        public OrderProductRepository(DbContext db) : base(db)
        {
        }
    }
}