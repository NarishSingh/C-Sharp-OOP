using System;

namespace Ex3GuessingGame
{
    class Program
    {
        /// <summary>
        /// Get a number from user or quit the game
        /// </summary>
        /// <param name="playing">output param for the user to quit the game</param>
        /// <returns></returns>
        static int GetNum(out bool playing)
        {
            int output = 0;

            Console.WriteLine("Enter an integer: ");

            while (true)
            {
                string input = Console.ReadLine();

                if (input.Equals("q") || input.Equals("Q"))
                {
                    playing = false;
                    return output;
                }

                if (int.TryParse(input, out output))
                {
                    playing = true;
                    return output;
                }

                Console.WriteLine("Not an integer...");
            }
        }

        static void Main(string[] args)
        {
            Random r = new Random();
            int num = r.Next(21);
            bool guessing = true;
            int attempts = 0;

            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine("I'm thinking of a number between 1 and 20...");
            Console.WriteLine("Start guessing! (Q to quit)");

            while (guessing)
            {
                int guess = GetNum(out guessing);

                if (guessing)
                {
                    if (guess < 1 || guess > 20)
                    {
                        Console.WriteLine("Out of bounds");
                    }
                    else if (guess > num)
                    {
                        Console.WriteLine("Too high!");
                    }
                    else if (guess < num)
                    {
                        Console.WriteLine("Too low!");
                    }
                    else
                    {
                        Console.WriteLine("!!!You win!!!");
                        Console.WriteLine($"{name} made {attempts} guesses before winning");
                        guessing = false;
                    }

                    attempts++;
                }
            }
        }
    }
}