using Microsoft.Xna.Framework;

namespace Zelda
{
    public class SpriteText : ISprite
    {
        Game1 game;
        public SpriteText(Game1 game)
        {
            this.game = game;
        }

        public void Update()
        {
            // No logic needed
        }

        public void Draw()
        {
            //game.SpriteBatch.DrawString(game.Font, "Credits\nProgram Made By: Walden Hart\nSprites From: https://www.mariomayhem.com/downloads/sprites/super_mario_bros_sprites.php", new Vector2(50, 300), Color.Black);
        }
    }
}
