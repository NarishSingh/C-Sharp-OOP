using System;

namespace Vars
{
    public class Person
    {
        public string name { get; set; }
        public int age { get; set; }

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
    }

    class Program
    {
        public static int add(int x, int y)
        {
            return x + y;
        }

        static void Main(string[] args)
        {
            // int unitialized; //will cause an error if we try to print
            int init = 5;

            // Console.WriteLine(unitialized);
            Console.WriteLine(init);

            // int simple = null; //will cause an error if we try to print
            int? nullable = null;

            // Console.WriteLine(simple);
            Console.WriteLine(nullable);

            //check if a nullable has a value
            int? nullableNum = 12;

            if (nullableNum.HasValue)
            {
                Console.WriteLine(nullableNum);
            }

            /*obj creation*/
            Person p = new Person("Mary", 59);
            Person p2 = p; //copies the pointer, not a new obj
            Console.WriteLine(p.name);
            Console.WriteLine(p.age);
            Console.WriteLine(p2.name);
            Console.WriteLine(p2.age);

            //expr's
            int result = 2 + 2;
            const int constant = 5; //a constant
            Console.WriteLine(result);
            Console.WriteLine(constant + constant);

            int x = 10;
            int y = 99;
            Console.WriteLine(add(x, y));

            //arrays
            int[] nums = { 3, 4 };
            Console.WriteLine(add(nums[0], nums[1]));

            //numeric literals
            int intNum = 1234;
            long longNum = 1234L;
            double pi = 3.14;
            float piFloat = 3.14F;
            decimal piDec = 3.14M;
            if (intNum is int && longNum is long && pi is double && piFloat is float && piDec is decimal)
            {
                Console.WriteLine("Suffixes works!");
            }

            //String literals
            string path1 = "c:\\My Documents\\MyFile.txt";
            string path2 = @"c:\My Documents\MyFile.txt"; //use !"" to not have to add escapes
            Console.WriteLine(path1);
            Console.WriteLine(path2);
        }
    }
}
