using Microsoft.Xna.Framework;
using System;
using System.Transactions;

namespace Zelda
{
    public class CommandReset : ICommand
    {
        private Game1 game;

        public CommandReset(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.initializeDetails();
            game.IsPaused = true;
            game.IsStart = true;
            game.IsOver = false;
            Console.WriteLine("Reset pressed");
        }

    }
}
