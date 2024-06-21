using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;





namespace Zelda
{
    public class ExplodedDoor : ISprite
    {
        private Rectangle sourceRectangle;
        private Rectangle targetRectangle;
        private Rectangle collisionRectangle;
        Boolean InitializedCollision;
        private int room;
        Game1 game;

        public ExplodedDoor(Game1 game, string side, int room)
        {
            InitializedCollision = false;
            switch (side)
            {
                case "left":
                    this.sourceRectangle = new Rectangle(815, 44, 32, 32);
                    this.targetRectangle = new Rectangle(0 + Constants.dungeonLoaderOffsetX, 305 + Constants.dungeonLoaderOffsetY, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                    collisionRectangle = new Rectangle(targetRectangle.X, targetRectangle.Y, targetRectangle.Width, targetRectangle.Height);

                    break;
                case "right":
                    this.sourceRectangle = new Rectangle(815, 77, 32, 32);
                    this.targetRectangle = new Rectangle(896 + Constants.dungeonLoaderOffsetX, 305 + Constants.dungeonLoaderOffsetY, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                    collisionRectangle = new Rectangle(targetRectangle.X, targetRectangle.Y, targetRectangle.Width, targetRectangle.Height);


                    break;
                case "top":
                    this.sourceRectangle = new Rectangle(815, 11, 32, 32);
                    this.targetRectangle = new Rectangle(450 + Constants.dungeonLoaderOffsetX, 0 + Constants.dungeonLoaderOffsetY, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                    collisionRectangle = new Rectangle(targetRectangle.X, targetRectangle.Y, targetRectangle.Width, targetRectangle.Height + 5);


                    break;
                case "bottom":
                    this.sourceRectangle = new Rectangle(815, 110, 32, 32);
                    this.targetRectangle = new Rectangle(450 + Constants.dungeonLoaderOffsetX, 576 + Constants.dungeonLoaderOffsetY, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                    collisionRectangle = new Rectangle(targetRectangle.X, targetRectangle.Y, targetRectangle.Width, targetRectangle.Height);


                    break;
                default: Console.WriteLine("invalid clearRoomDoor side " + side); break;
            }
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
            if (game.DungeonRooms.HitsProjectile(targetRectangle, true, "Zelda.Projectiles.Bomb"))
            {
                
                game.DungeonRooms.RemoveItem(this);
                game.DungeonRooms.getCurrentRoom().Colliable.Remove(collisionRectangle);
            }
        }
    }
}

