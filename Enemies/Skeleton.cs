


namespace Zelda.Enemies;

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Zelda.Projectiles;
using Zelda.RoomRoomObjects;

public class Skeleton : ISprite
{
    private Rectangle positionRectangle;
    private Rectangle[] sourceRectangle;
    private Rectangle currentSource;
    private Game1 game;
    private Vector2 position;
    private Vector2 direction;
    private bool hasKey;
    private int health;

    private float speed = Constants.skeletonSpeed;
    private double changeDirectionTime = Constants.skeletonChangeDirectionTime;
    private Dictionary<Vector2, (int x, int y, int yFrameStart)> directionToPositions;
    private int frame = 0;
    private bool mainCharacterCollision = false;
    

    public Skeleton(Game1 game, int xPosition, int yPosition,bool hasKey)
    {   
        direction=new Vector2(-1, 0);
        directionToPositions = new Dictionary<Vector2, (int x, int y, int yFrameStart)>
        {
            { new Vector2(-1, 0), (419, 120, 209) }, // Left
            { new Vector2(1, 0), (419, 150, 209) }, // Right
            { new Vector2(0, 1), (419, 120, 209) }, // Down
            { new Vector2(0, -1), (419, 150, 209) } // Up
        };
        this.game = game;
        
        sourceRectangle = new Rectangle[2];
        
        sourceRectangle[0] = new Rectangle(420, 120, 15, 18);
        sourceRectangle[1] = new Rectangle(420, 150, 15, 18);
        positionRectangle = new Rectangle(xPosition, yPosition, sourceRectangle[0].Width*4, sourceRectangle[0].Width*4);
        this.hasKey = hasKey;
        currentSource = sourceRectangle[0];
        position.X = positionRectangle.X;
        position.X = positionRectangle.Y;

        health = Constants.skeletonHealth;
       
        ChangeDirection();
    }


    public virtual void Update()
    {
        
        frame++;
        GameTime gameTime = Game1.GlobalGameTime;
        changeDirectionTime -= gameTime.ElapsedGameTime.TotalSeconds;
        if (changeDirectionTime <= 0)
        {
            ChangeDirection();
            changeDirectionTime = Constants.skeletonChangeDirectionTime;
        }
        position += direction * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        positionRectangle.X += (int)direction.X;
        positionRectangle.Y += (int)direction.Y;
        
        if (game.DungeonRooms.HitsProjectile(positionRectangle, true))
        {
            health--;
            Console.WriteLine("Skeleton took damage");
        }
        if (health == 0)
        {
            double ran = Constants.random.NextDouble();
            if (ran < .3)
            {
                game.DungeonRooms.AddItem(new RecoveryHeart(game, positionRectangle.X, positionRectangle.Y));
            }
            else if (ran < .32)
            {
                game.DungeonRooms.AddItem(new Clock(game, positionRectangle.X, positionRectangle.Y));
            }
            else if (ran < .44)
            {
                game.DungeonRooms.AddItem(new Rupee(game, positionRectangle.X, positionRectangle.Y));
            }
            else if (ran < .5)
            {
                game.DungeonRooms.AddItem(new Ring(game, positionRectangle.X, positionRectangle.Y));
            }
            else
            {
                game.DungeonRooms.AddItem(new BombItem(game, positionRectangle.X, positionRectangle.Y));

            }

            game.DungeonRooms.AddItem(new EnemyDeathExplosion(game, positionRectangle.X + 10, positionRectangle.Y + 10));
            if (hasKey) game.DungeonRooms.AddItem(new Key(game, positionRectangle.X, positionRectangle.Y, false));
            game.DungeonRooms.RemoveEnemy(this);
            SoundLoader.monsterDy1.Play();
        }
        CheckBounds();
        
        
        currentSource = sourceRectangle[(frame / 20 % 2)];
        
        mainCharacterCollision = CollisionHandler.mainCharacterEnemyColision(game ,positionRectangle, mainCharacterCollision);


    }
    
    private void CheckBounds()
    {
        if (CollisionHandler.hitsBoundry(game, positionRectangle))
        {
            Vector2 oldDirection = direction;
            direction.X = oldDirection.X * 0 + oldDirection.Y * 1;
            direction.Y = oldDirection.X*-1 + oldDirection.Y * 0;
;
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
        game.SpriteBatch.Draw(game.Textures.DungeonEnemies, positionRectangle, currentSource, Color.White);


    }


}
