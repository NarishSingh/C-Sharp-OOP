using System;
using System.Collections;
using System.Collections.Generic;

namespace Ex1Factorizer
{
    public class Calculator
    {
        /// <summary>
        /// Given a number, print the factors
        /// </summary>
        /// <param name="number">int</param>
        public static void PrintFactors(int number)
        {
            for (int i = 1; i < number; i++)
            {
                if (number % i == 0)
                {
                    Console.Write($"{i} ");
                }
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Given a number, print if it is perfect or not
        /// </summary>
        /// <param name="number">int</param>
        public static void IsPerfectNumber(int number)
        {
            int sum = 0;

            for (int i = 1; i < number; i++)
            {
                if (number % i == 0)
                {
                    sum += i;
                }
            }

            Console.WriteLine($"Is a perfect number: {sum == number}");
        }

        /// <summary>
        /// Given a number, print if it is prime or not
        /// </summary>
        /// <param name="number">int</param>
        public static void IsPrimeNumber(int number)
        {
            ArrayList fctList = new ArrayList();

            for (int i = 1; i < number; i++)
            {
                if (number % i == 0)
                {
                    fctList.Add(i);
                }
            }

            Console.WriteLine($"Is Prime: {fctList.Count == 2}");
        }
    }
}