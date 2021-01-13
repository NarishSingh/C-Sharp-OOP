namespace MonstersInhPolym
{
    public class Troll : Creature
    {
        public Troll(int startingLevel)
        {
            _level = startingLevel;
        }

        /*
        public override void Regen()
        {
            if (_hp < 100)
            {
                if (_hp + 4 > 100)
                {
                    _hp = 100;
                }
                else
                {
                    _hp += 4;
                }
            }
        }
        */

        /// <summary>
        /// Override - Troll regen's 4 hp
        /// </summary>
        public override void Regen()
        {
            base.Regen(); //uses base method to regen 1 hp
            
            //+3 more
            if (_hp + 3 > 100)
            {
                _hp = 100;
            }
            else
            {
                _hp += 3;
            }
        }
    }
}