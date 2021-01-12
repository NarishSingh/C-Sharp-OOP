namespace Factorizer2.BLL
{
    public class PrimeChecker
    {
        public static bool IsPrime(int n)
        {
            return FactorFinder.FactorsOf(n).Length == 1; //we omit n as a factor from list
        }
    }
}