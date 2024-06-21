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
    public class Boomerang : IProjectile
    {
        private Rectangle sourceRectangle;
        private Rectangle positionRectangle;
        private Game1 game;
        private int Xpos;
        private int Ypos;
        private Vector2 dir;
        private int speed;
        private int time;
        private float rotation;
        private Boolean enemyProjectile;

        public Boomerang(Game1 game, int Xpos, int Ypos, Vector2 dir, Boolean enemyProjectile)

        {
            Xpos += Constants.ShootOffsetX;
            Ypos += Constants.ShootOffsetY;
            this.game = game;
            this.enemyProjectile = enemyProjectile;
            sourceRectangle = new Rectangle(507, 213, 24, 12);
            positionRectangle = new Rectangle(Xpos, Ypos, 48, 24);
            speed = Constants.boomerangSpeed;
            rotation = 0.0F;
            this.Xpos = Xpos;
            this.Ypos = Ypos;
            this.dir = dir;
            time = 0;
        }


        public void Draw()
        {
            game.SpriteBatch.Draw(game.Textures.PlayerTexture, positionRectangle, sourceRectangle, Color.White, rotation, new Vector2(12, 6), SpriteEffects.None, 1.0F);
        }

        public bool HitsProjectile(Rectangle hitbox, bool enemy)
        {
            return (enemy != enemyProjectile && hitbox.Intersects(positionRectangle));
        }

        public void Update()
        {
            time++;
            if (time == Constants.boomerangDeleteTime||CollisionHandler.hitsWall(game, positionRectangle))
            {
                if (!enemyProjectile)
                {
                    
                     MainCharacterState.InventoryItems.TryAdd(Constants.items.Boomerang,1);
                    
                }
                GameProjectiles.Projectiles.Remove(this);
            }
            if(time == Constants.boomerangReverseTime)
            {
                speed = -speed;
            }
            rotation += Constants.boomerangRotationSpeed;
            Xpos += (int)dir.X*speed;
            Ypos += (int)dir.Y*speed;
            positionRectangle = new Rectangle(Xpos, Ypos, 48, 24);



        }
    }
}
