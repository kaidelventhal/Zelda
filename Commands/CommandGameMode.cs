using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Transactions;

namespace Zelda
{
    public class CommandGameMode : ICommand
    {
        private Game1 game;
        private List<Constants.GameMode> modes;
        int index;

        public CommandGameMode(Game1 game)
        {
            modes = new List<Constants.GameMode> { Constants.GameMode.Normal, Constants.GameMode.Ghost, Constants.GameMode.Gladiator, Constants.GameMode.Boss };
            this.game = game;
            index = 1;
        }

        public void Execute()
        {
            if (game.IsStart)
            {
                game.GameMode = modes[index++ % modes.Count];
            }
            
        }

    }
}
