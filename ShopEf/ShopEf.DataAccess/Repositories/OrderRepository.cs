using System.Data.Entity;
using ShopEf.DataAccess.Models;

namespace ShopEf.DataAccess
{
    public class OrderRepository : BaseEfRepository<Order>, IOrderRepository
    {
        public OrderRepository(DbContext db) : base(db)
        {
        }
    }
}