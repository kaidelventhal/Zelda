

using Microsoft.Xna.Framework;
using System.ComponentModel.Design;

namespace Zelda.RoomRoomObjects
{
    public class BombItem : Iitem
    {
        private Rectangle sourceRectangle;
        private Rectangle targetRectangle;

        Game1 game;
        public BombItem(Game1 game, int xPosition, int yPosition)
        {
            this.sourceRectangle = new Rectangle(136, 0, 8, 14);
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
                if (MainCharacterState.InventoryItems.ContainsKey(Constants.items.Bomb)){
                    MainCharacterState.InventoryItems[Constants.items.Bomb]++;
                }
                else
                {
                    MainCharacterState.InventoryItems.Add(Constants.items.Bomb,1);
                }
               
                
                game.DungeonRooms.RemoveItem(this);
            }
        }
    }
}
