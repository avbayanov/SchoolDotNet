using System;
using System.Data.Entity;
using Phonebook.DataAccess.Repositories;

namespace Phonebook.DataAccess
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
            if (typeof(T) == typeof(IContactRepository))
            {
                return new ContactRepository(_db) as T;
            }

            throw new Exception("Unknown repository type: " + typeof(T));
        }
    }
}