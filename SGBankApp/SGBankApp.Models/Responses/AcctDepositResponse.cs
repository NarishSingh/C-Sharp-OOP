namespace SGBankApp.Models.Responses
{
    public class AcctDepositResponse : Response
    {
        public Account Acct { get; set; }
        public decimal Deposit { get; set; }
        public decimal OldBalance { get; set; }
    }
}