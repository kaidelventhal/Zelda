﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Zelda
{
    public class SpriteStationaryUp : MainCharacterSprite
    {
        
       
        Rectangle sourceRectangle;
        Rectangle arrowSprite;
        Rectangle nothingSprite;

        public SpriteStationaryUp(Game1 game) : base(game)
        {
            this.game = game;
            this.nothingSprite = new Rectangle(914, 161, 30, 50);
            this.arrowSprite = new Rectangle(911, 220, 30, 50);
            sourceRectangle = nothingSprite;

        }

        public override void Update()
        {

            switch (MainCharacterState.CurrentItem)
            {
                case Constants.items.Bow: sourceRectangle = arrowSprite; break;
                default: sourceRectangle = nothingSprite; break;
            }
            MainCharacterState.DestinationRectangle = new Rectangle(MainCharacterState.XPos, MainCharacterState.YPos, sourceRectangle.Width * 2, sourceRectangle.Height * 2);
            base.Update();

        }

        public override void Draw()
        {
            Vector2 orgin = new Vector2(0.0F, 0.0F);
            game.SpriteBatch.Draw(game.Textures.PlayerTexture, MainCharacterState.DestinationRectangle, sourceRectangle, Color.White);
        }
    }
}
