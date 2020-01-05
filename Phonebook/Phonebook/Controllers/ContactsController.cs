using System.Collections.Generic;
using System.Web.Http;
using Phonebook.BusinessLogic;
using Phonebook.Contracts;

namespace Phonebook.Controllers
{
    public class ContactsController : ApiController
    {
        private readonly IContactsHandlers _contactsHandlers;

        public ContactsController(IContactsHandlers contactsHandlers)
        {
            _contactsHandlers = contactsHandlers;
        }

        [HttpGet]
        public List<ContactDto> Get(string term)
        {
            return _contactsHandlers.Get(term);
        }

        [HttpPost]
        public BaseResponse Create(ContactDto contact)
        {
            try
            {
                _contactsHandlers.Create(contact);

                return new BaseResponse
                {
                    IsSuccess = true
                };
            }
            catch (PhonebookException e)
            {
                return new BaseResponse
                {
                    IsSuccess = false,
                    Message = e.Message
                };
            }
        }

        [HttpPost]
        public BaseResponse Remove([FromBody] List<int> ids)
        {
            try
            {
                _contactsHandlers.Remove(ids);

                return new BaseResponse
                {
                    IsSuccess = true
                };
            }
            catch (PhonebookException e)
            {
                return new BaseResponse
                {
                    IsSuccess = false,
                    Message = e.Message
                };
            }
        }
    }
}
