using System.Collections.Generic;
using System.Linq;

namespace ShopEf.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public virtual ICollection<OrdersProducts> OrderProducts { get; set; } = new List<OrdersProducts>();

        public override string ToString()
        {
            return $"[ Id = {Id}, Customer = {Customer}, ProductsIds = [{string.Join(", ", OrderProducts.Select(product => product.Id))}] ]";
        }
    }
}