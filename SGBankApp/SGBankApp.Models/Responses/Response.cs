namespace SGBankApp.Models.Responses
{
    /// <summary>
    /// All responses will inherit this parent
    /// </summary>
    public class Response
    {
        public bool Success { get; set; }
        public string Msg { get; set; }
    }
}