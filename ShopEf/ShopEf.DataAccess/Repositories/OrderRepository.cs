using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ShopEf.DataAccess.Models;

namespace ShopEf.DataAccess.Repositories
{
    public class OrderRepository : BaseEfRepository<Order>, IOrderRepository
    {
        public OrderRepository(DbContext db) : base(db)
        {
        }

        public List<Order> GetOrdersMadeByCustomerWithId(int id)
        {
            return _dbSet
                .Where(order => order.CustomerId == id)
                .ToList();
        }
    }
}