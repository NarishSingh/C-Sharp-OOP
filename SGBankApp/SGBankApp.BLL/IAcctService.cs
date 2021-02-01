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
    }
}