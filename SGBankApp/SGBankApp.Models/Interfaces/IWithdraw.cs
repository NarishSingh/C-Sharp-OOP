using SGBankApp.Models.Responses;

namespace SGBankApp.Models.Interfaces
{
    public interface IWithdraw
    {
        /// <summary>
        /// Withdraw money from an account
        /// </summary>
        /// <param name="acct">Account to update with cash withdrawal</param>
        /// <param name="amount">decimal for Money to withdraw</param>
        /// <returns>AcctDepositResponse obj with transaction state and details</returns>
        AcctWithdrawResponse Withdraw(Account acct, decimal amount);
    }
}