/*
 * This uses the standard/java-esque way
 */

using System;

namespace ClassesGoblinBattle
{
    public class Goblin
    {
        private static Random _rng = new Random();
        private int _hitPoints;
        private string _name;
        private bool _dead;

        /*getters and setters*/
        public int GetHitPoints()
        {
            return _hitPoints;
        }

        public void SetHitPoints(int hp)
        {
            if (hp < 0)
            {
                return;
            }
            else
            {
                _hitPoints = hp;
            }
        }

        public string GetName()
        {
            return _name;
        }

        public void SetName(string newName)
        {
            _name = newName;
        }

        //getter only for this one
        public bool IsDead()
        {
            return _dead;
        }

        /*functions*/
        /// <summary>
        /// Take a hit
        /// </summary>
        /// <param name="dmg">amount of damage received from hit</param>
        public void Hit(int dmg)
        {
            _hitPoints -= dmg;

            Console.WriteLine($"{_name} receives {dmg} damage. {_hitPoints} hp remaining");

            //death handler
            if (_hitPoints <= 0)
            {
                Console.WriteLine($"{_name} has died");
                _dead = true;
            }
        }

        /// <summary>
        /// Attack a target
        /// </summary>
        /// <param name="target">Goblin to attack</param>
        public void Atk(Goblin target)
        {
            int dmg = _rng.Next(5);
            Console.WriteLine($"{_name} attacks {target.GetName()} for {dmg} damage!");
            
            target.Hit(dmg);
        }
    }
}