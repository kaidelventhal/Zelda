using Microsoft.Xna.Framework;

namespace Zelda
{
    public class CommandToggleMusic : ICommand
    {
        Game1 game;
        
        public CommandToggleMusic(Game1 game)
        {
            this.game = game;
            
        }

        public void Execute()
        {
            game.MusicController.togleMusic();
        }
    }
}