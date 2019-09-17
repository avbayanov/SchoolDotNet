using System;

namespace ShopEf.DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
        T GetRepository<T>() where T : class, IRepository;
    }
}