using System;
using System.Configuration;

namespace RPSDepInjc.BLL.Service
{
    public class GameManagerFactory
    {
        /**
         * This factory class will manage dep inj
         */
        public static GameManager Create()
        {
            string chooserType = ConfigurationManager.AppSettings["Chooser"];

            if (chooserType == "Random")
            {
                return new GameManager(new RandomChoice());
            }
            else if (chooserType == "PrefersRock")
            {
                return new GameManager(new PrefersRock());
            }
            else
            {
                throw new Exception("Chooser key in app.config not set properly");
            }
        }
    }
}