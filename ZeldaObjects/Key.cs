

using Microsoft.Xna.Framework;
using System.Runtime.CompilerServices;

namespace Zelda.RoomRoomObjects
{
    public class Key : Iitem
    {
        private Rectangle sourceRectangle;
        private Rectangle spawnRectangle;
        private Rectangle destinationRectangle;

        bool spawnWhenAllDead;
        Game1 game;
        
        public Key(Game1 game, int xPosition, int yPosition, bool spawnWhenAllDead)
        {
            this.sourceRectangle = new Rectangle(240, 0, 8, 16);
            this.spawnRectangle = new Rectangle(xPosition, yPosition, sourceRectangle.Width * 4, sourceRectangle.Height * 4);  
            this.spawnWhenAllDead = spawnWhenAllDead;
            destinationRectangle = spawnRectangle;
            if (spawnWhenAllDead)
            {
                destinationRectangle = new Rectangle(0, 0, 0, 0);
            }
            
            this.game = game;
        }
        public void Draw()
        {
            game.SpriteBatch.Draw(game.Textures.Items, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update()
        {
            if (spawnWhenAllDead && game.DungeonRooms.getCurrentRoom().Enemies.EnemiesLeft() == 0)
            {
                destinationRectangle = spawnRectangle;
            }
            
            if (game.mainCharacter.location().Intersects(destinationRectangle))
            {
                MainCharacterState.InventoryItems[Constants.items.Key]++;
                game.DungeonRooms.RemoveItem(this);
                SoundLoader.pickItem.Play();
            }
        }
    }
}
