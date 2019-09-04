using System;
using System.Collections.Generic;

namespace ShopEf.DataAccess.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

        public override string ToString()
        {
            return $"[ Id = {Id}, FirstName = {FirstName}, LastName = {LastName}, Phone = {Phone}, Email = {Email} ]";
        }
    }
}