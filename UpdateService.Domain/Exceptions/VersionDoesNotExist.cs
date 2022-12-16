using System;

namespace UpdateService.Domain.Exceptions
{
    public class NoHigherVersionFoundException : Exception
    {
        public NoHigherVersionFoundException()
        {
        }

        public NoHigherVersionFoundException(string message) : base(message)
        {
        }

        public NoHigherVersionFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
