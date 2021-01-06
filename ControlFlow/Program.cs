using System;

namespace ControlFlow
{
    class Program
    {

        /// <summary>
        /// Get an odd number from user input
        /// </summary>
        /// <returns>int - an odd number</returns>
        public static int getOdd()
        {
            string input;
            int output;

            //while loop to get numbers from user
            while (true)
            {
                Console.Write("Enter an odd number: ");
                input = Console.ReadLine();

                //try to parse to int
                if (int.TryParse(input, out output))
                {
                    if (output % 2 == 0)
                    {
                        Console.WriteLine("That is not a an odd number...");
                        continue; //try again
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    // Console.WriteLine("That is not a number");
                    throw new Exception("Not a number!"); //using an exception
                }
            }

            return output;
        }
        static void Main(string[] args)
        {
            int x = 5;
            int y = 10;

            //order matters in an else if
            if (x < 20 && y < 15)
            {
                Console.WriteLine("Both values < 20");
            }
            else if (x < 15 && y < 15)
            {
                Console.WriteLine("Both < 15");
            }
            else if (x < 10 && y < 10)
            {
                Console.WriteLine("Both < 10");
            }
            else
            {
                Console.WriteLine("Numbers are small");
            }

            //switch
            int a = 2;

            switch (a)
            {
                case 0:
                    Console.WriteLine("a is 0");
                    break;
                case 1:
                case 2:
                case 3:
                    Console.WriteLine("x is 1 2 or 3 b/c we fell through the switch lol");
                    break;
                default:
                    Console.WriteLine("Nothing");
                    break;
            }

            //while
            int b = 1;

            while (b < 4)
            {
                Console.WriteLine(b++);
            }

            do
            {
                Console.WriteLine(b++);
            } while (b < 10);


            //for
            for (int i = 0; i < 10; i++)
            {
                Console.Write($"{i}"); //template literal for a var
            }

            //we can access chars of a string without dumping to a char array
            Console.WriteLine();

            string s = "hello";

            for (int i = 0; i < s.Length; i++)
            {
                char current = s[i];

                //pring the vowel
                switch (current)
                {
                    case 'a':
                    case 'e':
                    case 'i':
                    case 'o':
                    case 'u':
                        Console.WriteLine(current);
                        break;
                }
            }

            Console.WriteLine(DateTime.Today);

            //a method with control flow
            while (true)
            {
                try
                {
                    Console.WriteLine($"Your number is {getOdd()}");
                    break;
                }
                catch (System.Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}
