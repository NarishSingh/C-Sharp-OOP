using SGBankApp.Models.Responses;

namespace SGBankApp.BLL
{
    public interface IAcctService
    {
        /// <summary>
        /// Look up an Account by its id
        /// </summary>
        /// <param name="acctNum">string for the account number</param>
        /// <returns>AcctLookupResponse with the proper success flag, Account obj if successful, or error message if failed</returns>
        AcctLookupResponse LookupAcct(string acctNum);

        /// <summary>
        /// Make a deposit to an existing Account
        /// </summary>
        /// <param name="acctNum">string for the account number</param>
        /// <param name="amount">decimal with the cash amount to deposit</param>
        /// <returns>AcctDepositResponse with proper success flag and transaction details</returns>
        AcctDepositResponse Deposit(string acctNum, decimal amount);

        /// <summary>
        /// Make a withdrawal from an existing Account
        /// </summary>
        /// <param name="acctNum">string for the account number</param>
        /// <param name="amount">decimal with the cash amount to withdraw</param>
        /// <returns>AcctWithdrawResponse with proper success flag and transaction details</returns>
        AcctWithdrawResponse Withdraw(string acctNum, decimal amount);
    }
}