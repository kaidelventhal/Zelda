

using Microsoft.Xna.Framework;

namespace Zelda.RoomRoomObjects
{
    public class Rupee : Iitem
    {
        private Rectangle[] sourceRectangle;
        private Rectangle targetRectangle;
        private int frame;
        
        Game1 game;
        public Rupee(Game1 game, int xPosition, int yPosition)
        {
            this.sourceRectangle = new Rectangle[2];
            this.sourceRectangle[0] = new Rectangle(72, 0, 8, 16);
            this.sourceRectangle[1] = new Rectangle(72, 16, 8, 16);
            this.targetRectangle = new Rectangle(xPosition, yPosition, sourceRectangle[0].Width * 3, sourceRectangle[0].Height * 3);

            frame = 0;
            this.game = game;
        }
        public void Draw()
        {
            game.SpriteBatch.Draw(game.Textures.Items, targetRectangle, sourceRectangle[frame++/10%2], Color.White);
        }

        public void Update()
        {
            if (game.mainCharacter.location().Intersects(targetRectangle))
            {
                MainCharacterState.InventoryItems[Constants.items.Rupee]++;
                game.DungeonRooms.RemoveItem(this);
                SoundLoader.pickItem.Play();
            }
        }
    }
}
