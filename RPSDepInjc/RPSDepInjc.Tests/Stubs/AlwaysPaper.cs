using RPSDepInjc.BLL;

namespace RPSDepInjc.Tests.Stubs
{
    public class AlwaysPaper : IChoiceGetter
    {
        public Choice GetChoice()
        {
            return Choice.Paper;
        }
    }
}