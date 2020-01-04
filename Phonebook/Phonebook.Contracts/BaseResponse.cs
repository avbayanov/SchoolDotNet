namespace Phonebook.Contracts
{
    public class BaseResponse
    {
        public bool IsSuccess { get; set; }
        
        public string Message { get; set; }
    }
}