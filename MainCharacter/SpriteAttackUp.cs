using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Zelda
{
    public class SpriteAttackUp : MainCharacterSprite
    {
        Rectangle[] sourceRectangle;
        int sourceRectangleIndex;

        private int frame;
        
        public SpriteAttackUp(Game1 game) : base(game)
        {
            this.game = game;
            sourceRectangle = new Rectangle[4];
            sourceRectangle[0] = new Rectangle(1025, 151, 38, 58);
            sourceRectangle[1] = new Rectangle(1066, 161, 36, 47);
            sourceRectangle[2] = new Rectangle(1102, 161, 34, 47);
            sourceRectangle[3] = new Rectangle(1136, 161, 42, 48);
            sourceRectangleIndex = 0;
            MainCharacterState.Attack = true;
            MainCharacterState.DestinationRectangle = new Rectangle(MainCharacterState.XPos, MainCharacterState.YPos, sourceRectangle[sourceRectangleIndex].Width * 2, sourceRectangle[sourceRectangleIndex].Height * 2);

        }

        public override void Update()
        {
            base.Update();
            if (frame < 10)
            {
                sourceRectangleIndex = 0;
                MainCharacterState.DestinationRectangle = new Rectangle(MainCharacterState.XPos, MainCharacterState.YPos-17, sourceRectangle[sourceRectangleIndex].Width * 2, sourceRectangle[sourceRectangleIndex].Height * 2);
            }
            else if (frame < 20)
            {

                sourceRectangleIndex = 1;
                MainCharacterState.DestinationRectangle = new Rectangle(MainCharacterState.XPos, MainCharacterState.YPos, sourceRectangle[sourceRectangleIndex].Width * 2, sourceRectangle[sourceRectangleIndex].Height * 2);
            }
            else if (frame < 30)
            {

                sourceRectangleIndex = 2;
                MainCharacterState.DestinationRectangle = new Rectangle(MainCharacterState.XPos-10, MainCharacterState.YPos, sourceRectangle[sourceRectangleIndex].Width * 2, sourceRectangle[sourceRectangleIndex].Height * 2);
            }
            else if (frame < 40)
            {

                sourceRectangleIndex = 3;
                MainCharacterState.DestinationRectangle = new Rectangle(MainCharacterState.XPos-22, MainCharacterState.YPos, sourceRectangle[sourceRectangleIndex].Width * 2, sourceRectangle[sourceRectangleIndex].Height * 2);
            }
            else
            {
                MainCharacterState.Attack = false;
                game.mainCharacter = new SpriteStationaryUp(game);
            }

            frame++;
            

        }

        public override void Draw()
        {
            base.Draw();
            
            
            game.SpriteBatch.Draw(game.Textures.PlayerTexture, MainCharacterState.DestinationRectangle, sourceRectangle[sourceRectangleIndex], Color.White);
            
        }
    }
}
