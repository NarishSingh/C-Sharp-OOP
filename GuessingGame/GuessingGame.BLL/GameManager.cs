/*
 * Service
 */

using System;

namespace GuessingGame.BLL
{
    public class GameManager
    {
        private int _ans;

        /// <summary>
        /// Validate a user guess
        /// </summary>
        /// <param name="guess">an integer</param>
        /// <returns>true if input is a valid int between 1 and 20, false otherwise</returns>
        private bool IsValidGuess(int guess)
        {
            if (guess >= 1 && guess <= 20)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Randomize an answer for a game
        /// </summary>
        private void CreateAnswer()
        {
            Random rng = new Random();
            _ans = rng.Next(1, 21);
        }

        /// <summary>
        /// Evaluate a user guess
        /// </summary>
        /// <param name="guess">an integer from user input</param>
        /// <returns>GuessResult state that corresponds to the input</returns>
        public GuessResult ProcessGuess(int guess)
        {
            if (!IsValidGuess(guess))
            {
                return GuessResult.Invalid;
            }

            if (guess < _ans)
            {
                return GuessResult.Higher;
            }
            else if (guess > _ans)
            {
                return GuessResult.Lower;
            }
            else
            {
                return GuessResult.Win;
            }
        }

        /// <summary>
        /// Start a game with random answer
        /// </summary>
        public void Start()
        {
            CreateAnswer();
        }

        /// <summary>
        /// Start a new game with a preset answer
        /// </summary>
        /// <param name="ans">int between 1 and 20</param>
        public void Start(int ans)
        {
            _ans = ans;
        }
    }
}