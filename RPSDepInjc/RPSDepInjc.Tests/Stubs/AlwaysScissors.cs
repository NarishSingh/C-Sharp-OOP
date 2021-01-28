using RPSDepInjc.BLL;

namespace RPSDepInjc.Tests.Stubs
{
    public class AlwaysScissors : IChoiceGetter
    {
        public Choice GetChoice()
        {
            return Choice.Scissors;
        }
    }
}