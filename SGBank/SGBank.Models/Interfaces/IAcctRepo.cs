namespace SGBank.Models.Interfaces
{
    public interface IAcctRepo
    {
        /// <summary>
        /// Load an Account by its account number
        /// </summary>
        /// <param name="acctNum">string representing the account number id</param>
        /// <returns>Account at this id</returns>
        Account ReadAcctById(string acctNum);

        /// <summary>
        /// Save an Account
        /// </summary>
        /// <param name="acct">Well formed Account obj</param>
        void SaveAcct(Account acct);
    }
}