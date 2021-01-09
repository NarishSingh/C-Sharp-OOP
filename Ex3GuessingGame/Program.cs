using System;

namespace Ex3GuessingGame
{
    class Program
    {
        /// <summary>
        /// Get a number from user or quit the game
        /// </summary>
        /// <param name="playing">output param for the user to quit the game</param>
        /// <returns>the parsed number for guess, or 0 and activated boolean flag to quit the gameplay loop</returns>
        static int GetNum(out bool playing)
        {
            int output = 0;

            Console.WriteLine("Enter an integer: ");

            while (true)
            {
                string input = Console.ReadLine();

                //allow quit
                if (input.Equals("q") || input.Equals("Q"))
                {
                    playing = false;
                    return output;
                }

                //if not quitting, parse the nummber
                if (int.TryParse(input, out output))
                {
                    playing = true;
                    return output;
                }

                //error msg
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Not an integer...");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        static void Main(string[] args)
        {
            Random r = new Random();
            int num = 1;
            bool guessing = true;
            bool levelSelected = false;
            int attempts = 0;
            //bounds
            int lower = 1;
            int higher = 0;

            //name and difficulty
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Choose difficulty level\n1 - Easy\n2 - Medium\n3 - Hard");
            while (!levelSelected)
            {
                string level = Console.ReadLine();

                if (level.Equals("1"))
                {
                    Console.WriteLine("I'm thinking of a number between 1 and 5...");
                    num = r.Next(5);
                    higher = 5;
                    levelSelected = true;
                }
                else if (level.Equals("2"))
                {
                    Console.WriteLine("I'm thinking of a number between 1 and 20...");
                    num = r.Next(21);
                    higher = 20;
                    levelSelected = true;
                }
                else if (level.Equals("3"))
                {
                    Console.WriteLine("I'm thinking of a number between 1 and 50...");
                    num = r.Next(51);
                    higher = 50;
                    levelSelected = true;
                }
                else
                {
                    Console.WriteLine("Please select your difficulty level");
                }
            }

            //gameplay
            Console.WriteLine("Start guessing! (Q to quit)");
            while (guessing)
            {
                int guess = GetNum(out guessing); //get number or quit game

                if (guessing)
                {
                    if (guess < lower || guess > higher)
                    {
                        //out of bounds error
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Out of bounds");
                        Console.ForegroundColor = ConsoleColor.White;
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
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("!!!You win!!!");
                        Console.WriteLine(attempts == 0
                            ? $"{name} aced it!!!"
                            : $"{name} made {attempts} guesses before winning"); //special msg if guessed on first try
                        Console.ForegroundColor = ConsoleColor.White;
                        guessing = false;
                    }

                    attempts++;
                }
            }

            Console.WriteLine("Thank you for playing!");
        }
    }
}