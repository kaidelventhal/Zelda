using Microsoft.Xna.Framework;

namespace Zelda
{
    public class CommandQuit : ICommand
    {
        private Game game;

        public CommandQuit(Game game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.Exit();
        }

    }
}
