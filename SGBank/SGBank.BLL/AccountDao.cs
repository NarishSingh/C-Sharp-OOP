using SGBank.Models.Interfaces;
using SGBank.Models.Responses;

namespace SGBank.BLL
{
    public class AccountDao
    {
        private IAccountRepo _acctRepo;

        /**
         * DI here for ctor injection
         */
        public AccountDao(IAccountRepo acctRepo)
        {
            _acctRepo = acctRepo;
        }

        /**
         * Look up an account in account repo
         */
        public AccountLookupResponse LookupAccount(string acctNum)
        {
            AccountLookupResponse resp = new AccountLookupResponse();

            resp.Acct = _acctRepo.ReadAccount(acctNum);

            if (resp.Acct == null)
            {
                resp.Success = false;
                resp.Msg = $"{acctNum} is not a valid account.";
            }
            else
            {
                resp.Success = true;
            }

            return resp;
        }
    }
}