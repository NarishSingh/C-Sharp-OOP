using SGBankApp.Models.Responses;

namespace SGBankApp.Models.Interfaces
{
    public interface IDeposit
    {
        /// <summary>
        /// Deposit money to an account
        /// </summary>
        /// <param name="acct">Account to update with cash deposit</param>
        /// <param name="amount">decimal for Money to deposit</param>
        /// <returns>AcctDepositResponse obj with transaction state and details</returns>
        AcctDepositResponse Deposit(Account acct, decimal amount);
    }
}