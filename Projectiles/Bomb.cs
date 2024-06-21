using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace Zelda.Projectiles
{
    public class Bomb : IProjectile
    {
        private Rectangle sourceRectangle;
        private Rectangle[] explosion;
        private Rectangle positionRectangle;
        private Rectangle hitboxRectange;
        private Game1 game;
        private int Xpos;
        private int Ypos;
        private Vector2 dir;
        private int speed;
        private int time;
        private Boolean enemyProjectile;

        public Bomb(Game1 game, int Xpos, int Ypos, Vector2 dir,Boolean enemyProjectile)

        {
            Xpos += Constants.ShootOffsetX;
            Ypos += Constants.ShootOffsetY;
            this.game = game;
            this.enemyProjectile = enemyProjectile;
            sourceRectangle = new Rectangle(487, 267, 30, 16);
            positionRectangle = new Rectangle(Xpos, Ypos, 60, 32);
  
            explosion = new Rectangle[3];
            explosion[0] = new Rectangle(915, 310, 25, 25);
            explosion[1] = new Rectangle(984, 302, 47, 42);
            explosion[2] = new Rectangle(1033, 302, 47, 42);
            hitboxRectange = new Rectangle(0, 0, 0, 0);
            speed = Constants.bombSpeed;
            this.Xpos = Xpos;
            this.Ypos = Ypos;
            this.dir = dir;
            time = 0;
            

        }


        public void Draw()
        {
            game.SpriteBatch.Draw(game.Textures.PlayerTexture, positionRectangle, sourceRectangle, Color.White,90.0F,new Vector2(12,6),SpriteEffects.None,1.0F);
        }

        public bool HitsProjectile(Rectangle hitbox, bool enemy)
        {
            return (enemy != enemyProjectile && hitbox.Intersects(hitboxRectange));
        }

        public void Update()
        {
            if (time == Constants.bombDeleteTime)
            {
                GameProjectiles.Projectiles.Remove(this);
            }
            if(CollisionHandler.hitsWall(game, positionRectangle))
            {
                speed = 0;
            }
            if (time < Constants.bombExplodeTime)
            {
                Xpos += (int)dir.X*speed;
                Ypos += (int)dir.Y*speed;

                positionRectangle = new Rectangle(Xpos, Ypos, 60, 32);
            }
            else
            {
                if (time < 32)
                {
                    
                    sourceRectangle = explosion[0];
                    positionRectangle = new Rectangle(Xpos, Ypos, 25, 25);
                }
                else if (time < 40)
                {
                    sourceRectangle = explosion[1];
                    hitboxRectange = new Rectangle(Xpos-25, Ypos-25, 100, 100);
                    positionRectangle = new Rectangle(Xpos, Ypos, 50, 50);
                }
                else
                {
                    sourceRectangle = explosion[2];
                    positionRectangle = new Rectangle(Xpos, Ypos, 60, 60);
                }
            }
            time++;
            
        }
        
        }
    }

