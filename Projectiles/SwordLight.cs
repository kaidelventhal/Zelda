using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Zelda.Enemies;


namespace Zelda.Projectiles
{
    public class SwordLight : IProjectile
    {
        private Rectangle sourceRectangle;
        private Rectangle currentSource;
        private Rectangle positionRectangle;
        private Game1 game;
        private int Xpos;
        private int Ypos;
        private Vector2 dir;
        private int speed;
        private int time;
        private float rotation;
        private Boolean enemyProjectile;
        private Vector2 position;

        public SwordLight(Game1 game, int Xpos, int Ypos, Vector2 dir, Boolean enemyProjectile)

        {
            Xpos += Constants.ShootOffsetX;
            Ypos += Constants.ShootOffsetY;
            this.game = game;
            this.enemyProjectile = enemyProjectile;
            sourceRectangle = new Rectangle(0, 0, 48, 139);
            currentSource = new Rectangle(0, 0, 48, 139);
            positionRectangle = new Rectangle(Xpos, Ypos, 82, 40);
            speed = Constants.mFireballSpeed;
            this.Xpos = Xpos;
            this.Ypos = Ypos;
            this.dir = dir;
            time = 0;
            rotation = BossSword.rotation;
            Console.WriteLine("Swordlight creat");
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


            Console.WriteLine(dir + "2");

            Xpos += (int)dir.X * speed /300;
            Ypos += (int)dir.Y * speed /300;
            positionRectangle = new Rectangle(Xpos, Ypos, positionRectangle.Width, positionRectangle.Height);
            position.X = Xpos;
            position.Y = Ypos;

        }

        public virtual void Draw()
        {
            game.SpriteBatch.Draw(game.Textures.BOSSSword1, position, sourceRectangle, Color.White, rotation, new Vector2(50 / 2, 100 / 2), 1.0f, SpriteEffects.None, 0f);


        }
    }
}
