using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ShopEf.DataAccess;
using ShopEf.DataAccess.Migrations;
using ShopEf.DataAccess.Models;
using ShopEf.DataAccess.Repositories;

namespace ShopEf
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ShopContext, Configuration>());

            using (var unitOfWork = new UnitOfWork(new ShopContext()))
            {
                var categories = FillCategories(unitOfWork);
                var customers = FillCustomers(unitOfWork);
                var products = FillProducts(unitOfWork, categories);
                FillOrders(unitOfWork, customers, products);
            }

            using (var unitOfWork = new UnitOfWork(new ShopContext()))
            {
                var orderRepository = unitOfWork.GetRepository<IOrderRepository>();

                Console.WriteLine("Order with id == 1 :");
                Console.WriteLine(orderRepository.GetById(1));
                Console.WriteLine();
            }

            using (var unitOfWork = new UnitOfWork(new ShopContext()))
            {
                var productRepository = unitOfWork.GetRepository<IProductRepository>();
                var customerRepository = unitOfWork.GetRepository<ICustomerRepository>();

                var productsWithPrice123 = productRepository.GetProductsWithPrice(123);
                Console.WriteLine("Products with (price == 123):");
                Console.WriteLine(string.Join(Environment.NewLine, productsWithPrice123.ToList()));
                Console.WriteLine();

                var customersWhoBoughtProductsWithPrice123 = productsWithPrice123
                    .SelectMany(productWithPrice123 => customerRepository
                        .GetCustomersWhoBoughtProduct(productWithPrice123))
                    .Distinct(); 
                Console.WriteLine("Customers who bought them: ");
                Console.WriteLine(string.Join(Environment.NewLine, customersWhoBoughtProductsWithPrice123.ToList()));
                Console.WriteLine();
            }

            using (var unitOfWork = new UnitOfWork(new ShopContext()))
            {
                var productRepository = unitOfWork.GetRepository<IProductRepository>();

                Console.WriteLine("Setting price = 800 for product with name == Product3");
                Console.WriteLine();

                var productWithNameProduct3 = productRepository.GetProductByName("Product3");
                productWithNameProduct3.Price = 800;

                unitOfWork.Save();
            }

            using (var unitOfWork = new UnitOfWork(new ShopContext()))
            {
                using (var transaction = unitOfWork._db.Database.BeginTransaction())
                {
                    try
                    {
                        var customerRepository = unitOfWork.GetRepository<ICustomerRepository>();
                        var orderRepository = unitOfWork.GetRepository<IOrderRepository>();

                        var customersWithLastNameCustomer2Ids = customerRepository
                            .GetCustomersWithLastName("Customer2LastName")
                            .Select(customer => customer.Id);

                        var ordersMadeByThem = customersWithLastNameCustomer2Ids
                            .SelectMany(customerId => orderRepository
                                .GetOrdersMadeByCustomerWithId(customerId))
                            .ToArray();

                        Console.WriteLine("Deleting all orders made by customers with Last name == Customer2LastName");
                        Console.WriteLine();

                        foreach (var order in ordersMadeByThem)
                        {
                            orderRepository.Delete(order);
                        }

                        unitOfWork.Save();
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                    }
                }
            }

            using (var unitOfWork = new UnitOfWork(new ShopContext()))
            {
                var customerRepository = unitOfWork.GetRepository<ICustomerRepository>();
                var orderRepository = unitOfWork.GetRepository<IOrderRepository>();

                var customersWithLastNameCustomer2Ids = customerRepository
                    .GetCustomersWithLastName("Customer2LastName")
                    .Select(customer => customer.Id);

                var ordersMadeByThem = customersWithLastNameCustomer2Ids
                    .SelectMany(customerId => orderRepository
                        .GetOrdersMadeByCustomerWithId(customerId))
                    .ToArray();

                Console.WriteLine("Deleting all orders made by customers with Last name == Customer2LastName");
                Console.WriteLine();

                foreach (var order in ordersMadeByThem)
                {
                    orderRepository.Delete(order);
                }

                unitOfWork.Save();
            }

            using (var unitOfWork = new UnitOfWork(new ShopContext()))
            {
                var productRepository = unitOfWork.GetRepository<IProductRepository>();

                var mostPopularProducts = productRepository.GetMostPopularProducts();

                Console.WriteLine("Most popular products: ");
                Console.WriteLine(string.Join(Environment.NewLine, mostPopularProducts));
                Console.WriteLine();
            }

            using (var unitOfWork = new UnitOfWork(new ShopContext()))
            {
                var customerRepository = unitOfWork.GetRepository<ICustomerRepository>();

                var customersWithExpenses = customerRepository.GetAll()
                    .Select(customer => new
                    {
                        customer.Id,
                        customer.FirstName,
                        customer.LastName,
                        Expenses = customerRepository.GetExpensesByCustomer(customer)
                    }).ToList();

                Console.WriteLine("Customers with expenses: ");
                Console.WriteLine(string.Join(Environment.NewLine, customersWithExpenses));
                Console.WriteLine();
            }

            using (var unitOfWork = new UnitOfWork(new ShopContext()))
            {
                var categoryRepository = unitOfWork.GetRepository<ICategoryRepository>();

                var categorySales = categoryRepository.GetAll()
                    .Select(category => new
                    {
                        category.Id,
                        category.Name,
                        Sales = categoryRepository.GetSalesByCategory(category)
                    }).ToList();

                Console.WriteLine("Sales by categories: ");
                Console.WriteLine(string.Join(Environment.NewLine, categorySales));
            }
        }

        private static List<Category> FillCategories(UnitOfWork unitOfWork)
        {
            var categoryRepository = unitOfWork.GetRepository<ICategoryRepository>();

            var category1 = new Category { Name = "Category1" };
            categoryRepository.Create(category1);

            var category2 = new Category { Name = "Category2" };
            categoryRepository.Create(category2);

            var category3 = new Category { Name = "Category3" };
            categoryRepository.Create(category3);

            unitOfWork.Save();

            return new List<Category> {category1, category2, category3};
        }

        private static List<Customer> FillCustomers(UnitOfWork unitOfWork)
        {
            var customerRepository = unitOfWork.GetRepository<ICustomerRepository>();

            var customer1 = new Customer {FirstName = "Customer1FirstName", LastName = "Customer1LastName", Email = "cus1@cus.com", Phone = "12345", DateOfBirth = new DateTime(2019, 09, 04)};
            customerRepository.Create(customer1);

            var customer2 = new Customer {FirstName = "Customer2FirstName", LastName = "Customer2LastName", Email = "cus2@cus.com", Phone = "77777", DateOfBirth = new DateTime(1949, 05, 06)};
            customerRepository.Create(customer2);

            var customer3 = new Customer {FirstName = "Customer3FirstName", LastName = "Customer3LastName", Phone = "99999", DateOfBirth = new DateTime(2008, 09, 01)};
            customerRepository.Create(customer3);

            unitOfWork.Save();

            return new List<Customer> {customer1, customer2, customer3};
        }

        private static List<Product> FillProducts(UnitOfWork unitOfWork, List<Category> categories)
        {
            var productRepository = unitOfWork.GetRepository<IProductRepository>();

            var product1 = new Product {Name = "Product1", Price = 123, Categories = {categories[0]}};
            productRepository.Create(product1);

            var product2 = new Product {Name = "Product2", Price = 547, Categories = {categories[0], categories[1]}};
            productRepository.Create(product2);

            var product3 = new Product {Name = "Product3", Price = 569, Categories = {categories[2]}};
            productRepository.Create(product3);

            unitOfWork.Save();

            return new List<Product> {product1, product2, product3};
        }

        private static List<Order> FillOrders(UnitOfWork unitOfWork, List<Customer> customers, List<Product> products)
        {
            var orderRepository = unitOfWork.GetRepository<IOrderRepository>();
            var orderProductRepository = unitOfWork.GetRepository<IOrderProductRepository>();

            var order1 = new Order {Customer = customers[0]};
            orderRepository.Create(order1);

            orderProductRepository.Create(new OrderProduct {Order = order1, Product = products[0], Quantity = 1});

            var order2 = new Order {Customer = customers[1]};
            orderRepository.Create(order2);

            orderProductRepository.Create(new OrderProduct {Order = order2, Product = products[0], Quantity = 1});
            orderProductRepository.Create(new OrderProduct {Order = order2, Product = products[1], Quantity = 1});

            var order3 = new Order {Customer = customers[2]};
            orderRepository.Create(order3);

            orderProductRepository.Create(new OrderProduct {Order = order3, Product = products[2], Quantity = 1});

            var order4 = new Order {Customer = customers[0]};
            orderRepository.Create(order4);

            orderProductRepository.Create(new OrderProduct {Order = order4, Product = products[0], Quantity = 1});
            orderProductRepository.Create(new OrderProduct {Order = order4, Product = products[2], Quantity = 1});

            var order5 = new Order {Customer = customers[2]};
            orderRepository.Create(order5);

            orderProductRepository.Create(new OrderProduct {Order = order5, Product = products[2], Quantity = 2});

            unitOfWork.Save();

            return new List<Order> {order1, order2, order3, order4, order5};
        }
    }
}