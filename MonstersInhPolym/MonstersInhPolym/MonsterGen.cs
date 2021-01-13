using System;

namespace MonstersInhPolym
{
    public class MonsterGen
    {
        private static Random _rng = new Random();

        /// <summary>
        /// Generate a new monster - polymorphism in action
        /// </summary>
        /// <returns>a Creature type</returns>
        public static Creature Generate()
        {
            switch (_rng.Next(1,4))
            {
                case 1:
                    return new Goblin(1);
                case 2:
                    return new Ogre(1);
                default:
                    return new Hydra(1);
            }
        }
    }
}