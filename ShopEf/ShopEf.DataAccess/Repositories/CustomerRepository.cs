using System.Data.Entity;
using ShopEf.DataAccess.Models;

namespace ShopEf.DataAccess
{
    public class CustomerRepository : BaseEfRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DbContext db) : base(db)
        {
        }
    }
}