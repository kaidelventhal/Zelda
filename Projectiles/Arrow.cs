using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace Zelda.Projectiles
{
    public class Arrow : IProjectile
    {
        
        private Rectangle sourceRectangle;
        private Rectangle positionRectangle;
        private Rectangle hitboxRectangle;
        private Game1 game;
        private int Xpos;
        private int Ypos;
        private Vector2 dir;
        private int speed;
        private float rotation;
        private int time;
        private Boolean enemyProjectile;


        public Arrow(Game1 game, int Xpos,int Ypos, Vector2 dir,Boolean enemyProjectile)
        {
            this.enemyProjectile = enemyProjectile;
            this.game = game;
            sourceRectangle = new Rectangle(154, 0, 5, 16);         
            speed = Constants.arrowSpeed;          
            this.dir = dir;
            rotation = 0.0F;
            time = 0;

            if (dir.X == -1)
            {
                rotation = 4.71F;
                this.Xpos = Xpos;
                this.Ypos = Ypos+35;
                hitboxRectangle = new Rectangle(Xpos, Ypos - positionRectangle.Width, positionRectangle.Height, positionRectangle.Width);
            }
            else if (dir.X == 1)
            {
                this.Xpos = Xpos+60;
                this.Ypos = Ypos+25;
                rotation = 1.57F;
                hitboxRectangle = new Rectangle(Xpos - positionRectangle.Height, Ypos, positionRectangle.Height, positionRectangle.Width);
            }
            else if (dir.Y == 1)
            {
                this.Xpos = Xpos+24;
                this.Ypos = Ypos+48;
                rotation = 3.14F;
                hitboxRectangle = new Rectangle(Xpos - positionRectangle.Width, Ypos - positionRectangle.Height, positionRectangle.Width, positionRectangle.Height);
            }
            else if (dir.Y == -1)
            {
                this.Xpos = Xpos+30;
                this.Ypos = Ypos;
                rotation = 0F;
                hitboxRectangle = positionRectangle;
            }
            positionRectangle = new Rectangle(Xpos, Ypos, sourceRectangle.Width * 3, sourceRectangle.Height * 3);
            Update();
        }


        public void Draw()
        {           
            game.SpriteBatch.Draw(game.Textures.Items, positionRectangle, sourceRectangle, Color.White,rotation,new Vector2(0,0),SpriteEffects.None,1.0F);
        }

        public void Update()
        {
            time++;
            
            Xpos += (int)dir.X*speed;
            Ypos += (int)dir.Y*speed;
            positionRectangle = new Rectangle(Xpos, Ypos, positionRectangle.Width, positionRectangle.Height);
            if (dir.X == -1)
            {
                rotation = 4.71F;
                hitboxRectangle = new Rectangle(Xpos, Ypos - positionRectangle.Width, positionRectangle.Height, positionRectangle.Width);

            }
            else if (dir.X == 1)
            {
                rotation = 1.57F;
                hitboxRectangle = new Rectangle(Xpos-positionRectangle.Height, Ypos, positionRectangle.Height, positionRectangle.Width);
            }
            else if (dir.Y == 1)
            {
                rotation = 3.14F;
                hitboxRectangle = new Rectangle(Xpos-positionRectangle.Width,Ypos - positionRectangle.Height,positionRectangle.Width,positionRectangle.Height);
            }
            else if (dir.Y == -1)
            {
                rotation = 0F;
                hitboxRectangle = positionRectangle;
            }
            if (CollisionHandler.hitsWall(game, hitboxRectangle))
            {
                speed = 0;
            }
            if (time == 200)
            {
                GameProjectiles.Projectiles.Remove(this);
            }
        }

        public bool HitsProjectile(Rectangle hitbox, bool enemy)
        {
            return (enemy != enemyProjectile && hitbox.Intersects(hitboxRectangle));
        }
    }
}
