using System.Collections.Generic;

namespace ShopEf
{
    public class Customer
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

        public override string ToString()
        {
            return $"[ Id = {Id}, FullName = {FullName}, Phone = {Phone}, Email = {Email} ]";
        }
    }
}