using System;

namespace DvdLibrary.BLL.DAO
{
    public class LibraryDaoException : Exception
    {
        public LibraryDaoException(string? message) : base(message)
        {
        }

        public LibraryDaoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}