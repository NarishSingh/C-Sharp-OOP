using System.Collections;

namespace Factorizer2.BLL
{
    public class FactorFinder
    {
        /// <summary>
        /// Find factors of an integer
        /// </summary>
        /// <param name="n">Any integer</param>
        /// <returns>array of all factors</returns>
        public static int[] FactorsOf(int n)
        {
            ArrayList fcts = new ArrayList();

            for (int i = 1; i < n; i++)
            {
                if (n % i == 0)
                {
                    fcts.Add(i);
                }
            }

            return fcts.ToArray(typeof(int)) as int[];
        }
    }
}