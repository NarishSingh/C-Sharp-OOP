using System;

namespace DvdLibrary.BLL.DAO
{
    public class LibraryDaoException : Exception
    {
        #nullable enable
        public LibraryDaoException(string? message) : base(message)
        {
        }
        
        #nullable enable
        public LibraryDaoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}