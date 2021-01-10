using System;

namespace GoblinBattlePropertyV
{
    public class Goblin
    {
        private static Random _rng = new Random();

        //property versions
        public string Name { get; set; }
        public bool Dead { get; private set; } //private set so only this class's methods can set it

        private int _hitPoints; //custom setter for property

        public int HitPoints
        {
            get => _hitPoints;
            set
            {
                if (value < 0)
                {
                    return;
                }
                else
                {
                    _hitPoints = value;
                }
            }
        }

        //functions
        /// <summary>
        /// Take a hit
        /// </summary>
        /// <param name="dmg">amount of damage received from hit</param>
        public void Hit(int dmg)
        {
            HitPoints -= dmg;
            Console.WriteLine($"{Name} receives {dmg} dmg. They have {HitPoints} hp");

            //death handler
            if (HitPoints <= 0)
            {
                Dead = true;
            }
        }

        /// <summary>
        /// Attack a target
        /// </summary>
        /// <param name="target">Goblin to attack</param>
        public void Atk(Goblin target)
        {
            int dmg = _rng.Next(5);
            Console.WriteLine($"{Name} attacks {target.Name} for {dmg} dmg!");

            target.Hit(dmg);
        }
    }
}