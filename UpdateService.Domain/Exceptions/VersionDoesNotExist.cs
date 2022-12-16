using System;

namespace UpdateService.Domain.Exceptions
{
    public class VersionDoesNotExistException : Exception
    {
        public VersionDoesNotExistException()
        {
        }

        public VersionDoesNotExistException(string message) : base(message)
        {
        }

        public VersionDoesNotExistException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
