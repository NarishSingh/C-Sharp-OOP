using SGBank.BLL;
using SGBank.UI.View;

namespace SGBank.UI
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