
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Zelda;

namespace Zelda.Projectiles
{
    public class GameProjectiles : IProjectile
    {
        private Game1 game;
        private static List<IProjectile> projectiles;
        public static List<IProjectile> Projectiles
        {
            get
            {
                return projectiles;
            }
            set
            {
                projectiles = value;
            }
        }
        public GameProjectiles(Game1 game) {
            this.game = game;
            projectiles = new List<IProjectile>();
        }
        public void Draw()
        {
            for (int i = 0; i < Projectiles.Count; i++)
            {
                Projectiles[i].Draw();
            }
        }

        public void Update()
        {
            for (int i = 0; i < Projectiles.Count; i++)
            {
                Projectiles[i].Update();

            }
        }
        public void addProjectile(IProjectile projectile)
        {
            projectiles.Add(projectile);


        }
        public void removeProjectile(IProjectile projectile)
        {
            projectiles.Remove(projectile);

        }
        public void clearProjectiles()
        {
            projectiles = new List<IProjectile>();
        }
        public bool HitsProjectile(Rectangle hitbox,bool enemy)
        {
            for(int i =0;i<projectiles.Count;i++)
            {
                if (projectiles[i].HitsProjectile(hitbox, enemy))
                {
                    removeProjectile(projectiles[i]);
                    i--;
                    return true;
                }
            }
            return false;
        }
        public bool HitsProjectile(Rectangle hitbox, bool enemy, string type)
        {
            
            
            for (int i = 0; i < projectiles.Count; i++)
            {
                if (projectiles[i].HitsProjectile(hitbox, enemy) && projectiles[i].GetType().ToString().Equals(type))
                {
                    Console.WriteLine("type = " + projectiles[i].GetType().ToString());
                    removeProjectile(projectiles[i]);
                    i--;
                    return true;
                }
            }
            return false;
        }

    }
}
