namespace SGBankApp.Models
{
    public class Account
    {
        public string Name { get; set; }
        public string AcctNum { get; set; }
        public decimal Balance { get; set; }
        public AcctType Type { get; set; }
    }
}