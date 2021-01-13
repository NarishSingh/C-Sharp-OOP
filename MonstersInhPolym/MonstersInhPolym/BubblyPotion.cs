using System;

namespace MonstersInhPolym
{
    public class BubblyPotion: Potion
    {
        public override void Drink(Creature drinker)
        {
            Console.WriteLine("Burp!");
        }
    }
}