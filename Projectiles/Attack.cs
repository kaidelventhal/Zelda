using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Zelda.RoomRoomObjects;


namespace Zelda.Projectiles
{
    public class Attack : IProjectile
    {
        
        private Rectangle sourceRectangle;
        private Rectangle positionRectangle;
        private Rectangle initialPositon; 
        private Game1 game;
        private int Xpos;
        private int Ypos;
        private Vector2 dir;
        private int speed;
        private int time;
        private Boolean enemyProjectile;
        private int frame;


        public Attack(Game1 game, int Xpos,int Ypos, Vector2 dir,Boolean enemyProjectile)
          
        {
            this.enemyProjectile = enemyProjectile;
            this.game = game;
            
            if (MainCharacterState.LDir.X == -1)
            {
                
                sourceRectangle = new Rectangle(46, 38, 18, 20);
                positionRectangle = new Rectangle(Xpos, Ypos, sourceRectangle.Width*4, sourceRectangle.Height*4);
                initialPositon = new Rectangle(Xpos-120, Ypos, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
            }
            else if (MainCharacterState.LDir.X == 1)
            {
               
                sourceRectangle = new Rectangle(74, 38, 18, 20);
                positionRectangle = new Rectangle(Xpos+120, Ypos, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
            }
            else if (MainCharacterState.LDir.Y == -1)
            {
                
                sourceRectangle = new Rectangle(5, 38, 17, 20);
                positionRectangle = new Rectangle(Xpos, Ypos-120, sourceRectangle.Width * 4, sourceRectangle.Height * 4);

            }
            else if (MainCharacterState.LDir.Y == 1)
            {

                sourceRectangle = new Rectangle(22, 38, 17, 20);
                positionRectangle = new Rectangle(Xpos, Ypos+120, sourceRectangle.Width * 4, sourceRectangle.Height * 4);
            }

            
            speed = 0;
            this.Xpos = Xpos;
            this.Ypos = Ypos;
            this.dir = dir;
            this.time = 0;
            frame = 0;
            

        }


        public void Draw()
        {
            game.SpriteBatch.Draw(game.Textures.Items, positionRectangle, sourceRectangle, Color.White);
        }

        public void Update()
        {
            if(frame++ == 40)
            {
                speed = 10;
            }
            time++;
            Rectangle wallRectangle = new Rectangle(positionRectangle.X+ positionRectangle.Width / 4, positionRectangle.Y+ positionRectangle.Width / 4, positionRectangle.Width / 2, positionRectangle.Height / 2);
            if (CollisionHandler.hitsWall(game, wallRectangle) &&frame>40)
            {
                game.DungeonRooms.AddProjectile(new AttackExplosion(game, positionRectangle.X, positionRectangle.Y));
                GameProjectiles.Projectiles.Remove(this);
            }
            
            Xpos += (int)dir.X*speed;
            Ypos += (int)dir.Y*speed;
            positionRectangle = new Rectangle(Xpos, Ypos, positionRectangle.Width, positionRectangle.Height);
        }

        public bool HitsProjectile(Rectangle hitbox, bool enemy)
        {
            if (!enemy) { return false; }
            bool result;
            if (frame < 20)
            {
                return false;
            }else if (frame < 40)
            {
                result = (enemy != enemyProjectile && hitbox.Intersects(initialPositon));
            }
            else
            {
                result = (enemy != enemyProjectile && hitbox.Intersects(positionRectangle));
            }
           
            if (result)
            {
                game.DungeonRooms.AddProjectile(new AttackExplosion(game, positionRectangle.X, positionRectangle.Y));
                GameProjectiles.Projectiles.Remove(this);
            }
            return result;
        }
    }
}
