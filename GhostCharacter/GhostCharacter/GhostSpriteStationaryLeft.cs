using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Zelda
{
    public class GhostSpriteStationaryLeft : GhostCharacterSprite
    {
        
        Rectangle sourceRectangle;
        Rectangle arrowSprite;
        Rectangle nothingSprite;
        
        public GhostSpriteStationaryLeft(Game1 game) : base(game)
        {
            this.game = game;
            this.nothingSprite = new Rectangle(211, 9, 33, 45);
            this.arrowSprite = new Rectangle(206, 141, 50, 50);
            sourceRectangle = nothingSprite;

        }

        public override void Update()
        {

            sourceRectangle = nothingSprite;
            GhostCharacterState.DestinationRectangle = new Rectangle(GhostCharacterState.XPos, GhostCharacterState.YPos, sourceRectangle.Width*2, sourceRectangle.Height*2);
            
            base.Update();

        }

        public override void Draw()
        {
            base.Draw();
            Vector2 orgin = new Vector2(0.0F, 0.0F);
            
            game.SpriteBatch.Draw(game.Textures.PlayerTexture, GhostCharacterState.DestinationRectangle, sourceRectangle, Color.DarkGray, 0.0F, orgin, SpriteEffects.FlipHorizontally, 0.0F);
            
        }
    }
}
