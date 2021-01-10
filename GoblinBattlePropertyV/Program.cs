using System;

namespace GoblinBattlePropertyV
{
    class Program
    {
        static void Main(string[] args)
        {
            Goblin g1 = new Goblin();
            g1.Name = "Bob";
            g1.HitPoints = 10;

            //obj initializer
            Goblin g2 = new Goblin {Name = "Tom", HitPoints = 10};

            int whoseTurn = 1;

            while (!g1.Dead && !g2.Dead)
            {
                if (whoseTurn == 1)
                {
                    g1.Atk(g2);
                    whoseTurn = 2;
                }
                else
                {
                    g2.Atk(g1);
                    whoseTurn = 1;
                }
            }

            Console.WriteLine("The battle has ended!");
            Console.WriteLine(g1.Dead
                ? $"{g2.Name} has won!"
                : $"{g1.Name} has won!");
        }
    }
}