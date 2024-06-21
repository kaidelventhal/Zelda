using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zelda.Rooms;




namespace Zelda
{
    public class KeyDoor : ISprite
    {
        private Rectangle sourceRectangle;
        private Rectangle targetRectangle;
        private Rectangle collisionRectangle;
        Boolean InitializedCollision;
        private int room;
        Game1 game;
        public KeyDoor(Game1 game, string side, int room)
        {

            switch (side)
            {
                case "left":
                    this.sourceRectangle = new Rectangle(881, 44, 32, 32);
                    this.targetRectangle = new Rectangle(0 + Constants.dungeonLoaderOffsetX, 305 + Constants.dungeonLoaderOffsetY, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                    collisionRectangle = new Rectangle(targetRectangle.X, targetRectangle.Y, targetRectangle.Width, targetRectangle.Height);

                    break;
                case "right":
                    this.sourceRectangle = new Rectangle(881, 77, 32, 32);
                    this.targetRectangle = new Rectangle(896 + Constants.dungeonLoaderOffsetX, 305 + Constants.dungeonLoaderOffsetY, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                    collisionRectangle = new Rectangle(targetRectangle.X, targetRectangle.Y, targetRectangle.Width, targetRectangle.Height);


                    break;
                case "top":
                    this.sourceRectangle = new Rectangle(881, 11, 32, 32);
                    this.targetRectangle = new Rectangle(450 + Constants.dungeonLoaderOffsetX, 0 + Constants.dungeonLoaderOffsetY, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                    collisionRectangle = new Rectangle(targetRectangle.X, targetRectangle.Y, targetRectangle.Width, targetRectangle.Height + 5);


                    break;
                case "bottom":
                    this.sourceRectangle = new Rectangle(881, 110, 32, 32);
                    this.targetRectangle = new Rectangle(450 + Constants.dungeonLoaderOffsetX, 576 + Constants.dungeonLoaderOffsetY, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
                    collisionRectangle = new Rectangle(targetRectangle.X, targetRectangle.Y, targetRectangle.Width, targetRectangle.Height);


                    break;
                default: Console.WriteLine("invalid keydoor side " + side); break;
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
            if (!InitializedCollision)
            {
                game.DungeonRooms.getCurrentRoom().Colliable.Add(collisionRectangle);
                InitializedCollision = true;
            }
            if (MainCharacterState.InboundsRectangle.Intersects(collisionRectangle) && MainCharacterState.InventoryItems[Constants.items.Key] > 0)
            {
                MainCharacterState.InventoryItems[Constants.items.Key]--;
                game.DungeonRooms.RemoveItem(this);
                game.DungeonRooms.getCurrentRoom().Colliable.Remove(collisionRectangle);
                
            }
        }
    }
}