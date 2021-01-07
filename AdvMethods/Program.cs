using System;
using System.Collections.Specialized;

namespace AdvMethods
{
    class Program
    {
        public static void PassByValue(int num)
        {
            num = 5;
        }

        public static void PassByValue(ref int num)
        {
            num = 5;
        }

        /*overloading*/
        public static int Add(int x, int y)
        {
            return x + y;
        }

        public static int Add(int x, int y, int z)
        {
            return x + y + z;
        }

        public static double Add(double x, double y)
        {
            return x + y;
        }

        /*output params*/
        /// <summary>
        /// Try to parse a string for a number
        /// </summary>
        /// <param name="s">any string</param>
        /// <param name="val">if string represents a parsable numeric value, val will be outputted as that value. If parse fails, val is set to minimum</param>
        /// <returns>true if parsed, false otherwise</returns>
        public static bool TryParse(string s, out int val)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (!char.IsDigit(s[i]))
                {
                    //non-digit found - set val to minimum value and return false
                    val = int.MinValue;
                    return false;
                }
            }

            val = int.Parse(s);
            return true;
        }

        /*optional params*/
        /// <summary>
        /// Sum up to 3 numbers with optional params
        /// </summary>
        /// <param name="x">required int for call</param>
        /// <param name="y">optionally initialized to 0</param>
        /// <param name="z">optionally initialized to 0</param>
        /// <returns>int - the sum of the 1-3 integers</returns>
        public static int AddOpt(int x, int y = 0, int z = 0)
        {
            return x + y + z;
        }

        /*params keyword*/
        /// <summary>
        /// Sum up any number of integers
        /// </summary>
        /// <param name="nums"> any amount of integers</param>
        /// <returns>int - the sum of all parameterized integers in call</returns>
        public static int Sum(params int[] nums)
        {
            if (nums.Length < 1)
            {
                return 0;
            }

            int sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
            }

            return sum;
        }

        /*recursion*/
        /// <summary>
        /// Compute the factorial recursively
        /// </summary>
        /// <param name="n">int - num to find the factorial of</param>
        /// <returns>int - the result of n!</returns>
        public static int Factorial(int n)
        {
            if (n <= 1)
            {
                return n;
            }
            else
            {
                return n * Factorial(n - 1);
            }
        }

        static void Main(string[] args)
        {
            Circle c = new Circle(10);
            Console.WriteLine(c.getArea());
            Console.WriteLine(Circle.pi);

            //ref keyword - not sure when this is useful...but ok
            int x = 1;

            PassByValue(x);
            Console.WriteLine(x);

            PassByValue(
                ref x); //ref allows changes within the method to be accessible outside of the methods scope -> here it allowed reassignment
            Console.WriteLine(x);

            //overloading
            Console.WriteLine(Add(1, 2));
            Console.WriteLine(Add(1.1, 2.6));
            Console.WriteLine(Add(1, 2, 6));
            Console.WriteLine(Add(x: 1, y: 2, z: 6)); //named params

            //output params
            string input = "hello";
            int output;

            if (!TryParse(input, out output))
            {
                Console.WriteLine($"{input} could not be converted.");
                Console.WriteLine(output);
            }

            string input2 = "52";
            if (TryParse(input2, out output))
            {
                Console.WriteLine($"{input} was converted to {output}");
            }

            //optional params
            Console.WriteLine(AddOpt(10));
            Console.WriteLine(AddOpt(10, 10));
            Console.WriteLine(AddOpt(10, 10, 10));

            //params key word
            Console.WriteLine(Sum(5));
            Console.WriteLine(Sum(5, 10));
            Console.WriteLine(Sum(5, 10, 15));

            //recursion
            Console.WriteLine(Factorial(9));
        }
    }
}