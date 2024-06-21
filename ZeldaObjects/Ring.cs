

using Microsoft.Xna.Framework;
using System;

namespace Zelda.RoomRoomObjects
{
    public class Ring : Iitem
    {
        private Rectangle sourceRectangle;
        private Rectangle targetRectangle;

        Game1 game;
        public Ring(Game1 game, int xPosition, int yPosition)
        {
            this.sourceRectangle = new Rectangle(169, 3, 8,10);
            this.targetRectangle = new Rectangle(xPosition, yPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);  

            this.game = game;
        }
        public void Draw()
        {
            game.SpriteBatch.Draw(game.Textures.Items, targetRectangle, sourceRectangle, Color.White);
        }

        public void Update()
        {
            if (game.mainCharacter.location().Intersects(targetRectangle))
            {
                if (!MainCharacterState.InventoryItems.ContainsKey(Constants.items.Ring))
                {
                    MainCharacterState.InventoryItems.Add(Constants.items.Ring, 1);
                }
                
                game.DungeonRooms.RemoveItem(this);
                SoundLoader.pickItem.Play();
            }
        }
    }
}
