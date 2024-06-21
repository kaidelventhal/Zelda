using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml.Linq;
using Zelda.Rooms;
using Zelda.RoomRoomObjects;
namespace Zelda.Enemies;


public class Trap : ISprite
{
    private Rectangle originalpositionRectangle;
    private Rectangle currentpositionRectangle;
    private Rectangle sourceRectangle;
    private Game1 game;
    private Vector2 position;
    private Vector2 orgin;

    Boolean leftX;
    Boolean leftY;
    private int health;
    int speedForawrd = Constants.trapSpeedForward;
    int speedRetreat = Constants.trapSpeedRetreat;
    private bool mainCharacterCollision = false;
    private SpriteEffects effect = SpriteEffects.None;

    public Trap(Game1 game, int xPosition, int yPosition)
    {
       
        this.game = game;
        originalpositionRectangle = new Rectangle(xPosition, yPosition, 55, 55);
        currentpositionRectangle = originalpositionRectangle;
        sourceRectangle = new Rectangle(269, 329, 17, 17);
        position.X = xPosition; 
        position.Y = yPosition; 
        health = Constants.trapHealth;
        orgin = new Vector2(0,0);
        leftX = false;
        leftY = false;
      
    }


    public virtual void Update()
    {
        
        if (Math.Abs(MainCharacterState.InboundsRectangle.X - originalpositionRectangle.X) < 40&&!leftX)
        {
            if (MainCharacterState.InboundsRectangle.Y < currentpositionRectangle.Y)
            {
                currentpositionRectangle.Y-= speedForawrd;
            }
            else
            {
                currentpositionRectangle.Y += speedForawrd;
            }
            leftY = true;
        }
        else if (Math.Abs(MainCharacterState.InboundsRectangle.Y - originalpositionRectangle.Y) < 40&&!leftY)
        {
            if (MainCharacterState.InboundsRectangle.X < currentpositionRectangle.X)
            {
                currentpositionRectangle.X -= speedForawrd;
            }
            else
            {
                currentpositionRectangle.X += speedForawrd;
            }
            leftX = true;
        }
        if (originalpositionRectangle.X < currentpositionRectangle.X)
        {
            currentpositionRectangle.X -= speedRetreat;
        }
        if (originalpositionRectangle.X > currentpositionRectangle.X)
        {
            currentpositionRectangle.X += speedRetreat;
        }
        if (originalpositionRectangle.Y < currentpositionRectangle.Y)
        {
            currentpositionRectangle.Y -= speedRetreat;
        }
        if (originalpositionRectangle.Y > currentpositionRectangle.Y)
        {
            currentpositionRectangle.Y += speedRetreat;
        }
        if (currentpositionRectangle.Equals(originalpositionRectangle))
        {
            leftX = false;
            leftY = false;
        }

        if (game.DungeonRooms.HitsProjectile(currentpositionRectangle, true))
        {
            health--;
            Console.WriteLine("Wallmaster took damage");
        }
        if (health == 0)
        {
            game.DungeonRooms.AddItem(new EnemyDeathExplosion(game, currentpositionRectangle.X, currentpositionRectangle.Y));

            game.DungeonRooms.RemoveEnemy(this);
        }
        mainCharacterCollision = CollisionHandler.mainCharacterEnemyColision(game, currentpositionRectangle, mainCharacterCollision);


    }

    
    
    

    public virtual void Draw()
    {
        game.SpriteBatch.Draw(game.Textures.DungeonEnemies, currentpositionRectangle, sourceRectangle, Color.White,0.0F,orgin,effect,0.0F);


    }


}
