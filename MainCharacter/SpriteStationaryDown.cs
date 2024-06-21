using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections;

namespace Zelda
{
    public class SpriteStationaryDown : MainCharacterSprite
    {
        
       
        Rectangle sourceRectangle;
        Rectangle arrowSprite;
        Rectangle nothingSprite;
        
        public SpriteStationaryDown(Game1 game) : base(game)
        {
            this.game = game;
            nothingSprite = new Rectangle(914, 104, 30, 50);
            arrowSprite = new Rectangle(914, 50, 30, 50);
            sourceRectangle = nothingSprite;
        }

        public override void Update()
        {
            MainCharacterState.DestinationRectangle = new Rectangle(MainCharacterState.XPos, MainCharacterState.YPos, 60, 100);
            switch (MainCharacterState.CurrentItem)
            {
                case Constants.items.Bow: sourceRectangle = arrowSprite;break;
                default: sourceRectangle = nothingSprite;break;
            }
            base.Update();
        }

        public override void Draw()
        {
            Vector2 orgin = new Vector2(0.0F, 0.0F);
            game.SpriteBatch.Draw(game.Textures.PlayerTexture, MainCharacterState.DestinationRectangle, sourceRectangle, Color.White, 0.0F, orgin, SpriteEffects.FlipHorizontally, 0.0F);
        }
    }
}
