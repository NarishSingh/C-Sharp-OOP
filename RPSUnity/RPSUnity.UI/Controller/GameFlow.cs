using System;
using RPSUnity.BLL.DTO;
using RPSUnity.BLL.Service;
using RPSUnity.UI.View;
using Unity;

namespace RPSUnity.UI.Controller
{
    public class GameFlow
    {
        public void Start()
        {
            Choice player1Choice;
            GameManager gm = DIContainer.Container.Resolve<GameManager>(); //this is like ctor inj

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