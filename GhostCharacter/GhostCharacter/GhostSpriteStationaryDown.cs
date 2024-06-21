using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections;

namespace Zelda
{
    public class GhostSpriteStationaryDown : GhostCharacterSprite
    {
        
       
        Rectangle sourceRectangle;
        Rectangle arrowSprite;
        Rectangle nothingSprite;
        
        public GhostSpriteStationaryDown(Game1 game) : base(game)
        {
            this.game = game;
            nothingSprite = new Rectangle(914, 104, 30, 50);
            arrowSprite = new Rectangle(914, 50, 30, 50);
            sourceRectangle = nothingSprite;


        }

        public override void Update()
        {

            GhostCharacterState.DestinationRectangle = new Rectangle(GhostCharacterState.XPos, GhostCharacterState.YPos, 60, 100);
            sourceRectangle = nothingSprite;
            base.Update();
        }

        public override void Draw()
        {
            Vector2 orgin = new Vector2(0.0F, 0.0F);
            game.SpriteBatch.Draw(game.Textures.PlayerTexture, GhostCharacterState.DestinationRectangle, sourceRectangle, Color.DarkGray, 0.0F, orgin, SpriteEffects.FlipHorizontally, 0.0F);
        }
    }
}
