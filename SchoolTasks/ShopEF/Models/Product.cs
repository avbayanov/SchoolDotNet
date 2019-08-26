using System.Collections.Generic;
using System.Linq;

namespace ShopEf.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public virtual ICollection<Category> Categories { get; set; } = new List<Category>();

        public virtual ICollection<OrderProduct> ProductOrders { get; set; } = new List<OrderProduct>();

        public override string ToString()
        {
            return $"[ Id = {Id}, Name = '{Name}', Price = {Price}," +
                   $" CategoriesIds = [{string.Join(", ", Categories.Select(category => category.Id))}]," +
                   $" OrdersIds = [{string.Join(", ", ProductOrders.Select(orderProduct => orderProduct.OrderId))}] ]";
        }
    }
}