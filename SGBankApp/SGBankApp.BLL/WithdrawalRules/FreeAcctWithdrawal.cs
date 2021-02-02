using SGBankApp.Models;
using SGBankApp.Models.Interfaces;
using SGBankApp.Models.Responses;

namespace SGBankApp.BLL.WithdrawalRules
{
    public class FreeAcctWithdrawal : IWithdraw
    {
        public AcctWithdrawResponse Withdraw(Account acct, decimal amount)
        {
            AcctWithdrawResponse rsp = new AcctWithdrawResponse();

            if (acct.Type != AcctType.Free)
            {
                rsp.Success = false;
                rsp.Msg = "Error: Non-Free Account hit Free Withdrawal rules, contact IT.";
            }

            //free = cannot withdraw more than $100 at a time
            if (amount > acct.Balance)
            {
                rsp.Success = false;
                rsp.Msg =
                    "Withdraw request exceeds balance. Please withdraw a cash amount equal to or lower than the balance, and under $100";
            }
            else if (amount > 100)
            {
                rsp.Success = false;
                rsp.Msg = "Free Account maximum withdraw limit exceeded. Please withdraw $100 or less.";
            }
            else if (amount <= 0)
            {
                rsp.Success = false;
                rsp.Msg = "Withdrawal amount must be over $0.00.";
            }
            else
            {
                rsp.OldBalance = acct.Balance;
                acct.Balance -= amount;
                rsp.Acct = acct;
                rsp.Withdrawal = amount;
                rsp.Success = true;
            }

            return rsp;
        }
    }
}