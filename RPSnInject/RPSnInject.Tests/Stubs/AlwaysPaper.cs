using RPSnInject.BLL.DAO;
using RPSnInject.BLL.DTO;

namespace RPSnInject.Tests.Stubs
{
    public class AlwaysPaper : IChoiceGetter
    {
        public Choice GetChoice()
        {
            return Choice.Paper;
        }
    }
}