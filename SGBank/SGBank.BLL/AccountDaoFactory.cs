using System;
using System.Configuration;
using SGBank.Data.Mocks;

namespace SGBank.BLL
{
    public static class AccountDaoFactory
    {
        public static AccountDao Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"]; //TODO this is returning null

            switch (mode)
            {
                case "FreeTest":
                    return new AccountDao(new FreeAcctTestRepo());
                default:
                    throw new Exception("Mode value in app.config not valid");
            }
        }
    }
}