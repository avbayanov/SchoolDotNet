using System;
using System.Data.Entity;
using System.Linq;
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
            
            return _dbSet.Where(c => ContainsIgnoreCase(c.FirstName, term)
                                        || ContainsIgnoreCase(c.LastName, term)
                                        || ContainsIgnoreCase(c.PhoneNumber, term));
        }

        private static bool ContainsIgnoreCase(string str, string substring)
        {
            return str.IndexOf(substring, StringComparison.InvariantCultureIgnoreCase) >= 0;
        }

        public Contact GetByPhoneNumber(string phoneNumber)
        {
            return _dbSet.SingleOrDefault(c => c.PhoneNumber == phoneNumber);
        }
    }
}