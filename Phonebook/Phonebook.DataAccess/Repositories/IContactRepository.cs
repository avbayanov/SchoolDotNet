using System.Linq;
using Phonebook.DataAccess.Models;

namespace Phonebook.DataAccess.Repositories
{
    public interface IContactRepository : IRepository<Contact>
    {
        IQueryable<Contact> Search(string term);

        Contact GetByPhoneNumber(string phoneNumber);
    }
}