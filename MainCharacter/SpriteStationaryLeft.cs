using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Zelda
{
    public class SpriteStationaryLeft : MainCharacterSprite
    {
        
        Rectangle sourceRectangle;
        Rectangle arrowSprite;
        Rectangle nothingSprite;
        
        public SpriteStationaryLeft(Game1 game) : base(game)
        {
            this.game = game;
            this.nothingSprite = new Rectangle(211, 9, 33, 45);
            this.arrowSprite = new Rectangle(206, 141, 50, 50);
            sourceRectangle = nothingSprite;

        }

        public override void Update()
        {

            switch (MainCharacterState.CurrentItem)
            {
                case Constants.items.Bow: sourceRectangle = arrowSprite; break;
                default: sourceRectangle = nothingSprite; break;
            }
            MainCharacterState.DestinationRectangle = new Rectangle(MainCharacterState.XPos, MainCharacterState.YPos, sourceRectangle.Width*2, sourceRectangle.Height*2);
            
            base.Update();

        }

        public override void Draw()
        {
            base.Draw();
            Vector2 orgin = new Vector2(0.0F, 0.0F);
            
            game.SpriteBatch.Draw(game.Textures.PlayerTexture, MainCharacterState.DestinationRectangle, sourceRectangle, Color.White, 0.0F, orgin, SpriteEffects.FlipHorizontally, 0.0F);
            
        }
    }
}
