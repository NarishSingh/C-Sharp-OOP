using System;

namespace ConsoleUtilities.BLL
{
    public class UserInput
    {
        public static int ReadInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string inp = Console.ReadLine();

                int result;
                if (int.TryParse(inp, out result))
                {
                    return result;
                }

                Console.WriteLine("Not an integer.");
            }
        }
    }
}