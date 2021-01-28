using RPSDepInjc.BLL;

namespace RPSDepInjc.Tests.Stubs
{
    public class AlwaysRock : IChoiceGetter
    {
        public Choice GetChoice()
        {
            return Choice.Rock;
        }
    }
}