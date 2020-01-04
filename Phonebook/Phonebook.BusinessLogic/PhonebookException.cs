using System;

namespace Phonebook.BusinessLogic
{
    public class PhonebookException : Exception
    {
        public PhonebookException(string message) : base(message)
        {
        }
    }
}