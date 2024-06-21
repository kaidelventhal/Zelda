using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Zelda;

namespace Zelda
{
    public class SpriteAttackDown : MainCharacterSprite
    {
        
        
        Rectangle[] sourceRectangle;
        int sourceRectangleIndex;

        private int frame;
        
        public SpriteAttackDown(Game1 game) : base(game)
        {
            this.game = game;
            sourceRectangle = new Rectangle[4];
            sourceRectangle[0] = new Rectangle(1027, 93, 39, 58);
            sourceRectangle[1] = new Rectangle(1070, 104, 46, 51);
            sourceRectangle[2] = new Rectangle(1145, 102, 27, 51);
            sourceRectangle[3] = new Rectangle(1187, 102, 31, 51);
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
                MainCharacterState.DestinationRectangle = new Rectangle(MainCharacterState.XPos+4, MainCharacterState.YPos-22, sourceRectangle[sourceRectangleIndex].Width * 2, sourceRectangle[sourceRectangleIndex].Height * 2);
            }
            else if (frame < 20)
            {
                sourceRectangleIndex = 1;
                MainCharacterState.DestinationRectangle = new Rectangle(MainCharacterState.XPos+4, MainCharacterState.YPos, sourceRectangle[sourceRectangleIndex].Width * 2, sourceRectangle[sourceRectangleIndex].Height * 2);
            }
            else if (frame < 30)
            {
                sourceRectangleIndex = 2;
                MainCharacterState.DestinationRectangle = new Rectangle(MainCharacterState.XPos+3, MainCharacterState.YPos, sourceRectangle[sourceRectangleIndex].Width * 2, sourceRectangle[sourceRectangleIndex].Height * 2);
            }
            else if (frame < 40)
            {
                sourceRectangleIndex = 3;
                MainCharacterState.DestinationRectangle = new Rectangle(MainCharacterState.XPos, MainCharacterState.YPos, sourceRectangle[sourceRectangleIndex].Width * 2, sourceRectangle[sourceRectangleIndex].Height * 2);
            }
            else
            {
                MainCharacterState.Attack = false;
                game.mainCharacter = new SpriteStationaryDown(game);
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
