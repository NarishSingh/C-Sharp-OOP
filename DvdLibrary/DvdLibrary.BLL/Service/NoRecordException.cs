using System;

namespace DvdLibrary.BLL.Service
{
    public class NoRecordException: Exception
    {
        public NoRecordException()
        {
        }

        public NoRecordException(string? message) : base(message)
        {
        }

        public NoRecordException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}