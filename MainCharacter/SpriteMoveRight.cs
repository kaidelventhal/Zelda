using Microsoft.Xna.Framework;
using System;
namespace Zelda
{
    internal class SpriteMoveRight : MainCharacterSprite
    {
        
        Rectangle[] sourceRectangle;
        int sourceRectangleIndex;
        int frame = 0;
        
        public SpriteMoveRight(Game1 game) : base(game)
        {
            sourceRectangleIndex = 0;
            sourceRectangle = new Rectangle[4];
            sourceRectangle[0] = new Rectangle(127, 140, 25, 45);
            sourceRectangle[1] = new Rectangle(4, 140, 37, 45);
            sourceRectangle[2] = new Rectangle(51, 140, 24, 45);
            sourceRectangle[3] = new Rectangle(81, 140, 37, 45);
        }
        
        public override void Update()
        {
            MainCharacterState.Attack = false;
            base.Update();
            //we can add animation if we find sprite sheet with up down animation
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
            else
            {
                sourceRectangleIndex = 3;
            }
            frame = (frame + 1) % 40;

            MainCharacterState.DestinationRectangle = new Rectangle(MainCharacterState.XPos, MainCharacterState.YPos, 70, 90);
            
            
        }

        public override void Draw()
        {
            base.Draw();
           
            game.SpriteBatch.Draw(game.Textures.PlayerTexture, MainCharacterState.DestinationRectangle, sourceRectangle[sourceRectangleIndex], Color.White);
           
        }
    }
}