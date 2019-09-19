using System.Collections.Generic;
using ShopEf.DataAccess.Models;

namespace ShopEf.DataAccess.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        List<Customer> GetCustomersWhoBoughtProduct(Product product);

        List<Customer> GetCustomersWithLastName(string lastName);

        int GetExpensesByCustomer(Customer customer);
    }
}