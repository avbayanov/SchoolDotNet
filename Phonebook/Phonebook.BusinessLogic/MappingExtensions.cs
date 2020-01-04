using Phonebook.Contracts;
using Phonebook.DataAccess.Models;

namespace Phonebook.BusinessLogic
{
    public static class MappingExtensions
    {
        public static Contact ToEntity(this ContactDto contact)
        {
            return new Contact
            {
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                PhoneNumber = contact.PhoneNumber
            };
        }
    }
}