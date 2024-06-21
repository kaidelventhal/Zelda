using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Zelda.Rooms;




namespace Zelda
{
    public class MovingBlock : ISprite
    {
        private Rectangle sourceRectangle;
        private Rectangle targetRectangle;
        private Rectangle oldtargetRectangle;


        Game1 game;
        public MovingBlock(Game1 game, int xPosition, int yPosition)
        {


            sourceRectangle = new Rectangle(323, 91, 16, 16);
            targetRectangle = new Rectangle(xPosition, yPosition, sourceRectangle.Width*4, sourceRectangle.Height*4);
  
            this.game = game;
            
            
        }
        public void Draw()
        {
            game.SpriteBatch.Draw(game.Textures.GameBoardTexture, targetRectangle, sourceRectangle, Color.White);
            
        }

        public void Update()
        {
            if (MainCharacterState.InboundsRectangle.Intersects(targetRectangle))
            {
                oldtargetRectangle = targetRectangle;
                int midpointX = targetRectangle.X + targetRectangle.Width/2;
                int midpointY = targetRectangle.Y + targetRectangle.Height / 2;
                int characterMidX = MainCharacterState.InboundsRectangle.X + MainCharacterState.InboundsRectangle.Width / 2;
                int characterMidY = MainCharacterState.InboundsRectangle.Y + MainCharacterState.InboundsRectangle.Height / 2;
                int difx = midpointX - characterMidX;
                int dify = midpointY - characterMidY;
                Console.WriteLine("X = " + difx + " y = " + dify);
                int absx = Math.Abs(difx);
                int absy = Math.Abs(dify);
                if (difx > dify)
                {
                    if (absx > absy)
                    {
                        //colision left
                        targetRectangle = new Rectangle(targetRectangle.X+4, targetRectangle.Y, targetRectangle.Width, targetRectangle.Height);
                    }
                    else
                    {
                        //bot
                        targetRectangle = new Rectangle(targetRectangle.X, targetRectangle.Y-4, targetRectangle.Width, targetRectangle.Height);
                    }
                }
                else
                {
                    if (absx > absy)
                    {
                        //colision right
                        targetRectangle = new Rectangle(targetRectangle.X-4, targetRectangle.Y, targetRectangle.Width, targetRectangle.Height);
                    }
                    else
                    {
                        //top
                        targetRectangle = new Rectangle(targetRectangle.X, targetRectangle.Y+4, targetRectangle.Width, targetRectangle.Height);
                    }
                }
                foreach (Rectangle r in game.DungeonRooms.getCurrentRoom().Colliable){
                    if (r.Intersects(targetRectangle))
                    {
                        targetRectangle = oldtargetRectangle;
                    }
                }
                
                

            }
        }
    }
}

