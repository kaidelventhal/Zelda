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
    public class Flame : IProjectile
    {
        private Rectangle sourceRectangle;
        private Rectangle positionRectangle;
        private Game1 game;
        private int Xpos;
        private int Ypos;
        private Vector2 dir;
        private int speed;
        private int time;
        private Boolean enemyProjectile;
        private SpriteEffects effect;

        public Flame(Game1 game, int Xpos, int Ypos, Vector2 dir, Boolean enemyProjectile)

        {
            Xpos += Constants.ShootOffsetX;
            Ypos += Constants.ShootOffsetY;
            this.game = game;
            this.enemyProjectile = enemyProjectile;
            sourceRectangle = new Rectangle(93, 83, 15, 16);
            positionRectangle = new Rectangle(Xpos, Ypos, sourceRectangle.Width*3, sourceRectangle.Height*3);
            speed = Constants.mFireballSpeed;
            this.Xpos = Xpos;
            this.Ypos = Ypos;
            this.dir = dir;
            time = 0;
            effect = SpriteEffects.None;
        }


        public void Draw()
        {
            game.SpriteBatch.Draw(game.Textures.Items, positionRectangle, sourceRectangle, Color.White,0.0F,new Vector2(0,0),effect,0.0F);
        }

        public bool HitsProjectile(Rectangle hitbox, bool enemy)
        {
            bool result = (enemy != enemyProjectile && hitbox.Intersects(positionRectangle));
            if (result)
            {
                MainCharacterState.InventoryItems.Add(Constants.items.Candle, 1);
            }
            return result;
        }

        

        public void Update()
        {
            time++;
            if (time == 400||CollisionHandler.hitsWall(game, positionRectangle))
            {
                MainCharacterState.InventoryItems.Add(Constants.items.Candle, 1);
                GameProjectiles.Projectiles.Remove(this);
            }
            if (time / 5 % 2 == 0)
            {
                effect = SpriteEffects.None;
            }
            else
            {
                effect = SpriteEffects.FlipHorizontally;
            }
            Xpos += (int)dir.X * speed;
            Ypos += (int)dir.Y * speed;
            positionRectangle = new Rectangle(Xpos, Ypos, positionRectangle.Width, positionRectangle.Height);



        }
    }
}
