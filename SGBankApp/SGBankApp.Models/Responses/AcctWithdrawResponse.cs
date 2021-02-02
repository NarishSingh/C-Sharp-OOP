namespace SGBankApp.Models.Responses
{
    public class AcctWithdrawResponse : Response
    {
        public Account Acct { get; set; }
        public decimal Withdrawal { get; set; }
        public decimal OldBalance { get; set; }
    }
}