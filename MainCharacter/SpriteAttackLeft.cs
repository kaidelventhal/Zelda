using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Zelda
{
    public class SpriteAttackLeft : MainCharacterSprite
    {
        
        
        Rectangle[] sourceRectangle;
        int sourceRectangleIndex;

        private int frame;
        
        public SpriteAttackLeft(Game1 game) : base(game)
        {

            this.game = game;
            sourceRectangle = new Rectangle[4];
            sourceRectangle[0] = new Rectangle(94, 1, 43, 52);
            sourceRectangle[1] = new Rectangle(309, 67, 39, 60);
            sourceRectangle[2] = new Rectangle(354, 61, 79, 66);
            sourceRectangle[3] = new Rectangle(442, 87, 33, 41);
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
                MainCharacterState.DestinationRectangle = new Rectangle(MainCharacterState.XPos - 5, MainCharacterState.YPos - 10, sourceRectangle[sourceRectangleIndex].Width * 2, sourceRectangle[sourceRectangleIndex].Height * 2);
            }
            else if (frame < 20)
            {
                sourceRectangleIndex = 1;
                MainCharacterState.DestinationRectangle = new Rectangle(MainCharacterState.XPos + 2, MainCharacterState.YPos - 20, sourceRectangle[sourceRectangleIndex].Width * 2, sourceRectangle[sourceRectangleIndex].Height * 2);
            }
            else if (frame < 30)
            {
                sourceRectangleIndex = 2;
                MainCharacterState.DestinationRectangle = new Rectangle(MainCharacterState.XPos - 45, MainCharacterState.YPos - 33, sourceRectangle[sourceRectangleIndex].Width * 2, sourceRectangle[sourceRectangleIndex].Height * 2);
            }
            else if (frame < 40)
            {
                sourceRectangleIndex = 3;
                MainCharacterState.DestinationRectangle = new Rectangle(MainCharacterState.XPos + 10, MainCharacterState.YPos + 10, sourceRectangle[sourceRectangleIndex].Width * 2, sourceRectangle[sourceRectangleIndex].Height * 2);
            }
            else
            {
                MainCharacterState.Attack = false;
                game.mainCharacter = new SpriteStationaryLeft(game);
            }
            
            frame++;
            

        }

        public override void Draw()
        {
            base.Draw();
            Vector2 orgin = new Vector2(0.0F, 0.0F);
            game.SpriteBatch.Draw(game.Textures.PlayerTexture, MainCharacterState.DestinationRectangle, sourceRectangle[sourceRectangleIndex], Color.White, 0.0F, orgin, SpriteEffects.FlipHorizontally, 0.0F);
            
        }
    }
}
