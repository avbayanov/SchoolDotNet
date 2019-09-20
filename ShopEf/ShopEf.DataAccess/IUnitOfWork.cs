using System;

namespace ShopEf.DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
        void BeginTransaction();
        void Rollback();
        T GetRepository<T>() where T : class, IRepository;
    }
}