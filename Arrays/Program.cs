using System;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            //1D arrs
            int[] arr1 = new int[4];
            // int[] arr2 = new int[]{1, 2, 3, 4};
            int[] arr3 = {1, 2, 3, 4}; //shorthand init

            //2D
            int[,] table1 = new int[2, 3];
            // int[,] table2 =  new int[,] { { 5, 3, 1 }, { 2, 4, 6 } };
            int[,] table2 = {{5, 3, 1}, {2, 4, 6}}; //shorthand init

            //jagged 2D
            int[][] jagged = new int[3][]; //omit len that is variable
            jagged[0] = new[] {1, 2};
            jagged[1] = new[] {3, 4, 5, 6};
            jagged[2] = new[] {7, 8, 9};

            Console.WriteLine(arr1[2]);
            Console.WriteLine(arr3[0]);
            // Console.WriteLine(arr3[arr3.Length-1]);
            Console.WriteLine(arr3[^1]); //one back from end of arr
            Console.WriteLine(arr3[^2]); //two back from end of arr

            //iterating
            int sum = 0;
            for (int i = 0; i < arr3.Length; i++)
            {
                sum += arr3[i];
                Console.WriteLine($"i={i}, current sum={sum}");
            }

            Console.WriteLine($"Final sum = {sum}");

            //reverse for loop
            for (int i = arr3.Length - 1; i >= 0; i--)
            {
                if (i % 2 == 0)
                {
                    continue;
                }
                else
                {
                    Console.WriteLine($"index {i} - {arr3[i]}");
                }
            }

            int[] numbers = {1, 2, 3, 4, 5, 6};
            for (int i = 0; i < arr3.Length; i += 3)
            {
                Console.WriteLine($"Pair: {numbers[i]}, {numbers[i + 1]}");
            }

            //iterating through a string can be done without dumping to char[]
            string s = "wassup";
            for (int i = 0; i < s.Length; i++)
            {
                Console.WriteLine(s[i]);
            }
        }
    }
}