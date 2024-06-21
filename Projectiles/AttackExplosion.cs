

using Microsoft.Xna.Framework;

namespace Zelda.Projectiles
{
    public class AttackExplosion : IProjectile
    {
        private Rectangle[] sourceRectangle;
        private Rectangle[] positionRectangle;


        private int time;
        private int speed;
        Game1 game;
        public AttackExplosion(Game1 game, int xPosition, int yPosition)
        {
            sourceRectangle = new Rectangle[4];
            sourceRectangle[0] = new Rectangle(7, 67, 15, 19);//topleft
            sourceRectangle[1] = new Rectangle(26, 68, 15, 19);//bottom right
            sourceRectangle[2] = new Rectangle(43, 70, 19, 15);//bottom left
            sourceRectangle[3] = new Rectangle(64, 68, 19, 15);//bottom right
            positionRectangle = new Rectangle[4];
            positionRectangle[0] = new Rectangle(xPosition, yPosition, sourceRectangle[0].Width * 2, sourceRectangle[0].Height * 2);
            positionRectangle[1] = new Rectangle(xPosition, yPosition, sourceRectangle[1].Width * 2, sourceRectangle[1].Height * 2);
            positionRectangle[2] = new Rectangle(xPosition, yPosition, sourceRectangle[2].Width * 2, sourceRectangle[2].Height * 2);
            positionRectangle[3] = new Rectangle(xPosition, yPosition, sourceRectangle[3].Width * 2, sourceRectangle[3].Height * 2);
            time = 0;
            speed = 6;
            this.game = game;
        }
        public void Draw()
        {
            int i = 0;
            foreach (Rectangle r in sourceRectangle)
            {
                game.SpriteBatch.Draw(game.Textures.Items, positionRectangle[i++], r, Color.White);
            }

        }

        public bool HitsProjectile(Rectangle hitbox, bool enemy)
        {
            if (!enemy)
            {
                return false;
            }
            return hitbox.Intersects(positionRectangle[0]) || hitbox.Intersects(positionRectangle[1]) || hitbox.Intersects(positionRectangle[2]) || hitbox.Intersects(positionRectangle[3]);
        }

        public void Update()
        {
            time++;
            for (int i = 0; i < 4; i++)
            {
                switch (i)
                {
                    case 0:
                        positionRectangle[i].X -= speed;
                        positionRectangle[i].Y -= speed;
                        break;
                    case 1:
                        positionRectangle[i].X += speed;
                        positionRectangle[i].Y += speed;
                        break;
                    case 2:
                        positionRectangle[i].X -= speed;
                        positionRectangle[i].Y += speed;
                        break;
                    case 3:
                        positionRectangle[i].X += speed;
                        positionRectangle[i].Y -= speed;
                        break;
                    default:
                        break;
                }

            }
            if (time == 15)
            {
                game.DungeonRooms.RemoveProjectile(this);
            }
        }

    }
}
