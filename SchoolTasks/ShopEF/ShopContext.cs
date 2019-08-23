using System.Data.Entity;

namespace ShopEf
{
    public class ShopContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrdersProducts> OrdersProducts { get; set; }

        public ShopContext() : base("DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasKey(f => f.Id);
            modelBuilder.Entity<Category>().Property(f => f.Name).IsRequired();

            modelBuilder.Entity<Customer>().HasKey(f => f.Id);
            modelBuilder.Entity<Customer>().Property(f => f.FullName).IsRequired();
            modelBuilder.Entity<Customer>().Property(f => f.Phone).IsRequired();
            modelBuilder.Entity<Customer>().Property(f => f.Email).IsOptional();

            modelBuilder.Entity<OrdersProducts>().HasKey(f => f.Id);
            modelBuilder.Entity<OrdersProducts>()
                .HasRequired(f => f.Product)
                .WithMany(f => f.ProductOrders)
                .HasForeignKey(f => f.ProductId);
            modelBuilder.Entity<OrdersProducts>()
                .HasRequired(f => f.Order)
                .WithMany(f => f.OrderProducts)
                .HasForeignKey(f => f.OrderId);

            modelBuilder.Entity<Product>().HasKey(f => f.Id);
            modelBuilder.Entity<Product>().Property(f => f.Name).IsRequired();
            modelBuilder.Entity<Product>().Property(f => f.Price).IsRequired();

            modelBuilder.Entity<Order>().HasKey(f => f.Id);
            modelBuilder.Entity<Order>()
                .HasRequired(f => f.Customer)
                .WithMany(f => f.Orders)
                .HasForeignKey(f => f.CustomerId);

            base.OnModelCreating(modelBuilder);
        }
    }
}