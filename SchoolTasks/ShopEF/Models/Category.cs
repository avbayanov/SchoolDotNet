using System.Collections.Generic;
using System.Linq;

namespace ShopEf.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();

        public override string ToString()
        {
            return $"[ Id = {Id}, Name = {Name}, ProductsIds = [{string.Join(", ", Products.Select(product => product.Id))}] ]";
        }
    }
}