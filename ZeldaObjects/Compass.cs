

using Microsoft.Xna.Framework;

namespace Zelda.RoomRoomObjects
{
    public class Compass : Iitem
    {
        private Rectangle sourceRectangle;
        private Rectangle targetRectangle;
        
        
        Game1 game;
        public Compass(Game1 game, int xPosition, int yPosition)
        {
            this.sourceRectangle = new Rectangle(258, 0, 11, 13);
            this.targetRectangle = new Rectangle(xPosition, yPosition, sourceRectangle.Width * 5, sourceRectangle.Height * 5);  
            
            
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
                
                MainCharacterState.InventoryItems.TryAdd(Constants.items.Compass,1);
                
                
                game.DungeonRooms.RemoveItem(this);
                SoundLoader.pickItem.Play();
            }
        }
    }
}
