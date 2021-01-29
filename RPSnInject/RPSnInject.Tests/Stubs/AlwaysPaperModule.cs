using Ninject.Modules;
using RPSnInject.BLL.DAO;

namespace RPSnInject.Tests.Stubs
{
    public class AlwaysPaperModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IChoiceGetter>().To<AlwaysPaper>();
        }
    }
}