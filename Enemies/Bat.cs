using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml.Linq;
using Zelda.RoomRoomObjects;
namespace Zelda.Enemies;

public class Bat : ISprite
{
    private Rectangle positionRectangle;
    private Rectangle[] sourceRectangle;
    private Game1 game;

    private Vector2 direction;
    private int health;
    private double speed = Constants.batSpeed;
    private int frame = 0;
    private bool mainCharacterCollision = false;
    public Bat(Game1 game, int xPosition, int yPosition)
    {
        this.game = game;

        positionRectangle = new Rectangle(xPosition, yPosition, 50, 50);
        sourceRectangle = new Rectangle[2];
        sourceRectangle[0] = new Rectangle(235, 272, 16, 12);
        sourceRectangle[1] = new Rectangle(260, 272, 16, 12);

        health = Constants.batHealth;
    }


    public virtual void Update()
    {
        
        if (speed < 3 && Constants.random.NextDouble() < .05)
        {
            speed+=.25;
        }

        if (game.gameMode == Constants.GameMode.Gladiator)
        {
            game.DungeonRooms.RemoveEnemy(this);
        }
        positionRectangle.X += (int)(direction.X*speed);
        positionRectangle.Y += (int)(direction.Y*speed);
        if (game.DungeonRooms.HitsProjectile(positionRectangle, true))
        {
            health--;
            Console.WriteLine("bat took damage");
        }
        frame++;
        if (direction.X==0&&direction.Y==0)
        {
            frame--;
        }
        
        
        if (health == 0)
        {
            game.DungeonRooms.AddItem(new EnemyDeathExplosion(game, positionRectangle.X + 10, positionRectangle.Y + 10));
            game.DungeonRooms.RemoveEnemy(this);
        }
        mainCharacterCollision = CollisionHandler.mainCharacterEnemyColision(game, positionRectangle, mainCharacterCollision);
        if(Constants.random.NextDouble()<.03)ChangeDirection();
        CheckBounds();
    }

    private void CheckBounds()
    {
        if (CollisionHandler.hitsWall(game, positionRectangle))
        {
            direction = -direction;
        }
    }
    private void ChangeDirection()
    {

        direction = new Vector2(Constants.random.Next(-1, 2), Constants.random.Next(-1, 2));
    
    }

    public virtual void Draw()
    {
        game.SpriteBatch.Draw(game.Textures.DungeonEnemies, positionRectangle, sourceRectangle[frame/5%2], Color.White);


    }


}
