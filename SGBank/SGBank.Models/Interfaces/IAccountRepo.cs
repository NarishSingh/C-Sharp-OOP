namespace SGBank.Models.Interfaces
{
    public interface IAccountRepo
    {
        Account ReadAccount(string accNum);

        Account CreateAccount(Account acct);
    }
}