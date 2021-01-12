/*
 * Controller
 */

using GuessingGame.BLL;

namespace GuessingGame.UI
{
    public class GameFlow
    {
        private GameManager _mng;

        /// <summary>
        /// Play a game
        /// </summary>
        public void Play()
        {
            CreateGameManagerInstance();
            ConsoleOutput.DisplayTitle();

            GuessResult result;

            do
            {
                int guess = ConsoleInput.ReadGuess();
                result = _mng.ProcessGuess(guess);
                ConsoleOutput.DisplayGuessResult(result);
            } while (result != GuessResult.Win);
        }

        /// <summary>
        /// Initialize the service layer
        /// </summary>
        private void CreateGameManagerInstance()
        {
            _mng = new GameManager();
            _mng.Start();
        }
    }
}