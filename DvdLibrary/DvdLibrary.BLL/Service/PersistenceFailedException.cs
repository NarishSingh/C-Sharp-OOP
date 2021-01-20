using System;

namespace DvdLibrary.BLL.Service
{
    public class PersistenceFailedException: Exception
    {
        public PersistenceFailedException()
        {
        }

        public PersistenceFailedException(string? message) : base(message)
        {
        }

        public PersistenceFailedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}