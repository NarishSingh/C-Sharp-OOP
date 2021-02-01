using SGBankApp.Models.Interfaces;
using SGBankApp.Models.Responses;

namespace SGBankApp.BLL
{
    public class AcctService : IAcctService
    {
        private IAcctRepo _acctRepo;

        public AcctService(IAcctRepo acctRepo)
        {
            _acctRepo = acctRepo;
        }
        
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