using Microsoft.Xna.Framework;

namespace Zelda
{
    public class CommandStartGame : ICommand
    {
        Game1 game;
        
        public CommandStartGame(Game1 game)
        {
            this.game = game;
            
        }

        public void Execute()
        {
            game.IsStart = false;
            game.IsPaused = false;
            game.IsOver = false;
        }
    }
}