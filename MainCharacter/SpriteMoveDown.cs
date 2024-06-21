using Microsoft.Xna.Framework;
using System;
namespace Zelda
{
    internal class SpriteMoveDown : MainCharacterSprite
    {
        
        Rectangle[] sourceRectangle;
        int sourceRectangleIndex;
        int frame = 0;
        
        public SpriteMoveDown(Game1 game) : base(game)
        {
            sourceRectangle = new Rectangle[3];
            sourceRectangleIndex = 0;
            sourceRectangle[0] = new Rectangle(914, 104, 30, 50);
            sourceRectangle[1] = new Rectangle(950, 104, 30, 50);
            sourceRectangle[2] = new Rectangle(985, 104, 30, 50);
        }

        public override void Update()
        {
            MainCharacterState.Attack = false;
            base.Update();
            //we can add animation if we find sprite sheet with up down animation
            // Could erfactor these movement codes later
            if (frame <= 10)
            {
                sourceRectangleIndex = 0;  
            }
            else if (frame <= 20)
            {
                sourceRectangleIndex = 1;
            }
            else if (frame <= 30)
            {
                sourceRectangleIndex = 2;
            }
            frame = (frame + 1) % 30;

            MainCharacterState.DestinationRectangle = new Rectangle(MainCharacterState.XPos, MainCharacterState.YPos, 70, 100);
            
            
        }

        public override void Draw()
        {
            base.Draw();
            
            game.SpriteBatch.Draw(game.Textures.PlayerTexture, MainCharacterState.DestinationRectangle, sourceRectangle[sourceRectangleIndex], Color.White);
            
        }
    }
}