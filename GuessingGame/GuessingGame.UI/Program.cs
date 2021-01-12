using System;
using GuessingGame.BLL;

namespace GuessingGame.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            GameFlow game = new GameFlow();
            game.Play();
        }
    }
}