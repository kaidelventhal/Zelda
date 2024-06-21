using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Zelda
{
    public class EndScreen
    {
        private Game1 game;
        private Rectangle destinationRectanlgle;
        private Texture2D finalEndScreen;


        // Constructor to initialize the End Screen with a reference to the game class
        public EndScreen(Game1 game)
        {
            this.game = game;
            finalEndScreen = game.Textures.FinalEndScreen;
            destinationRectanlgle = new Rectangle(0, 0, game.GraphicsDevice.Viewport.Width, game.GraphicsDevice.Viewport.Height);
        }


        // Update method to check for any key press to deactivate the End screen
        public void Update()
        {


        }

        // Draw method to render the End screen
        public void Draw()
        {
            if (game.IsOver)
            {
                Console.WriteLine("EndScreen class - Game Over");
                //game.SpriteBatch.Draw(game.Textures.FinalEndScreen, destinationRectanlgle,  Color.White);
                game.SpriteBatch.Draw(finalEndScreen, new Rectangle(0, 0, game.GraphicsDevice.Viewport.Width, game.GraphicsDevice.Viewport.Height), Color.White);
            }
        }
    }
}
