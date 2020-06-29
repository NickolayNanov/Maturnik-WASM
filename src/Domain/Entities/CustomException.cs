using Maturnik.Domain.Common;

namespace Maturnik.Domain.Entities
{
    public class CustomException : BaseEntity<int>
    {
        public CustomException()
        {

        }

        public CustomException(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }
}
