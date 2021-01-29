using System;
using System.Configuration;
using RPSUnity.BLL.DAO;
using Unity;

namespace RPSUnity.BLL.Service
{
    public static class DIContainer
    {
        public static UnityContainer Container = new UnityContainer();

        static DIContainer()
        {
            string chooserType = ConfigurationManager.AppSettings["Chooser"];

            if (chooserType == "Random")
            {
                Container.RegisterType<IChoiceGetter, RandomChoice>();
            } else if (chooserType == "PrefersRock")
            {
                Container.RegisterType<IChoiceGetter, PrefersRock>();
            }
            else
            {
                throw new Exception("Chooser key not set properly");
            }
        }
    }
}