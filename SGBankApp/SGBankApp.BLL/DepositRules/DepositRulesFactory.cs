using System;
using SGBankApp.Models;
using SGBankApp.Models.Interfaces;

namespace SGBankApp.BLL.DepositRules
{
    public class DepositRulesFactory
    {
        public static IDeposit Create(AcctType type)
        {
            switch (type)
            {
                case AcctType.Free:
                    return new FreeAcctDeposit();
                default:
                    throw new Exception("Account type not supported.");
            }
        }
    }
}