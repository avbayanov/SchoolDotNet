using System.Collections.Generic;
using System.Linq;

namespace ShopEf
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public virtual ICollection<Category> Categories { get; set; } = new List<Category>();

        public virtual ICollection<OrdersProducts> ProductOrders { get; set; } = new List<OrdersProducts>();

        public override string ToString()
        {
            return $"[ Id = {Id}, Name = '{Name}', Price = {Price}," +
                   $" CategoriesIds = [{string.Join(", ", Categories.Select(category => category.Id))}]," +
                   $" OrdersIds = [{string.Join(", ", ProductOrders.Select(order => order.Id))}] ]";
        }
    }
}