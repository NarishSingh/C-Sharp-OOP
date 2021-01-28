using System;
using System.Configuration;
using Ninject;
using RPSnInject.BLL.DAO;

namespace RPSnInject.BLL.Service
{
    /**
     * This will use NInject to handle DI, static because we only need one
     */
    public static class DIContainer
    {
        public static IKernel Kernel = new StandardKernel();

        /**
         * Ctor to configure our bindings set in app.config
         */
        static DIContainer()
        {
            string chooserType = ConfigurationManager.AppSettings["Chooser"].ToString();

            // Tell ninject that IChoiceGetter should resolve to RandomChoice
            if (chooserType == "Random")
            {
                Kernel.Bind<IChoiceGetter>().To<RandomChoice>();
            }
            // Tell ninject that IChoiceGetter should resolve to PrefersRockChoice
            else if (chooserType == "PrefersRock")
            {
                Kernel.Bind<IChoiceGetter>().To<PrefersRock>();
            }
            else
            {
                throw new Exception("Chooser key in app.config not set properly!");
            }
        }
    }
}