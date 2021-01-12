using System;
using Factorizer2.BLL;

namespace Factorizer2.UI
{
    public class Controller
    {
        public void Run()
        {
            bool running;

            ConsoleOutput.DisplayWelcome();
            do
            {
                Console.Clear();
                int n = ConsoleInput.ReadInt();

                Console.WriteLine($"Factors = {string.Join(", ", FactorFinder.FactorsOf(n))}");
                Console.WriteLine($"Perfect Number? : {PerfectChecker.IsPerfect(n)}");
                Console.WriteLine($"Prime Number? : {PrimeChecker.IsPrime(n)}");
                
                running = ConsoleOutput.ExitPrompt();
            } while (running);
        }
    }
}