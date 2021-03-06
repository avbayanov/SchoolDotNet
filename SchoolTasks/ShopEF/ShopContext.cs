﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using ShopEf.Models;

namespace ShopEf
{
    public class ShopContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrdersProducts { get; set; }

        public ShopContext() : base("DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            const int stringMaxLength = 256;

            modelBuilder.Entity<Category>()
                .HasKey(f => f.Id);
            modelBuilder.Entity<Category>()
                .Property(f => f.Name)
                .IsRequired()
                .HasMaxLength(stringMaxLength);

            modelBuilder.Entity<Customer>()
                .HasKey(f => f.Id);
            modelBuilder.Entity<Customer>()
                .Property(f => f.FirstName)
                .IsRequired()
                .HasMaxLength(stringMaxLength);
            modelBuilder.Entity<Customer>()
                .Property(f => f.LastName)
                .IsRequired()
                .HasMaxLength(stringMaxLength);
            modelBuilder.Entity<Customer>()
                .Property(f => f.Phone)
                .IsRequired()
                .HasMaxLength(stringMaxLength);
            modelBuilder.Entity<Customer>()
                .Property(f => f.Email)
                .IsOptional()
                .HasMaxLength(stringMaxLength);

            modelBuilder.Entity<OrderProduct>()
                .HasKey(f => f.Id);
            modelBuilder.Entity<OrderProduct>()
                .Property(f => f.OrderId)
                .IsRequired()
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(
                        new IndexAttribute("OrderIdProductId", 1) {IsUnique = true}));
            modelBuilder.Entity<OrderProduct>()
                .Property(f => f.ProductId)
                .IsRequired()
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(
                        new IndexAttribute("OrderIdProductId", 2) { IsUnique = true }));
            modelBuilder.Entity<OrderProduct>()
                .HasRequired(f => f.Product)
                .WithMany(f => f.ProductOrders)
                .HasForeignKey(f => f.ProductId);
            modelBuilder.Entity<OrderProduct>()
                .HasRequired(f => f.Order)
                .WithMany(f => f.OrderProducts)
                .HasForeignKey(f => f.OrderId);

            modelBuilder.Entity<Product>()
                .HasKey(f => f.Id);
            modelBuilder.Entity<Product>()
                .Property(f => f.Name)
                .IsRequired()
                .HasMaxLength(stringMaxLength);

            modelBuilder.Entity<Order>()
                .HasKey(f => f.Id);
            modelBuilder.Entity<Order>()
                .HasRequired(f => f.Customer)
                .WithMany(f => f.Orders)
                .HasForeignKey(f => f.CustomerId);

            base.OnModelCreating(modelBuilder);
        }
    }
}