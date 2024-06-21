

using Microsoft.Xna.Framework;

namespace Zelda.RoomRoomObjects
{
    public class Bow : Iitem
    {
        private Rectangle sourceRectangle;
        private Rectangle targetRectangle;
        
  
        Game1 game;
        public Bow(Game1 game, int xPosition, int yPosition)
        {
            this.sourceRectangle = new Rectangle(144, 0, 8, 16);
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
                
                MainCharacterState.InventoryItems.TryAdd(Constants.items.Bow,1);
                
                game.DungeonRooms.RemoveItem(this);
                SoundLoader.pickItem.Play();
            }
        }
    }
}
