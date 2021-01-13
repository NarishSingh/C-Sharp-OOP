using System;

namespace MonstersInhPolym
{
    public class PoisonPotion: Potion
    {
        public override void Drink(Creature drinker)
        {
            Console.WriteLine("The poison potion hurts you!");
            drinker.AddHp(-5);
        }
    }
}