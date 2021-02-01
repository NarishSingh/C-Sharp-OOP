using SGBankApp.BLL;
using SGBankApp.UI.View;

namespace SGBankApp.UI
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            BankController c = new BankController(AcctServiceFactory.Create(), new BankView());
            c.Run();
        }
    }
}