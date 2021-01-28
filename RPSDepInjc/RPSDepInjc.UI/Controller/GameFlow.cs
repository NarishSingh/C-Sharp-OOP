using System;
using RPSDepInjc.BLL;
using RPSDepInjc.BLL.Service;
using RPSDepInjc.UI.View;

namespace RPSDepInjc.UI.Controller
{
    public class GameFlow
    {
        public void Start()
        {
            Choice player1Choice;
            GameManager gm = GameManagerFactory.Create();

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