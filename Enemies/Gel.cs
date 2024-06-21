using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml.Linq;
using Zelda.RoomRoomObjects;
namespace Zelda.Enemies;


public class Gel : ISprite
{
    private Rectangle positionRectangle;
    private Rectangle[] sourceRectangle;
    private Game1 game;
    private Vector2 position;
    private Vector2 direction;
    
    
    private float speed = Constants.gelSpeed;
    private int health = Constants.gelHealth;
    private int currentFrame = 0;
    private bool mainCharacterCollision = false;

    public Gel(Game1 game, int xPosition, int yPosition)
    {
        ChangeDirection();
        this.game = game;

        positionRectangle = new Rectangle(xPosition, yPosition, 50, 50);
        sourceRectangle = new Rectangle[2];
        sourceRectangle[0] = new Rectangle(403, 183, 10, 10);
        sourceRectangle[1] = new Rectangle(404, 212, 8, 9);
        
        position.X = xPosition; 
        position.Y = yPosition; 
        

        
        
       
    }


    public virtual void Update()
    {

        currentFrame++;
        if (currentFrame%Constants.gelChangeDirectionTime == 0)
        {
            ChangeDirection();
            
        }

        position += direction * speed;
        positionRectangle.X += (int)direction.X;
        positionRectangle.Y += (int)direction.Y;
        positionRectangle.Width = sourceRectangle[currentFrame / 4 % 2].Width * 4;
        positionRectangle.Height = sourceRectangle[currentFrame / 4 % 2].Height * 4;
        CheckBounds();
        
        if (game.DungeonRooms.HitsProjectile(positionRectangle, true))
        {
            health--;
            Console.WriteLine("Gel took damage");
        }
        if (health == 0)
        {
            game.DungeonRooms.AddItem(new EnemyDeathExplosion(game, positionRectangle.X, positionRectangle.Y));

            game.DungeonRooms.RemoveEnemy(this);
        }
        mainCharacterCollision = CollisionHandler.mainCharacterEnemyColision(game,positionRectangle, mainCharacterCollision);


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


        int directionChoice = Constants.random.Next(6);  // Randomly choose between 0 and 4
        Vector2 stationary = new Vector2(0, 0);
        if (direction.Equals(stationary)){
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
                case 4:
                    direction = stationary;
                    break;
                case 5:
                    direction = stationary;
                    break;

            }
        }
        else
        {
            direction = stationary;
        }
        
    }

    public virtual void Draw()
    {
        game.SpriteBatch.Draw(game.Textures.DungeonEnemies, positionRectangle, sourceRectangle[currentFrame/4%2], Color.White);


    }


}
