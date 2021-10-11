using System;

namespace Ebanx.Infrastructure.Exceptions
{
    public class InvalidAccountException : Exception
    {
        public InvalidAccountException()
        {
        }

        public InvalidAccountException(string message) : base(message)
        {
        }
    }
}
