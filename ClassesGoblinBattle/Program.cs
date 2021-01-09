using System;

namespace ClassesGoblinBattle
{
    class Program
    {
        static void Main(string[] args)
        {
            /*make the goblins battle*/
            Goblin g1 = new Goblin();
            g1.SetName("Bob");
            g1.SetHitPoints(10);

            Goblin g2 = new Goblin();
            g2.SetName("Tom");
            g2.SetHitPoints(10);

            int whoseTurn = 1;

            while (!g1.IsDead() && !g2.IsDead())
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
            Console.WriteLine(g1.IsDead()
                ? $"{g2.GetName()} has won!"
                : $"{g1.GetName()} has won!");
        }
    }
}