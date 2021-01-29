using System;

namespace SGBank.Models.Responses
{
    /**
     * Wrapper class for the BLL
     */
    public class Response
    {
        public bool Success { get; set; }
        public String Msg { get; set; }
    }
}