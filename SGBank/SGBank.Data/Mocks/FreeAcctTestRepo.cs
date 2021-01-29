using SGBank.Models;
using SGBank.Models.Interfaces;

namespace SGBank.Data.Stubs
{
    /**
     * Mock Repo is just like a stub class, just hard code data
     */
    public class FreeAcctTestRepo : IAccountRepo
    {
        private static Account _acct = new Account
        {
            Name = "Free Account",
            Balance = 100.00M,
            AcctNum = "12345",
            Type = AccountType.Free
        }; //make the data static and private to mimic load from file when mocking
        
        public Account ReadAccount(string accNum)
        {
            return _acct;
        }

        public Account CreateAccount(Account acct)
        {
            _acct = acct;
            return _acct;
        }
    }
}