using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml.Linq;
using Zelda.Rooms;
using Zelda.RoomRoomObjects;
using System.Transactions;
namespace Zelda.Enemies;


public class Wallmaster : ISprite
{
    private Rectangle positionRectangle;
    private Rectangle[] sourceRectangle;
    private Game1 game;
    private Vector2 position;
    private Vector2 direction;

    Boolean returnLinkToStart;
    double positionX;
    double positionY;

    int startX;
    int startY;
    Vector2 returndir;
    private int currentFrame = 0;
    private float speed = Constants.wallmasterSpeed;
    private int health = Constants.wallmasterHealth;
    private bool mainCharacterCollision = false;
    private bool initialInvisible = MainCharacterState.Invincible;
    private SpriteEffects effect = SpriteEffects.None;
    private Vector2 orgin;
    

    public Wallmaster(Game1 game, int xPosition, int yPosition, int delay)
    {
        ChangeDirection();
        this.game = game;
        positionRectangle = new Rectangle(xPosition, yPosition, 50, 50);
        sourceRectangle = new Rectangle[2];
        sourceRectangle[0] = new Rectangle(270, 30, 17, 17);
        sourceRectangle[1] = new Rectangle(271, 0, 17, 17);
        startX = 128+Constants.dungeonLoaderOffsetX;
        startY = 320+Constants.dungeonLoaderOffsetY;
        returnLinkToStart = false;
        position.X = xPosition; 
        position.Y = yPosition;
        currentFrame = 200;
        orgin = new Vector2(0,0);

        
        
    }


    public virtual void Update()
    {
        currentFrame++;
        if (returnLinkToStart)
        {
            positionX += returndir.X / 200;
            positionY += returndir.Y / 200;
            positionRectangle.X = (int)positionX;
            positionRectangle.Y = (int)positionY;
            MainCharacterState.XPos =(int)positionX;
            MainCharacterState.YPos = (int)positionY;
            if(currentFrame == 200)
            {
                Console.WriteLine(currentFrame);
                returnLinkToStart = false;
                MainCharacterState.Invincible = initialInvisible;
                currentFrame = 0;
            }
        }
        else
        {
            if (currentFrame % Constants.wallmasterChangeDirectionTime == 0)
            {
                ChangeDirection();
            }

            positionRectangle.X += (int)(direction.X * speed);
            positionRectangle.Y += (int)(direction.Y * speed);
            positionRectangle.Width = sourceRectangle[currentFrame / 4 % 2].Width * 4;
            positionRectangle.Height = sourceRectangle[currentFrame / 4 % 2].Height * 4;
            CheckBounds();

            if (game.DungeonRooms.HitsProjectile(positionRectangle, true))
            {
                health--;
                Console.WriteLine("Wallmaster took damage");
            }
            if (health == 0)
            {
                game.DungeonRooms.AddItem(new EnemyDeathExplosion(game, positionRectangle.X, positionRectangle.Y));

                game.DungeonRooms.RemoveEnemy(this);
            }
            mainCharacterCollision = CollisionHandler.mainCharacterEnemyColision(game, positionRectangle, mainCharacterCollision);
            if (mainCharacterCollision&&currentFrame>200)
            {
                returnLinkToStart = true;
                returndir = new Vector2(startX - positionRectangle.X, startY - positionRectangle.Y);
                currentFrame = 0; ;
                MainCharacterState.invincible = true;
                positionX = positionRectangle.X;
                positionY = positionRectangle.Y;
            }
        }
        
        
        


    }

    
    private void CheckBounds()
    {
        //if the Wallmaster reaches edge it goes to the other side.
        
        if (positionRectangle.X<Constants.dungeonLoaderOffsetX+Constants.edgewidth)
        {
            positionRectangle.X += Constants.gameWindowWidth - (2 * Constants.edgewidth);
        }
        if (positionRectangle.X > Constants.dungeonLoaderOffsetX - Constants.edgewidth+Constants.gameWindowWidth)
        {
            positionRectangle.X -= Constants.gameWindowWidth + (2 * Constants.edgewidth);
        }
        if (positionRectangle.Y < Constants.dungeonLoaderOffsetY + Constants.edgewidth)
        {
            positionRectangle.Y += Constants.gameWindowHeight - (2 * Constants.edgewidth);
        }
        if (positionRectangle.Y > Constants.dungeonLoaderOffsetY - Constants.edgewidth+Constants.gameWindowHeight)
        {
            positionRectangle.Y -= Constants.gameWindowWidth + (2 * Constants.edgewidth);
        }
        
    }
    private void ChangeDirection()
    {


        int directionChoice = Constants.random.Next(6);  // Randomly choose between 0 and 4
        switch (directionChoice)
        {
            case 0:
                direction = new Vector2(-1, 0); // Move left
                effect = SpriteEffects.FlipHorizontally;
                break;
            case 1:
                direction = new Vector2(1, 0); // Move right
                effect = SpriteEffects.None;
                break;
            case 2:
                direction = new Vector2(0, -1); // Move up
                effect = SpriteEffects.None;
                break;
            case 3:
                direction = new Vector2(0, 1); // Move down
                effect = SpriteEffects.FlipVertically;
                break;
 
        }
        
    }

    public virtual void Draw()
    {
        game.SpriteBatch.Draw(game.Textures.DungeonEnemies, positionRectangle, sourceRectangle[currentFrame/4%2], Color.White,0.0F,orgin,effect,0.0F);


    }


}
