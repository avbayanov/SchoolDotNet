using System.Collections.Generic;
using System.Linq;
using Phonebook.Contracts;
using Phonebook.DataAccess;
using Phonebook.DataAccess.Repositories;

namespace Phonebook.BusinessLogic
{
    public class ContactsHandlers : IContactsHandlers
    {
        private readonly IUnitOfWork _unitOfWork;

        public ContactsHandlers(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<ContactDto> Get(string term)
        {
            var repository = _unitOfWork.GetRepository<IContactRepository>();

            return repository.Search(term)
                .Select(MappingExpressions.ContactExpression())
                .ToList();
        }

        private static void ValidateContact(ContactDto contact)
        {
            if (string.IsNullOrEmpty(contact.FirstName))
            {
                throw new PhonebookException("First name must be filled");
            }

            if (string.IsNullOrEmpty(contact.LastName))
            {
                throw new PhonebookException("Last name must be filled");
            }

            if (string.IsNullOrEmpty(contact.PhoneNumber))
            {
                throw new PhonebookException("Phone number must be filled");
            }
        }

        public void Create(ContactDto contact)
        {
            ValidateContact(contact);
            
            _unitOfWork.BeginTransaction();

            var repository = _unitOfWork.GetRepository<IContactRepository>();

            if (repository.GetByPhoneNumber(contact.PhoneNumber) != null)
            {
                throw new PhonebookException("Contact with this phone number already exists");
            }

            repository.Create(contact.ToEntity());

            _unitOfWork.Save();
        }

        public void Remove(List<int> ids)
        {
            _unitOfWork.BeginTransaction();

            var repository = _unitOfWork.GetRepository<IContactRepository>();

            foreach (var id in ids)
            {
                var contact = repository.GetById(id);
                repository.Delete(contact);
            }

            _unitOfWork.Save();
        }
    }
}