using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Zelda
{
    public class StartScreen
    {
        private Game1 game;
        private Texture2D startScreen;
        string gamemodeText;
        

        // Constructor to initialize the StartScreen with a reference to the game class
        public StartScreen(Game1 game)
        {
            this.game = game;
            startScreen = game.Textures.StartScreen;
            gamemodeText = "Game Mode : " + game.GameMode;

        }


        // Update method to check for any key press to deactivate the start screen
        public void Update()
        {

            gamemodeText = "Game Mode : " + game.GameMode+ "  (Sw itch Using N)";
        }

        // Draw method to render the start screen
        public void Draw()
        {
            if (game.IsStart)
            {
                game.SpriteBatch.Draw(startScreen, new Rectangle(0, 0, game.GraphicsDevice.Viewport.Width, game.GraphicsDevice.Viewport.Height), Color.White);
                game.SpriteBatch.DrawString(game.Textures.CountFont,gamemodeText,new Vector2(350,600),Color.Black);
            }

            

        }
    }
}
