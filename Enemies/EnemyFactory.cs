using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Reflection;
using Zelda.Projectiles;
using Zelda.RoomRoomObjects;
namespace Zelda.Enemies;
// have these enemies Stalfos gibdo keese wizzrobe darknut goriya aquamentus. 
public class EnemyFactory : ISprite
{
    private List<ISprite> enemies;
    private Game1 game;
    
    

    public EnemyFactory(Game1 game, List<ISprite> enemies)
    {
        this.game = game;
        this.enemies = enemies;
        
        
        
    }

    public void Update()
    {
        for (int i =0;i<enemies.Count;i++)
        {
            enemies[i].Update();
        }
        
    }

    public void Draw()
    {
        foreach(var enemy in enemies)
        {
            enemy.Draw();
        }

    }
    public void RemoveEnemy(ISprite Enemy)
    {
        enemies.Remove(Enemy);
    }
     public void AddEnemy(ISprite Enemy)
    {
        enemies.Add(Enemy);
    }
    public int EnemiesLeft()
    {
        return enemies.Count;
    }

}
