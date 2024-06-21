

using Microsoft.Xna.Framework;
using System;

namespace Zelda.ZeldaItems
{
    public class BossDeathExplosion : Iitem
    {
        private Rectangle sourceRectangle;
        private Rectangle currentSource;
        private Rectangle targetRectangle;
        
        private int room;
        private int time;
        Game1 game;
        public BossDeathExplosion(Game1 game, int xPosition, int yPosition, int room)
        {
            Console.WriteLine("BBossDeathExplosio creat");
            sourceRectangle = new Rectangle(0, 0, 272, 316);
            targetRectangle = new Rectangle(xPosition, yPosition, 100, 100);

            this.room = room;
            this.game = game;
            time++;
        }
        public void Draw()
        {
            game.SpriteBatch.Draw(game.Textures.BossDeath, targetRectangle, sourceRectangle, Color.White);
        }

        public void Update()
        {

            if (time == 8)
            {
                game.DungeonRooms.RemoveItem(this);
            }
        }
    }
}
