using System;

namespace StringManip
{
    class Program
    {
        /// <summary>
        /// Check is a string has vowels next to each other
        /// </summary>
        /// <param name="s">any string</param>
        /// <returns>true is vowels are consecutive anywhere in string, false otherwise</returns>
        public static bool HasConsecutiveVowels(string s)
        {
            //0 - next to last since we are selecting 2 at a time
            for (int i = 0; i < s.Length - 1; i++)
            {
                char current = s[i];
                char next = s[i + 1];

                if (IsVowel(current) && IsVowel(next))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Check is a character is a value, case insensitive
        /// </summary>
        /// <param name="c">char</param>
        /// <returns>true if is a upper or lower cased vowel, false otherwise</returns>
        private static bool IsVowel(char c)
        {
            switch (c)
            {
                case 'a':
                case 'A':
                case 'e':
                case 'E':
                case 'i':
                case 'I':
                case 'o':
                case 'O':
                case 'u':
                case 'U':
                    return true;
                default:
                    return false;
            }
        }

        static void Main(string[] args)
        {
            /*string formatting*/
            string name = "Thakur";
            int age = 76;

            string msg = string.Format("Hi {0}, you are {1} years old", name, age);
            Console.WriteLine(msg);

            //numeric formatting
            decimal d = 1.234M;
            decimal cash = 12.99M;
            float f = 1234.5F;
            float percent = 123456.7F;
            int eNotation = 1000000000;

            string asDecimal = string.Format("{0:G}", d);
            Console.WriteLine(asDecimal);

            string cashOut = string.Format("{0:C}", cash);
            Console.WriteLine(cashOut);

            string fixedPointOut = string.Format("{0:F}", f);
            Console.WriteLine(fixedPointOut);

            string fCommasOut = string.Format("{0:N1}", f);
            Console.WriteLine(fCommasOut);

            string percOut = string.Format("{0:P}", percent);
            Console.WriteLine(percOut);

            string eOut = string.Format("{0:E}", eNotation);
            Console.WriteLine(eOut);

            //customized
            decimal formatDec = 1.9865412376M;
            string formatDecimalCustom = string.Format("{0:00.0000}", formatDec); //prints as 01.9865
            Console.WriteLine(formatDecimalCustom);

            //align strings
            // left align two 10-character values 
            // then right align a 10 character value in currency format
            // putting a space and literal pipe character in between
            string format = "{0,-10} | {1,-10} | {2,10:C}";
            Console.WriteLine("First Name | Last Name  | Balance");
            Console.WriteLine("====================================");

            Console.WriteLine(format, "Bob", "Jones", 101.25M);
            Console.WriteLine(format, "Mary", "Moore", 2100.53M);
            Console.WriteLine(format, "Susan", "Smith", 563.77);

            //not using string.Format
            Console.WriteLine("{0} is the number to count, {0} only", 3);

            //interpolation
            string me = "Narish";
            decimal myCash = 20.750009M;
            string interpol = $"My name is {me}, and I have {myCash:C} in my wallet";
            Console.WriteLine(interpol);
            Console.WriteLine($"My name is {me}, and I have {myCash:C} in my wallet");

            int x = 5;
            int y = 99;
            Console.WriteLine($"The sum of {x} and {y} is {x + y}");

            /*more string members*/
            //.Replace(old, new) returns a string, doesn't modify original string b/c its immutable
            string hi = "hello";
            hi.Replace("e", "i"); //doesn't work
            string newHi = hi.Replace("e", "i");
            Console.WriteLine(hi);
            Console.WriteLine(newHi);

            //equality test is case sensitive
            Console.WriteLine("hello" == "Hello");
            Console.WriteLine("hello" == "hello");
            Console.WriteLine(hi.Equals(newHi));

            //find index of all e's
            string cheese = "I like cheese";
            int i = 0;
            while (true)
            {
                i = cheese.IndexOf("e", i);

                if (i == -1)
                {
                    break; //no more e's
                }
                else
                {
                    Console.WriteLine($"e at index: {i}");
                }

                i++;
            }

            //split
            string[] words = cheese.Split(' ');

            for (int j = 0; j < words.Length; j++)
            {
                Console.WriteLine(words[j]);
            }

            //split on common punctuation and remove empty entries
            string moreCheese = "I like cheese. Lots of it! I am the CHEESEMAN, MAN OF C.H.E.E.S.E";

            char[] delimiters = {',', '!', '.', ' '};
            string[] wordsOnly =
                moreCheese.Split(delimiters,
                    StringSplitOptions.RemoveEmptyEntries); //checks for all delm's + throws away empty results

            for (int j = 0; j < wordsOnly.Length; j++)
            {
                Console.WriteLine(wordsOnly[j]);
            }

            //join an arr, delimited certain ways
            int[] nums = {5, 10, 15, 20};
            Console.WriteLine(string.Join(",", nums));
            Console.WriteLine(string.Join("|", nums));

            //has consecutive vowels
            Console.WriteLine(HasConsecutiveVowels(cheese));
            Console.WriteLine(HasConsecutiveVowels(moreCheese));
            
            //print all chars and values
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            for (int j = 0; j < 255; j++)
            {
                char c = (char) j;
                Console.WriteLine("{0} -> {1}", j, c);
            }
        }
    }
}