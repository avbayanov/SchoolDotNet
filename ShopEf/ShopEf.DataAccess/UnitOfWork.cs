using System;
using System.Data.Entity;
using ShopEf.DataAccess.Repositories;

namespace ShopEf.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        public DbContext _db { get; private set; }

        public UnitOfWork(DbContext db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public T GetRepository<T>() where T : class, IRepository
        {
            if (typeof(T) == typeof(IProductRepository))
            {
                return new ProductRepository(_db) as T;
            }

            if (typeof(T) == typeof(ICategoryRepository))
            {
                return new CategoryRepository(_db) as T;
            }

            if (typeof(T) == typeof(ICustomerRepository))
            {
                return new CustomerRepository(_db) as T;
            }

            if (typeof(T) == typeof(IOrderRepository))
            {
                return new OrderRepository(_db) as T;
            }

            if (typeof(T) == typeof(IOrderProductRepository))
            {
                return new OrderProductRepository(_db) as T;
            }

            throw new Exception("Unknown repository type: " + typeof(T));
        }
    }
}