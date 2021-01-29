using System;
using Ninject;
using RPSnInject.BLL.DTO;
using RPSnInject.BLL.Service;
using RPSnInject.UI.View;

namespace RPSnInject.UI.Controller
{
    public class GameFlow
    {
        public void Start()
        {
            Choice player1Choice;
            GameManager gm = DIContainer.Kernel.Get<GameManager>(); //this is like ctor inj

            while (true)
            {
                Console.Clear();
                player1Choice = ConsoleInput.GetChoiceFromUser();
                PlayRoundResponse response = gm.PlayRound(player1Choice);

                ConsoleOutput.DisplayResult(response);

                if (!ConsoleInput.QueryPlayAgain())
                {
                    return;
                }
            }
        }
    }
}