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

public class Goriya : ISprite
{
    private Rectangle positionRectangle;
    private Rectangle sourceRectangle;
    private Game1 game;
    private Vector2 position;
    private Vector2 direction;
    private int xPosition;
    private int yPosition;
    private int health;

    private float speed = Constants.goriyaSpeed;
    private double changeDirectionTime = Constants.goriyaChangeDirectionTime;
    private double shootTime = Constants.goriyaShootTime;
    private double waitTime = Constants.goriyaWaitTime;
    private int currentFrame = 0;
    private Dictionary<Vector2, (int xPosition, int yFrameStart, int yFrameEnd)> directionAnimationMap;
    private bool mainCharacterCollision = false;

    public Goriya(Game1 game, int xPosition, int yPosition)
    {   
        direction = new Vector2(0, -1);
        this.game = game;
        positionRectangle = new Rectangle(xPosition, yPosition, 50, 50);
        sourceRectangle = new Rectangle(0, 59, 15, 18);
        
        position.X = positionRectangle.X;
        position.Y = positionRectangle.Y; 
        health = Constants.goriyaHealth;

        
        directionAnimationMap = new Dictionary<Vector2, (int xPosition, int yFrameStart, int yFrameEnd)>
        {
            { new Vector2(-1, 0), (30, 59, 89) }, // Left
            { new Vector2(1, 0), (90, 59, 89) }, // Right
            { new Vector2(0, 1), (0, 59, 89) }, // Down
            { new Vector2(0, -1), (60, 59, 89) } // Up
        };
    }


    public virtual void Update()
    {
        GameTime gameTime = Game1.GlobalGameTime;
        changeDirectionTime -= gameTime.ElapsedGameTime.TotalSeconds;
        if (changeDirectionTime <= 0)
        {
            ChangeDirection();
            changeDirectionTime = Constants.goriyaChangeDirectionTime;
        }

        position += direction * speed * (float)gameTime.ElapsedGameTime.TotalSeconds; // 更新位置
        positionRectangle.X += (int)direction.X;
        positionRectangle.Y += (int)direction.Y;
        CheckBounds();
        UpdateAnimation();
        shootTime -= gameTime.ElapsedGameTime.TotalSeconds;
        if (shootTime <= 0)
        {

            game.DungeonRooms.AddProjectile(new Boomerang(game, positionRectangle.X, positionRectangle.Y, direction,true));
            shootTime = Constants.goriyaShootTime;

            waitTime = Constants.goriyaWaitTime;
            
        }
        if (waitTime > 0)
        {
            speed = 0;
            waitTime -= gameTime.ElapsedGameTime.TotalSeconds;

        }
        else
        {
            speed = Constants.goriyaSpeed;
        }
        if (game.DungeonRooms.HitsProjectile(positionRectangle, true))
        {
            health--;
            Console.WriteLine("Goriya took damage");
        }
        if (health == 0)
        {
            double r = Constants.random.NextDouble();
            if (r< .75)
            {
                game.DungeonRooms.AddItem(new Rupee(game, positionRectangle.X + 10, positionRectangle.Y + 10));
            }
            else if (r < 1)
            {
                game.DungeonRooms.AddItem(new BombItem(game, positionRectangle.X + 10, positionRectangle.Y + 10));
            }
            game.DungeonRooms.AddItem(new EnemyDeathExplosion(game, positionRectangle.X + 10, positionRectangle.Y + 10));

            game.DungeonRooms.RemoveEnemy(this);
        }
        mainCharacterCollision = CollisionHandler.mainCharacterEnemyColision(game,positionRectangle, mainCharacterCollision);

    }

    private void UpdateAnimation()
    {
        Vector2 normalizedDirection = new Vector2(Math.Sign(direction.X), Math.Sign(direction.Y));
        if (directionAnimationMap.TryGetValue(normalizedDirection, out var animationMapping))
        {
            xPosition = animationMapping.xPosition;
            yPosition = currentFrame % 60 > 30 ? animationMapping.yFrameStart : animationMapping.yFrameEnd;
        }
        currentFrame++;
        sourceRectangle = new Rectangle(xPosition, yPosition, 15, 18);
    }
    private void CheckBounds()
    {
        if (CollisionHandler.hitsBoundry(game, positionRectangle))
        {
            direction = -direction;
        }
    }
    private void ChangeDirection()
    {

        
        int directionChoice = Constants.random.Next(4);  // Randomly choose between 0 and 1

        switch (directionChoice)
        {
            case 0:
                direction = new Vector2(-1, 0); // Move left
                break;
            case 1:
                direction = new Vector2(1, 0); // Move right
                break;
            case 2:
                direction = new Vector2(0, -1); // Move up
                break;
            case 3:
                direction = new Vector2(0, 1); // Move down
                break;
        }
    }

    public virtual void Draw()
    {
        game.SpriteBatch.Draw(game.Textures.DungeonEnemies, positionRectangle, sourceRectangle, Color.White);


    }


}
