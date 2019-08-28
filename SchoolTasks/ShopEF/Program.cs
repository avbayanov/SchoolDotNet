using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ShopEf.Models;

namespace ShopEf
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var shopDb = new ShopContext())
            {
                shopDb.Database.Log = s => Debug.WriteLine(s);

                var categories = FillCategories(shopDb);
                var customers = FillCustomers(shopDb);
                var products = FillProducts(shopDb, categories);
                FillOrders(shopDb, customers, products);

                Console.WriteLine("Order with id == 1 :");
                Console.WriteLine(shopDb.Orders.FirstOrDefault(order => order.Id == 1));

                Console.WriteLine();

                var productWithPrice123 = shopDb.Products
                    .FirstOrDefault(product => product.Price == 123);

                Console.WriteLine("Product with price == 123 :");
                Console.WriteLine(productWithPrice123);

                Console.WriteLine();

                var customersBoughtProductWithPrice123 = shopDb.Products
                    .FirstOrDefault(product => product.Id == productWithPrice123.Id)
                    .ProductOrders
                    .Select(productOrder => productOrder.Order)
                    .Select(order => order.Customer)
                    .Distinct()
                    .ToList();

                Console.WriteLine("Customers who bought {0} : ", productWithPrice123);
                Console.WriteLine(string.Join(Environment.NewLine, customersBoughtProductWithPrice123));

                Console.WriteLine();
                Console.WriteLine("Setting price = 800 for product with name == Product3");

                shopDb.Products
                    .FirstOrDefault(product => product.Name == "Product3")
                    .Price = 800;
                shopDb.SaveChanges();

                Console.WriteLine();
                Console.WriteLine("Deleting all orders made by customer with ast name == Customer2LastName");

                var customer2Id = shopDb.Customers
                    .FirstOrDefault(customer => customer.LastName == "Customer2LastName")
                    .Id;

                shopDb.Orders.RemoveRange(shopDb.Orders.Where(order => order.CustomerId == customer2Id));
                shopDb.SaveChanges();

                Console.WriteLine();

                var productMaxOrders = shopDb.Products
                    .Max(product => product.ProductOrders
                        .Sum(orderProduct => orderProduct.Quantity));

                var mostPopularProducts = shopDb.Products
                    .Where(product =>
                        product.ProductOrders.Sum(orderProduct => orderProduct.Quantity) == productMaxOrders);

                Console.WriteLine("Most popular products: ");
                Console.WriteLine(string.Join(Environment.NewLine, mostPopularProducts.ToList()));

                Console.WriteLine();

                var customersWithExpenses = shopDb.Customers
                    .GroupBy(customer => customer.Id)
                    .Select(g => new
                    {
                        Id = g.Key,
                        Sum = g.SelectMany(customer => customer.Orders
                                .SelectMany(order => order.OrderProducts
                                    .Select(orderProduct => orderProduct.Product.Price * orderProduct.Quantity)))
                            .DefaultIfEmpty(0)
                            .Sum()
                    })
                    .AsEnumerable()
                    .Join(customers,
                        p => p.Id,
                        t => t.Id,
                        (p, t) => new {p.Id, t.FirstName, t.LastName, p.Sum});

                Console.WriteLine("Customers with expenses: ");
                Console.WriteLine(string.Join(Environment.NewLine, customersWithExpenses.ToList()));

                Console.WriteLine();

                var categorySales = shopDb.Categories
                    .GroupBy(category => category.Id)
                    .Select(g => new
                    {
                        Id = g.Key,
                        Quantity = g.SelectMany(category => category.Products
                                    .SelectMany(product => product.ProductOrders))
                                    .Select(orderProduct => orderProduct.Quantity)
                                    .DefaultIfEmpty(0)
                                    .Sum()
                    }) 
                    .AsEnumerable()
                    .Join(categories,
                        p => p.Id,
                        t => t.Id,
                        (p, t) => new {p.Id, t.Name, p.Quantity});

                Console.WriteLine("Sales by categories: ");
                Console.WriteLine(string.Join(Environment.NewLine, categorySales.ToList()));
            }
        }

        private static List<Category> FillCategories(ShopContext shopContext)
        {
            var category1 = new Category {Name = "Category1"};
            shopContext.Categories.Add(category1);

            var category2 = new Category {Name = "Category2"};
            shopContext.Categories.Add(category1);

            var category3 = new Category {Name = "Category3"};
            shopContext.Categories.Add(category1);

            shopContext.SaveChanges();

            return new List<Category> {category1, category2, category3};
        }

        private static List<Customer> FillCustomers(ShopContext shopContext)
        {
            var customer1 = new Customer {FirstName = "Customer1FirstName", LastName = "Customer1LastName", Email = "cus1@cus.com", Phone = "12345"};
            shopContext.Customers.Add(customer1);

            var customer2 = new Customer {FirstName = "Customer2FirstName", LastName = "Customer2LastName", Email = "cus2@cus.com", Phone = "77777"};
            shopContext.Customers.Add(customer1);

            var customer3 = new Customer {FirstName = "Customer3FirstName", LastName = "Customer3LastName", Phone = "99999"};
            shopContext.Customers.Add(customer1);

            shopContext.SaveChanges();

            return new List<Customer> {customer1, customer2, customer3};
        }

        private static List<Product> FillProducts(ShopContext shopContext, List<Category> categories)
        {
            var product1 = new Product {Name = "Product1", Price = 123, Categories = {categories[0]}};
            shopContext.Products.Add(product1);

            var product2 = new Product {Name = "Product2", Price = 547, Categories = {categories[0], categories[1]}};
            shopContext.Products.Add(product1);

            var product3 = new Product {Name = "Product3", Price = 569, Categories = {categories[2]}};
            shopContext.Products.Add(product1);

            shopContext.SaveChanges();

            return new List<Product> {product1, product2, product3};
        }

        private static List<Order> FillOrders(ShopContext shopContext, List<Customer> customers, List<Product> products)
        {
            var order1 = new Order {Customer = customers[0]};
            shopContext.Orders.Add(order1);

            shopContext.OrdersProducts.Add(new OrderProduct {Order = order1, Product = products[0], Quantity = 1});

            var order2 = new Order {Customer = customers[1]};
            shopContext.Orders.Add(order2);

            shopContext.OrdersProducts.Add(new OrderProduct {Order = order2, Product = products[0], Quantity = 1});
            shopContext.OrdersProducts.Add(new OrderProduct {Order = order2, Product = products[1], Quantity = 1});

            var order3 = new Order {Customer = customers[2]};
            shopContext.Orders.Add(order3);

            shopContext.OrdersProducts.Add(new OrderProduct {Order = order3, Product = products[2], Quantity = 1});

            var order4 = new Order {Customer = customers[0]};
            shopContext.Orders.Add(order4);

            shopContext.OrdersProducts.Add(new OrderProduct {Order = order4, Product = products[0], Quantity = 1});
            shopContext.OrdersProducts.Add(new OrderProduct {Order = order4, Product = products[2], Quantity = 1});

            var order5 = new Order {Customer = customers[2]};
            shopContext.Orders.Add(order5);

            shopContext.OrdersProducts.Add(new OrderProduct {Order = order5, Product = products[2], Quantity = 2});

            shopContext.SaveChanges();

            return new List<Order> {order1, order2, order3, order4, order5};
        }
    }
}