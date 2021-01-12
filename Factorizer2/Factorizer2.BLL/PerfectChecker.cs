namespace Factorizer2.BLL
{
    public class PerfectChecker
    {
        /// <summary>
        /// Verify if parameterized int is a perfect number, where all factors sum up to the number
        /// </summary>
        /// <param name="n">int</param>
        /// <returns>true if number is perfect, false otherwise</returns>
        public static bool IsPerfect(int n)
        {
            int[] fctArr = FactorFinder.FactorsOf(n);
            int sum = 0;

            foreach (int f in fctArr)
            {
                sum += f;
            }

            return sum == n;
        }
    }
}