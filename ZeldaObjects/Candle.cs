

using Microsoft.Xna.Framework;
using System;

namespace Zelda.RoomRoomObjects
{
    public class Candle : Iitem
    {
        private Rectangle sourceRectangle;
        private Rectangle targetRectangle;

        Game1 game;
        public Candle(Game1 game, int xPosition, int yPosition)
        {
            this.sourceRectangle = new Rectangle(644, 137, 8, 16);
            this.targetRectangle = new Rectangle(xPosition, yPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);  

            this.game = game;
        }
        public void Draw()
        {
            game.SpriteBatch.Draw(game.Textures.PauseScreen, targetRectangle, sourceRectangle, Color.White);
        }

        public void Update()
        {
            Console.WriteLine("Updating");
            if (game.mainCharacter.location().Intersects(targetRectangle))
            {
                if (!MainCharacterState.InventoryItems.ContainsKey(Constants.items.Candle))
                {
                    MainCharacterState.InventoryItems.Add(Constants.items.Candle, 1);
                }
                
                game.DungeonRooms.RemoveItem(this);
                SoundLoader.pickItem.Play();
            }
        }
    }
}
