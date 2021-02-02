using System;
using SGBankApp.Models;
using SGBankApp.Models.Interfaces;

namespace SGBankApp.BLL.WithdrawalRules
{
    public class WithdrawalRulesFactory
    {
        public static IWithdraw Create(AcctType type)
        {
            switch (type)
            {
                case AcctType.Free:
                    return new FreeAcctWithdrawal();
                default:
                    throw new Exception("Account type not supported");
            }
        }
    }
}