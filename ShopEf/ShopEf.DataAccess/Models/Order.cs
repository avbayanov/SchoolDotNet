using System.Collections.Generic;
using System.Linq;

namespace ShopEf.DataAccess.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();

        public override string ToString()
        {
            return $"[ Id = {Id}, Customer = {Customer}, ProductsIds = [{string.Join(", ", OrderProducts.Select(orderProduct => orderProduct.ProductId))}] ]";
        }
    }
}