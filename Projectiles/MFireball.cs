using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace Zelda.Projectiles
{
    public class MFireball : IProjectile
    {
        private Rectangle[] sourceRectangle;
        private Rectangle currentSource;
        private Rectangle positionRectangle;
        private Game1 game;
        private int Xpos;
        private int Ypos;
        private Vector2 dir;
        private int speed;
        private int time;
        private Boolean enemyProjectile;

        public MFireball(Game1 game, int Xpos, int Ypos, Vector2 dir, Boolean enemyProjectile)

        {
            Xpos += Constants.ShootOffsetX;
            Ypos += Constants.ShootOffsetY;
            this.game = game;
            this.enemyProjectile = enemyProjectile;
            sourceRectangle = new Rectangle[3];
            sourceRectangle[0] = new Rectangle(119, 14, 8, 10);
            sourceRectangle[1] = new Rectangle(110, 14, 8, 10);
            sourceRectangle[2] = new Rectangle(128, 14, 8, 10);
            currentSource = sourceRectangle[0];
            positionRectangle = new Rectangle(Xpos, Ypos, 32, 40);
            speed = Constants.mFireballSpeed;
            this.Xpos = Xpos;
            this.Ypos = Ypos;
            this.dir = dir;
            time = 0;
        }


        public void Draw()
        {
            game.SpriteBatch.Draw(game.Textures.ZeldaBoses, positionRectangle, currentSource, Color.White);
        }

        public bool HitsProjectile(Rectangle hitbox, bool enemy)
        {
            return (enemy != enemyProjectile && hitbox.Intersects(positionRectangle));
        }

        

        public void Update()
        {
            time++;
            if (time == Constants.mFireballDeleteTime||CollisionHandler.hitsBoundry(game, positionRectangle))
            {
                GameProjectiles.Projectiles.Remove(this);
            }
            currentSource = sourceRectangle[time / 8 % 3];

            Xpos += (int)dir.X * speed;
            Ypos += (int)dir.Y * speed;
            positionRectangle = new Rectangle(Xpos, Ypos, positionRectangle.Width, positionRectangle.Height);



        }
    }
}
