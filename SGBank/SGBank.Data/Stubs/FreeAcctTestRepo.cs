using SGBank.Models;
using SGBank.Models.Interfaces;

namespace SGBank.Data.Stubs
{
    public class FreeAcctTestRepo : IAcctRepo
    {
        private static Account _acct = new Account
        {
            Name = "Free Acct",
            Balance = 100.00M,
            AcctNum = "12345",
            Type = AcctType.Free
        };

        public Account ReadAcctById(string acctNum)
        {
            return _acct;
        }

        public void SaveAcct(Account acct)
        {
            _acct = acct;
        }
    }
}