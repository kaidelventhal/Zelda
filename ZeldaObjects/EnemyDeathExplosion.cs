

using Microsoft.Xna.Framework;

namespace Zelda.RoomRoomObjects
{
    public class EnemyDeathExplosion : ISprite
    {
        private Rectangle[] sourceRectangle;
        private Rectangle currentSource;
        private Rectangle targetRectangle;
        

        private int time;
        Game1 game;
        public EnemyDeathExplosion(Game1 game, int xPosition, int yPosition)
        {
            this.sourceRectangle = new Rectangle[4];
            sourceRectangle[0] = new Rectangle(987, 363, 22, 22);
            sourceRectangle[1] = new Rectangle(1013, 363, 22, 22);
            sourceRectangle[2] = new Rectangle(1039, 363, 22, 22);
            sourceRectangle[3] = new Rectangle(1064, 364, 22, 22);
            currentSource = sourceRectangle[0];
            this.targetRectangle = new Rectangle(xPosition, yPosition, currentSource.Width * 2, currentSource.Height * 2);
            time++;

            this.game = game;
        }
        public void Draw()
        {
            game.SpriteBatch.Draw(game.Textures.PlayerTexture, targetRectangle, currentSource, Color.White);
        }

        public void Update()
        {
            currentSource = sourceRectangle[time++/10%4];
            if (time == 40)
            {
                game.DungeonRooms.RemoveItem(this);
            }
        }
    }
}
