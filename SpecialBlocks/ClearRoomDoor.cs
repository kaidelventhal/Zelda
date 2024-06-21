using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zelda.Rooms;




namespace Zelda
{
    public class ClearRoomDoor : ISprite
    {
        private Rectangle sourceRectangle;
        private Rectangle targetRectangle;
        private Rectangle collisionRectangle;
        Boolean InitializedCollision;
        private int room;
        private Boolean moveBlock;
        private Rectangle moveRectangle;
        Game1 game;
        public ClearRoomDoor(Game1 game, string side, int room,Boolean moveBlock)
        {
            this.moveBlock = moveBlock;
            moveRectangle = new Rectangle(478+Constants.dungeonLoaderOffsetX,350+Constants.dungeonLoaderOffsetY,2,2);
            switch (side) 
            {
                case "left":
                    this.sourceRectangle = new Rectangle(914, 44, 32, 32);
                    this.targetRectangle = new Rectangle(0+Constants.dungeonLoaderOffsetX, 305+Constants.dungeonLoaderOffsetY, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                    collisionRectangle = new Rectangle(targetRectangle.X, targetRectangle.Y, targetRectangle.Width, targetRectangle.Height);
                    
                    break;
                case "right":
                    this.sourceRectangle = new Rectangle(914, 77, 32, 32);
                    this.targetRectangle = new Rectangle(896 + Constants.dungeonLoaderOffsetX, 305 + Constants.dungeonLoaderOffsetY, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                    collisionRectangle = new Rectangle(targetRectangle.X, targetRectangle.Y, targetRectangle.Width, targetRectangle.Height);
                    
                    
                    break;
                case "top":
                    this.sourceRectangle = new Rectangle(914, 11, 32, 32);
                    this.targetRectangle = new Rectangle(450+Constants.dungeonLoaderOffsetX, 0+Constants.dungeonLoaderOffsetY, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                    collisionRectangle = new Rectangle(targetRectangle.X, targetRectangle.Y, targetRectangle.Width, targetRectangle.Height + 5);
                   
                    
                    break;
                case "bottom":
                    this.sourceRectangle = new Rectangle(914, 110, 32, 32);
                    this.targetRectangle = new Rectangle(450 + Constants.dungeonLoaderOffsetX, 576 + Constants.dungeonLoaderOffsetY, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                    collisionRectangle = new Rectangle(targetRectangle.X, targetRectangle.Y, targetRectangle.Width, targetRectangle.Height);
                    
                    
                    break;
                default: Console.WriteLine("invalid clearRoomDoor side " + side); break;
            }

                
            
            InitializedCollision = false;
            
            this.room = room;
            this.game = game;
            
        }
        public void Draw()
        {
            game.SpriteBatch.Draw(game.Textures.GameBoardTexture, targetRectangle, sourceRectangle, Color.White);
            
        }

        public void Update()
        {
            if(!InitializedCollision)
            {
                game.DungeonRooms.getCurrentRoom().Colliable.Add(collisionRectangle);
                InitializedCollision = true;
            }
            if (moveBlock)
            {
                if (MainCharacterState.DestinationRectangle.Intersects(moveRectangle)){
                    game.DungeonRooms.RemoveItem(this);
                    game.DungeonRooms.getCurrentRoom().Colliable.Remove(collisionRectangle);
                }
            }
            else if (game.DungeonRooms.getCurrentRoom().Enemies.EnemiesLeft()==0)
            {
                
                game.DungeonRooms.RemoveItem(this);
                game.DungeonRooms.getCurrentRoom().Colliable.Remove(collisionRectangle);
                
            }
        }
    }
}

