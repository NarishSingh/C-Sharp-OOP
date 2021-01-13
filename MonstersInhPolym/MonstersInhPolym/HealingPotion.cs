using System;

namespace MonstersInhPolym
{
    public class HealingPotion: Potion
    {
        public override void Drink(Creature drinker)
        {
            Console.WriteLine("The healing potion heals you!");
            drinker.AddHp(5);
        }
    }
}