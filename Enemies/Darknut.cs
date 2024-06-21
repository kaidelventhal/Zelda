using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml.Linq;
namespace Zelda.Enemies;
using System.Collections.Generic;
using Zelda.RoomRoomObjects;

public class Darknut : ISprite
{
    private Rectangle positionRectangle;
    private Rectangle sourceRectangle;
    private Game1 game;
    private Vector2 position;
    private Vector2 direction;
    private int xPosition;
    private int yPosition;
    private int health;

    private float speed=Constants.darknutSpeed;
    private double changeDirectionTime = Constants.darknutChangeDirectionTime;
    private int currentFrame = 0;
    private Dictionary<Vector2, (int x, int y, int yFrameStart)> directionToPositions;
    private bool mainCharacterCollision = false;

    public Darknut(Game1 game, int xPosition, int yPosition) 
    {
        direction=new Vector2(0, -1);
        directionToPositions = new Dictionary<Vector2, (int x, int y, int yFrameStart)>
        {
            { new Vector2(-1, 0), (30, 179, 209) }, // Left
            { new Vector2(1, 0), (90, 179, 209) }, // Right
            { new Vector2(0, 1), (0, 179, 209) }, // Down
            { new Vector2(0, -1), (60, 179, 209) } // Up
        };
        this.game = game;

        positionRectangle = new Rectangle(xPosition, yPosition, 50, 50);
        sourceRectangle = new Rectangle(0, 179, 15, 17);
        changeDirectionTime = Constants.darknutChangeDirectionTime;
        position.X = positionRectangle.X;
        position.X = positionRectangle.Y;
        health = Constants.darknutHealth;
    }


    public virtual void Update()
    {
        if (Constants.random.NextDouble() < 0.0050)
        {
            game.DungeonRooms.AddEnemy(new Skeleton(game, positionRectangle.X, positionRectangle.Y, false));
        }
            GameTime gameTime = Game1.GlobalGameTime;
        changeDirectionTime -= gameTime.ElapsedGameTime.TotalSeconds;
        if (changeDirectionTime <= 0)
        {
            ChangeDirection();
            changeDirectionTime = Constants.darknutChangeDirectionTime;
        }

        position += direction * speed * (float)gameTime.ElapsedGameTime.TotalSeconds; 
        positionRectangle.X += (int)direction.X;
        positionRectangle.Y += (int)direction.Y;
        if (game.DungeonRooms.HitsProjectile(positionRectangle, true))
        {
            health--;
            Console.WriteLine("Darknut took damage");
        }
        if (health == 0)
        {
            game.DungeonRooms.AddItem(new EnemyDeathExplosion(game, positionRectangle.X + 10, positionRectangle.Y + 10));

            game.DungeonRooms.RemoveEnemy(this);
        }
        mainCharacterCollision = CollisionHandler.mainCharacterEnemyColision(game,positionRectangle, mainCharacterCollision);
        CheckBounds();
        UpdateAnimation();


    }
    private void UpdateAnimation()
    {
        if (directionToPositions.TryGetValue(direction, out var positions))
        {
            xPosition = positions.x;
            yPosition = currentFrame % 60 > 30 ? positions.yFrameStart : positions.y;
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

        
        int directionChoice = Constants.random.Next(4);  // Randomly choose between 0 and 3

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



