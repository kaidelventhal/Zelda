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

public class Wizzrobe : ISprite
{
    private Rectangle positionRectangle;
    private Rectangle sourceRectangle;
    private Game1 game;
    private Vector2 position;
    private Vector2 direction;
    private int xPosition;
    private int yPosition;
    private float speed;
    private double changeDirectionTime;
    private double shootTime;
    private double waitTime;
    private int currentFrame;
    private int health;
    private bool mainCharacterCollision = false;

    // Direction to animation and shooting direction mapping
    private Dictionary<Vector2, (int xPosition, int yFrameStart, int yFrameEnd, Vector2[] shootingDirections)> directionAnimationAndShootMap;

    public Wizzrobe(Game1 game, int xPosition, int yPosition)
    {    
        direction = new Vector2(0, -1);
        this.game = game;
        positionRectangle = new Rectangle(xPosition, yPosition, 50, 50);
        sourceRectangle = new Rectangle(0, 59, 15, 18);
        position.X = xPosition;
        position.Y = yPosition;
        currentFrame = 0;
        changeDirectionTime = Constants.wizzrobeChangeDirectionTime;
        shootTime = Constants.wizzrobeShootTime;
        health = Constants.wizzrobeHealth;
        speed = Constants.wizzrobeSpeed;
        waitTime = Constants.wizzrobeWaitTime;

        // Initialize direction animation and shooting direction mapping
        directionAnimationAndShootMap = new Dictionary<Vector2, (int xPosition, int yFrameStart, int yFrameEnd, Vector2[] shootingDirections)>
        {
            { new Vector2(-1, 0), (30, 119, 149, new Vector2[] {new Vector2(-1, -1), new Vector2(-1, 1)}) }, // Left
            { new Vector2(1, 0), (90, 119, 149, new Vector2[] {new Vector2(1, -1), new Vector2(1, 1)}) }, // Right
            { new Vector2(0, 1), (0, 119, 149, new Vector2[] {new Vector2(-1, 1), new Vector2(1, 1)}) }, // Down
            { new Vector2(0, -1), (60, 119, 149, new Vector2[] {new Vector2(-1, -1), new Vector2(1, -1)}) } // Up
        };
    }


    public virtual void Update()
    {
        GameTime gameTime = Game1.GlobalGameTime;
        changeDirectionTime -= gameTime.ElapsedGameTime.TotalSeconds;
        if (changeDirectionTime <= 0)
        {
            ChangeDirection();
            changeDirectionTime = Constants.wizzrobeChangeDirectionTime;
        }

        position += direction * speed * (float)gameTime.ElapsedGameTime.TotalSeconds; 
        positionRectangle.X += (int)direction.X;
        positionRectangle.Y += (int)direction.Y;
        CheckBounds();
        UpdateAnimation();
        shootTime -= gameTime.ElapsedGameTime.TotalSeconds;
        if (shootTime <= 0)
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
            game.DungeonRooms.AddProjectile(new MFireball(game, positionRectangle.X, positionRectangle.Y, shot1, true));
            game.DungeonRooms.AddProjectile(new MFireball(game, positionRectangle.X, positionRectangle.Y, direction, true));
            game.DungeonRooms.AddProjectile(new MFireball(game, positionRectangle.X, positionRectangle.Y, shot2, true));
            shootTime = Constants.wizzrobeShootTime;

            waitTime = Constants.wizzrobeWaitTime;

        }
        if (waitTime > 0)
        {
            speed = 0;
            waitTime -= gameTime.ElapsedGameTime.TotalSeconds;

        }
        else
        {
            speed = 100f;
        }
        if (game.DungeonRooms.HitsProjectile(positionRectangle, true))
        {
            health--;
            Console.WriteLine("Wizzrobe took damage");
        }
        if (health == 0)
        {
            game.DungeonRooms.AddItem(new EnemyDeathExplosion(game, positionRectangle.X + 10, positionRectangle.Y + 10));

            game.DungeonRooms.RemoveEnemy(this);
        }
        mainCharacterCollision = CollisionHandler.mainCharacterEnemyColision(game, positionRectangle, mainCharacterCollision);

    }

    private void UpdateAnimation()
    {
        // Normalize direction for mapping lookup
        Vector2 normalizedDirection = new Vector2(Math.Sign(direction.X), Math.Sign(direction.Y));
        if (directionAnimationAndShootMap.TryGetValue(normalizedDirection, out var mapping))
        {
            xPosition = mapping.xPosition;
            yPosition = currentFrame % 60 > 30 ? mapping.yFrameStart : mapping.yFrameEnd;
            sourceRectangle = new Rectangle(xPosition, yPosition, 15, 18);
        }
        currentFrame++;
    }
    private void CheckBounds()
    {
        if(CollisionHandler.hitsBoundry(game, positionRectangle))
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

