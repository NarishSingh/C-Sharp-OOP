using System;
using System.Configuration;
using SGBankApp.Data.Stubs;

namespace SGBankApp.BLL
{
    public static class AcctServiceFactory
    {
        public static AcctService Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"];

            switch (mode)
            {
                case "FreeTest":
                    return new AcctService(new FreeAcctTestRepo());
                default:
                    throw new Exception("Mode value in app config is not valid");
            }
        }
    }
}