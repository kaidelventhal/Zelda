

using Microsoft.Xna.Framework;

namespace Zelda.RoomRoomObjects
{
    public class ArrowItem : Iitem
    {
        private Rectangle sourceRectangle;
        private Rectangle targetRectangle;

        Game1 game;
        public ArrowItem(Game1 game, int xPosition, int yPosition)
        {
            this.sourceRectangle = new Rectangle(154, 0, 5, 16);
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
                game.DungeonRooms.RemoveItem(this);
            }
        }
    }
}
