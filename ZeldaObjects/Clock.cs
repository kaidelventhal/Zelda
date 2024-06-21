

using Microsoft.Xna.Framework;
using System.Runtime.CompilerServices;

namespace Zelda.RoomRoomObjects
{
    public class Clock : Iitem
    {
        private Rectangle sourceRectangle;

        private Rectangle destinationRectangle;

        Game1 game;
        
        public Clock(Game1 game, int xPosition, int yPosition)
        {
            this.sourceRectangle = new Rectangle(56, 0, 14, 17);
            this.destinationRectangle = new Rectangle(xPosition, yPosition, sourceRectangle.Width * 3, sourceRectangle.Height * 3);  

           
            this.game = game;
        }
        public void Draw()
        {
            game.SpriteBatch.Draw(game.Textures.Items, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update()
        {
            
            if (game.mainCharacter.location().Intersects(destinationRectangle))
            {
                game.DungeonRooms.getCurrentRoom().pauseEnemies = 75;
                game.DungeonRooms.RemoveItem(this);
                SoundLoader.pickItem.Play();
            }
        }
    }
}
