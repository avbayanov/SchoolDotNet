using System;
using System.Data.Entity;
using ShopEf.DataAccess.Repositories;

namespace ShopEf.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _db;
        private DbContextTransaction _transaction;

        public UnitOfWork(DbContext db)
        {
            _db = db;
        }

        public void Save()
        {
            if (_transaction != null)
            {
                _transaction.Commit();
                _transaction.Dispose();
                _transaction = null;
            }

            _db.SaveChanges();
        }

        public void Dispose()
        {
            if (_transaction != null)
            {
                Rollback();
            }

            _db.Dispose();
        }

        public void BeginTransaction()
        {
            _transaction = _db.Database.BeginTransaction();
        }

        public void Rollback()
        {
            if (_transaction == null)
            {
                return;
            }

            _transaction.Rollback();
            _transaction.Dispose();
            _transaction = null;
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