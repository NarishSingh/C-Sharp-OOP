using System;

namespace MonstersInhPolym
{
    class Program
    {
        static void Main(string[] args)
        {
            Goblin g = new Goblin(5);

            g.AddPotion(new BubblyPotion());
            g.AddPotion(new HealingPotion());
            g.AddPotion(new PoisonPotion());
            
            g.Drink();
            g.Drink();
            g.Drink();
        }
    }
}