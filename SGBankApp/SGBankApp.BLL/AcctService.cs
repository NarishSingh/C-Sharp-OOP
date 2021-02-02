using SGBankApp.BLL.DepositRules;
using SGBankApp.BLL.WithdrawalRules;
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

        public AcctDepositResponse Deposit(string acctNum, decimal amount)
        {
            AcctDepositResponse rsp = new AcctDepositResponse
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

            IDeposit depositRule = DepositRulesFactory.Create(rsp.Acct.Type);
            rsp = depositRule.Deposit(rsp.Acct, amount);

            if (rsp.Success)
            {
                _acctRepo.SaveAcct(rsp.Acct);
            }
            
            return rsp;
        }

        public AcctWithdrawResponse Withdraw(string acctNum, decimal amount)
        {
            AcctWithdrawResponse rsp = new AcctWithdrawResponse
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

            IWithdraw withdrawRules = WithdrawalRulesFactory.Create(rsp.Acct.Type);
            rsp = withdrawRules.Withdraw(rsp.Acct, amount);

            if (rsp.Success)
            {
                _acctRepo.SaveAcct(rsp.Acct);
            }
            
            return rsp;
        }
    }
}