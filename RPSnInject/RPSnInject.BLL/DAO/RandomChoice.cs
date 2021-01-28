using System;
using RPSnInject.BLL.DTO;

namespace RPSnInject.BLL.DAO
{
    /**
     * True choice behavior for gameplay
     */
    public class RandomChoice : IChoiceGetter
    {
        private Random _rng = new();

        public Choice GetChoice()
        {
            return (Choice) _rng.Next(1, 4);
        }
    }
}