using RPSUnity.BLL.DAO;
using RPSUnity.BLL.DTO;

namespace RPSUnity.BLL.Service
{
    /**
     * This will use ctor injection -> private field + ctor
     */
    public class GameManager
    {
        private IChoiceGetter _chooser;

        public GameManager(IChoiceGetter chooser)
        {
            _chooser = chooser;
        }

        public PlayRoundResponse PlayRound(Choice p1Choice)
        {
            PlayRoundResponse response = new PlayRoundResponse();

            //save round choices
            response.Player1Choice = p1Choice;
            response.Player2Choice = _chooser.GetChoice();

            //evaluate round
            //tie
            if (response.Player1Choice == response.Player2Choice)
            {
                response.Player1Result = GameResult.Tie;
                return response;
            }

            //p1 win
            if (response.Player1Choice == Choice.Rock && response.Player2Choice == Choice.Scissors ||
                response.Player1Choice == Choice.Scissors && response.Player2Choice == Choice.Paper ||
                response.Player1Choice == Choice.Paper && response.Player2Choice == Choice.Rock)
            {
                response.Player1Result = GameResult.Win;
                return response;
            }

            //loss
            response.Player1Result = GameResult.Loss;
            return response;
        }
    }
}