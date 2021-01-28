using System;
using RPSnInject.BLL.DTO;

namespace RPSnInject.BLL.DAO
{
    public class PrefersRock : IChoiceGetter
    {
        private Random _rng = new();

        public Choice GetChoice()
        {
            int n = _rng.Next(1, 101);

            if (n > 40)
            {
                return Choice.Rock;
            }
            else if (n > 20)
            {
                return Choice.Paper;
            }
            else
            {
                return Choice.Scissors;
            }
        }
    }
}