namespace MonstersInhPolym
{
    public class Goblin: Creature
    {
        public Goblin(int startingLevel): base(startingLevel)
        {
            // _level = startingLevel; //no longer need to do this since we used the base ctor
        }
    }
}