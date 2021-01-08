using System;
using System.Threading.Channels;

namespace StringInput
{
    class Program
    {
        static void Main(string[] args)
        {
            /*input validation*/
            string userText;

            while (true)
            {
                Console.WriteLine("Enter something: ");
                userText = Console.ReadLine();

                //verify if text was entered
                if (string.IsNullOrEmpty(userText))
                {
                    Console.WriteLine("Nothing entered...");
                }
                else
                {
                    break;
                }
            }
            
            //tryparse
            int numOut;
            while (true)
            {
                Console.WriteLine("Enter a whole number:");
                string input = Console.ReadLine();

                //returns a bool, but will
                if (int.TryParse(input, out numOut))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Not a whole num...");
                }
            }

            Console.WriteLine($"You entered: {numOut}");
        }
    }
}