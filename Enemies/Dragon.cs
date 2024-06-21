using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml.Linq;
using Zelda.Enemies;
using Zelda.Projectiles;
using Zelda.RoomRoomObjects;
namespace Zelda.Enemies;

public class Dragon : ISprite
{
    private Rectangle positionRectangle;
    private Rectangle initialposition;
    private Rectangle[] sourceRectangle;
    private Rectangle sourceRect;
    
    private Game1 game;
    private SpriteEffects spriteEffects;
    private Vector2 direction;
    
    private int frame;
    private int xPosition;
    private int yPosition;

    private int health;
    private bool mainCharacterCollision = false;

    public Dragon(Game1 game, int xPosition, int yPosition)
    {
        this.game = game;
        this.xPosition = xPosition;
        this.yPosition = yPosition;
        health = Constants.dragonHealth;
        frame = 0;
        direction = new Vector2(-1, 0);
        positionRectangle = new Rectangle(xPosition, yPosition, 50, 50);
        sourceRectangle = new Rectangle[4];
        sourceRectangle[0] = new Rectangle(1, 11, 24, 32);
        sourceRectangle[1] = new Rectangle(26, 11, 24, 32);
        sourceRectangle[2] = new Rectangle(51, 11, 24, 32);
        sourceRectangle[3] = new Rectangle(76, 11, 24, 32);
        sourceRect = sourceRectangle[0];
        spriteEffects = SpriteEffects.None;
        initialposition = positionRectangle;

    }
    public virtual void Update()
    {
        if (CollisionHandler.hitsBoundry(game, positionRectangle)||Constants.random.NextDouble()<0.0025)
        {
            if(spriteEffects== SpriteEffects.None)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }
            else
            {
                spriteEffects = SpriteEffects.None;
            }
            direction = -direction;
        }
        if (Constants.random.NextDouble() < .0050)
        {
            Vector2 shot1;
            Vector2 shot2;
            if (direction.X != 0)
            {
                shot1 = new Vector2(direction.X, -1);
                shot2 = new Vector2(direction.X, 1);
            }
            else
            {
                shot1 = new Vector2(-1, direction.Y);
                shot2 = new Vector2(1, direction.Y);
            }
            game.DungeonRooms.AddProjectile(new MFireball(game, positionRectangle.X+12, positionRectangle.Y, shot1, true));
            game.DungeonRooms.AddProjectile(new MFireball(game, positionRectangle.X+12, positionRectangle.Y, direction,true));
            game.DungeonRooms.AddProjectile(new MFireball(game, positionRectangle.X+12, positionRectangle.Y, shot2, true));
        }
        if (game.DungeonRooms.HitsProjectile(positionRectangle, true))
        {
            health--;
            Console.WriteLine("Dragon took damage");
        }
        if (health == 0)
        {
            game.DungeonRooms.AddItem(new EnemyDeathExplosion(game, xPosition+20, yPosition+20));
            game.DungeonRooms.AddItem(new HeartContainer(game, initialposition.X + 130, initialposition.Y+25));
            game.DungeonRooms.RemoveEnemy(this);    
        }
        mainCharacterCollision = CollisionHandler.mainCharacterEnemyColision(game,positionRectangle, mainCharacterCollision);
        sourceRect = sourceRectangle[frame++ / 12 % 4];
        xPosition += (int)direction.X;
        yPosition += (int)direction.Y;
        positionRectangle = new Rectangle(xPosition, yPosition, sourceRect.Width*4, sourceRect.Height*4);
        
    }
    public virtual void Draw()
    {
        game.SpriteBatch.Draw(game.Textures.ZeldaBoses, positionRectangle, sourceRect, Color.White,0.0F,new Vector2(0,0), spriteEffects, 0.0F);
    }
}
