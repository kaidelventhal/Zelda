

using Microsoft.Xna.Framework;
using System;

namespace Zelda.RoomRoomObjects
{
    public class BoomerangItem : Iitem
    {
        private Rectangle sourceRectangle;
        private Rectangle spawnRectangle;
        private Rectangle destinationRectangle;
        private bool spawnWhenAllDead;
        Game1 game;
        public BoomerangItem(Game1 game, int xPosition, int yPosition, bool spawnWhenAllDead)
        {
            this.sourceRectangle = new Rectangle(128, 2, 7, 10);
            this.spawnRectangle = new Rectangle(xPosition, yPosition, sourceRectangle.Width * 6, sourceRectangle.Height * 6);
            destinationRectangle = spawnRectangle;
            if(spawnWhenAllDead)
            {
                destinationRectangle = new Rectangle(0, 0, 0, 0);
            }
            this.spawnWhenAllDead = spawnWhenAllDead;
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
                MainCharacterState.InventoryItems.TryAdd(Constants.items.Boomerang,1);
                game.DungeonRooms.RemoveItem(this);
            }
            
        }
    }
}
