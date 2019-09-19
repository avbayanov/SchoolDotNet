using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ShopEf.DataAccess.Models;

namespace ShopEf.DataAccess.Repositories
{
    public class CustomerRepository : BaseEfRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DbContext db) : base(db)
        {
        }

        public List<Customer> GetCustomersWhoBoughtProduct(Product product)
        {
            return product
                .ProductOrders
                .Select(productOrder => productOrder.Order)
                .Select(order => order.Customer)
                .Distinct()
                .ToList();
        }

        public List<Customer> GetCustomersWithLastName(string lastName)
        {
            return _dbSet
                .Where(customer => customer.LastName == lastName)
                .ToList();
        }

        public int GetExpensesByCustomer(Customer customer)
        {
            return customer.Orders
                .SelectMany(order => order.OrderProducts
                    .Select(orderProduct => orderProduct.Product.Price * orderProduct.Quantity))
                .DefaultIfEmpty(0)
                .Sum();
        }
    }
}