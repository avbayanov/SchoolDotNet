using System.Collections.Generic;
using Phonebook.Contracts;

namespace Phonebook.BusinessLogic
{
    public interface IContactsHandlers
    {
        List<ContactDto> Get(string term);

        void Create(ContactDto contact);

        void Remove(List<int> ids);
    }
}