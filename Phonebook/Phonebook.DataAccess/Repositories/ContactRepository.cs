using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Phonebook.DataAccess.Models;

namespace Phonebook.DataAccess.Repositories
{
    public class ContactRepository : BaseEfRepository<Contact>, IContactRepository
    {
        public ContactRepository(DbContext db) : base(db)
        {
        }

        public IQueryable<Contact> Search(string term)
        {
            if (string.IsNullOrEmpty(term))
            {
                return _dbSet;
            }
            
            return _dbSet.Where(c => c.FirstName.Contains(term) 
                                     || c.LastName.Contains(term) 
                                     || c.PhoneNumber.Contains(term));
        }

        public Contact GetByPhoneNumber(string phoneNumber)
        {
            return _dbSet.SingleOrDefault(c => c.PhoneNumber == phoneNumber);
        }
    }
}