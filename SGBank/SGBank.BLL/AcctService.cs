using SGBank.Models.Interfaces;
using SGBank.Models.Responses;

namespace SGBank.BLL
{
    public class AcctService
    {
        private IAcctRepo _acctRepo;

        public AcctService(IAcctRepo acctRepo)
        {
            _acctRepo = acctRepo;
        }

        /// <summary>
        /// Look up an Account by its id
        /// </summary>
        /// <param name="acctNum">string for the account number</param>
        /// <returns>AcctLookupResponse with the proper success flag, Account obj if successfull, or error message if failed</returns>
        public AcctLookupResponse LookupAcct(string acctNum)
        {
            AcctLookupResponse rsp = new AcctLookupResponse
            {
                Acct = _acctRepo.ReadAcctById(acctNum)
            };

            if (rsp.Acct == null)
            {
                rsp.Success = false;
                rsp.Msg = $"{acctNum} is not a valid account.";
            }
            else
            {
                rsp.Success = true;
            }

            return rsp;
        }
    }
}