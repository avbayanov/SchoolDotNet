using System;
using System.Linq.Expressions;
using Phonebook.Contracts;
using Phonebook.DataAccess.Models;

namespace Phonebook.BusinessLogic
{
    public static class MappingExpressions
    {
        public static Expression<Func<Contact, ContactDto>> ContactExpression()
        {
            return contact => new ContactDto
            {
                Id = contact.Id,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                PhoneNumber = contact.PhoneNumber
            };
        }
    }
}