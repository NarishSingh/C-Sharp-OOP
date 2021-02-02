using SGBankApp.Models;
using SGBankApp.Models.Interfaces;
using SGBankApp.Models.Responses;

namespace SGBankApp.BLL.DepositRules
{
    public class FreeAcctDeposit : IDeposit
    {
        public AcctDepositResponse Deposit(Account acct, decimal amount)
        {
            AcctDepositResponse rsp = new AcctDepositResponse();

            if (acct.Type != AcctType.Free)
            {
                rsp.Success = false;
                rsp.Msg = "Error: Non-Free Account hit Free Dep rules, contact IT.";
            }

            //free = cannot deposit more than $100 a day
            if (amount > 100)
            {
                rsp.Success = false;
                rsp.Msg = "Free Account maximum deposit limit exceeded. Please deposit $100 or less.";
            }
            else if (amount <= 0)
            {
                rsp.Success = false;
                rsp.Msg = "Deposit amount must be over $0.00.";
            }
            else
            {
                rsp.OldBalance = acct.Balance;
                acct.Balance += amount;
                rsp.Acct = acct;
                rsp.Deposit = amount;
                rsp.Success = true;
            }

            return rsp;
        }
    }
}