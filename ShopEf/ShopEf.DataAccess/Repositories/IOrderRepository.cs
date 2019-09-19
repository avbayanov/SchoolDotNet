using System.Collections.Generic;
using ShopEf.DataAccess.Models;

namespace ShopEf.DataAccess.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        List<Order> GetOrdersMadeByCustomerWithId(int id);
    }
}