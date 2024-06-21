using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Zelda
{
    public class GhostSpriteStationaryRight : GhostCharacterSprite
    {
        
        Rectangle sourceRectangle;
        Rectangle arrowSprite;
        Rectangle nothingSprite;

        public GhostSpriteStationaryRight(Game1 game) : base(game)
        {
            this.game = game;
            this.nothingSprite = new Rectangle(211, 9, 33, 45);
            this.arrowSprite = new Rectangle(206, 141, 50, 50);
            sourceRectangle = nothingSprite;

        }

        public override void Update()
        {

            sourceRectangle = nothingSprite;

            GhostCharacterState.DestinationRectangle = new Rectangle(GhostCharacterState.XPos, MainCharacterState.YPos, sourceRectangle.Width * 2, sourceRectangle.Height * 2);
            base.Update();
            
            

        }

        public override void Draw()
        {
            
            base.Draw();
            
            game.SpriteBatch.Draw(game.Textures.PlayerTexture, GhostCharacterState.DestinationRectangle, sourceRectangle, Color.DarkGray);
            
        }
    }
}
