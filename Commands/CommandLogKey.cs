using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

namespace Zelda
{
    public class CommandLogKey : ICommand
    {
        private Game1 game;
        private Keys key;

        public CommandLogKey(Game1 game, Keys key)
        {
            this.game = game;
            this.key = key;
        }

        public void Execute()
        {
            game.CheatControls.LogKey(key.ToString());
        }

    }
}
