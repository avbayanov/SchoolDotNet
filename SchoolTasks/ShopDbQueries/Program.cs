using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDbQueries
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                Console.WriteLine("Количество товаров: " + GetProductsCount(connection));

                Console.WriteLine();
                var categoryName = "Category999";
                Console.WriteLine("Добавляю категорию {0}...", categoryName);
                Console.WriteLine(AddCategory(connection, categoryName) ? "Категория {0} добавлена" : "Категория {0} не добавлена", categoryName);

                Console.WriteLine();
                var productName = "ProductA";
                var productPrice = 500;
                var productCategoryId = 4;
                Console.WriteLine("Добавляю товар {0}...", productName);
                Console.WriteLine(AddProduct(connection, "ProductA", productPrice, productCategoryId) ? "Товар {0} добавлен" : "Товар {0} не добавлен", productName);

                Console.WriteLine();
                var productId = 3;
                var newProductPrice = 999;
                Console.WriteLine("Меняю цену на товар с Id = {0} на {1}...", productId, newProductPrice);
                Console.WriteLine(ChangeProductPrice(connection, productId, newProductPrice) ? "Цена изменена" : "Цена не изменена");

                Console.WriteLine();
                var productNameToDelete = "Product1";
                Console.WriteLine("Удаляю товар {0}...", productNameToDelete);
                Console.WriteLine(DeleteProductByName(connection, productNameToDelete) ? "Товар удалён" : "Товар не удалён");

                Console.WriteLine();
                Console.WriteLine("Все товары:");
                PrintAllProducts(connection);

                Console.WriteLine();
                Console.WriteLine("Все товары с помощью DataSet:");
                PrintAllProductsUsingDataSet(connection);
            }
        }

        private static int GetProductsCount(SqlConnection connection)
        {
            var query = "SELECT COUNT(*) FROM Products";

            using (var command = new SqlCommand(query, connection))
            {
                return (int) command.ExecuteScalar();
            }
        }

        private static bool AddCategory(SqlConnection connection, string category)
        {
            var query = "INSERT INTO Categories (Name) VALUES (@category)";

            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.Add(new SqlParameter("@category", category) {SqlDbType = SqlDbType.NVarChar});

                return command.ExecuteNonQuery() == 1;
            }
        }

        private static bool AddProduct(SqlConnection connection, string name, int price, int categoryId)
        {
            var query = "INSERT INTO Products (Name, Price, categoryId) VALUES (@name, @price, @categoryId)";

            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.Add(new SqlParameter("@name", name) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@price", price) { SqlDbType = SqlDbType.Int });
                command.Parameters.Add(new SqlParameter("@categoryId", categoryId) { SqlDbType = SqlDbType.Int });

                return command.ExecuteNonQuery() == 1;
            }
        }

        private static bool ChangeProductPrice(SqlConnection connection, int id, int price)
        {
            var query = "UPDATE Products SET Price = @price WHERE Id = @id";

            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.Add(new SqlParameter("@id", id) { SqlDbType = SqlDbType.Int });
                command.Parameters.Add(new SqlParameter("@price", price) { SqlDbType = SqlDbType.Int });

                return command.ExecuteNonQuery() == 1;
            }
        }

        private static bool DeleteProductByName(SqlConnection connection, string name)
        {
            var query = "DELETE FROM Products WHERE Name = @name";

            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.Add(new SqlParameter("@name", name) { SqlDbType = SqlDbType.NVarChar });

                return command.ExecuteNonQuery() == 1;
            }
        }

        private static void PrintAllProducts(SqlConnection connection)
        {
            var query = "SELECT Products.Name, Price, Categories.Name AS Category FROM Products LEFT JOIN Categories ON Products.CategoryId = Categories.Id";

            using (var command = new SqlCommand(query, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("{0} | {1} | {2}", reader["Name"], reader["Price"], reader["Category"]);
                    }
                }
            }
        }

        private static void PrintAllProductsUsingDataSet(SqlConnection connection)
        {
            var query = "SELECT Products.Name, Price, Categories.Name AS Category FROM Products LEFT JOIN Categories ON Products.CategoryId = Categories.Id";

            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

            DataSet allProducts = new DataSet();

            adapter.Fill(allProducts);

            foreach (DataTable productsTable in allProducts.Tables)
            {
                foreach (DataRow productRow in productsTable.Rows)
                {
                    Console.WriteLine("{0} | {1} | {2}", productRow["Name"], productRow["Price"], productRow["Category"]);
                }
            }
        }
    }
}
