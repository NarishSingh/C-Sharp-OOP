using System.Collections.Generic;

namespace MonstersInhPolym
{
    public class Creature
    {
        protected int _level;
        protected int _hp;
        private Stack<Potion> _potions = new Stack<Potion>();

        //here we used this() to chain ctors -> by default a creature is lvl 1  w 100hp
        public Creature(): this(1)
        {
        }

        public Creature(int startLvl)
        {
            _level = startLvl;
            _hp = 100;
        }

        public void LevelUp()
        {
            _level++;
        }

        /// <summary>
        /// Regenerate some health - virtual -> can be overriden in child classes
        /// </summary>
        public virtual void Regen()
        {
            if (_hp < 100)
            {
                _hp++;
            }
        }
        
        public void AddHp(int hp)
        {
            if (_hp + hp > 100)
            {
                _hp = 100;
            }
            else
            {
                _hp += hp;
            }
        }
 
        public void AddPotion(Potion p)
        {
            // push a potion onto the stack
            _potions.Push(p);
        }

        /// <summary>
        /// implements from abstract class potion - Creature drinks topmost potion from stack
        /// </summary>
        public void Drink()
        {
            if (_potions.Peek()!=null)
            {
                _potions.Pop().Drink(this);
            }
        }
    }
}