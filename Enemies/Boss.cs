using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml.Linq;
using Zelda.ZeldaItems;
using Microsoft.Xna.Framework.Media;


namespace Zelda.Enemies;

public class Boss : ISprite
{
    private Rectangle positionRectangle;
    private Rectangle sourceRectangle;
    private Game1 game;
    private Vector2 position;
    private Vector2 direction;
    public static Vector2 directionM;
    public static bool BossD;
    private float speed=2;
    private double timer;
    private double changeDirectionTime = 2;
    private static Random random = new Random();
    public static int xPosition;
    public static int yPosition;
    private int room;
    private int health;
    private bool mainCharacterCollision = false;
    private int currentFrame;
    private double timeSinceLastFrame;
    private double directionChangeCooldown = 1; 
    private double timeSinceLastDirectionChange = 0;
    private double callSwordCooldown = 1;
    private double timeSinceLastcallSword = 0;
    public Boss(Game1 game, int xPosition, int yPosition, int room)
    {
        this.game = game;
        this.room = room;
        positionRectangle = new Rectangle(xPosition, yPosition, 100, 170);
        sourceRectangle = new Rectangle(10,40, 100, 170);



        timer = changeDirectionTime;
        position.X = positionRectangle.X;
        position.Y = positionRectangle.Y;
        health = 10;
    }


    public virtual void Update()
    {
        GameTime gameTime = Game1.GlobalGameTime;
        timer -= gameTime.ElapsedGameTime.TotalSeconds;
        timeSinceLastDirectionChange += gameTime.ElapsedGameTime.TotalSeconds;
        timeSinceLastcallSword += gameTime.ElapsedGameTime.TotalSeconds;
        if (timer <= 0)
        {
            ChangeDirection();
            timer = changeDirectionTime;
        }
        Vector2 playerPosition = new Vector2(MainCharacterState.XPos, MainCharacterState.YPos);

        float distance = Vector2.Distance(playerPosition, position);
        if (distance < 150 && timeSinceLastDirectionChange >= directionChangeCooldown)
        {

            float xDifference = position.X - playerPosition.X;
            float yDifference = position.Y - playerPosition.Y;


            if (Math.Abs(xDifference) > Math.Abs(yDifference))
            {
                direction = xDifference > 0 ? new Vector2(-1, 0) : new Vector2(1, 0);
            }
            else
            {
                direction = yDifference > 0 ? new Vector2(0, -1) : new Vector2(0, 1);
            }
            Console.WriteLine("direction: X = " + direction.X + ", Y = " + direction.Y);
            Console.WriteLine(distance);
            timeSinceLastDirectionChange = 0;
        }
        
        directionM = direction * speed;
        positionRectangle.X += (int)directionM.X;
        positionRectangle.Y += (int)directionM.Y;
        position.X = positionRectangle.X;
        position.Y = positionRectangle.Y;
        if (game.DungeonRooms.HitsProjectile(positionRectangle, true))
        {
            health--;
            Console.WriteLine("Boss took damage");
            Console.WriteLine(direction);
        }

        if (health == 0)
        {


            game.DungeonRooms.RemoveEnemy(this);
            BossD = true;
            game.DungeonRooms.AddEnemy(new Boss2(game, positionRectangle.X, positionRectangle.Y, room));

        }
        mainCharacterCollision = CollisionHandler.mainCharacterEnemyColision(game, positionRectangle, mainCharacterCollision);
        timeSinceLastFrame += gameTime.ElapsedGameTime.TotalMilliseconds;

        if (timeSinceLastFrame >= 200)
        {
            currentFrame++;
            timeSinceLastFrame = 0;
        }

        if (currentFrame > 7) 
        {
            currentFrame = 0;

        }
        CheckBounds();
        UpdateAnimation();
        CallSword();

    }
    private void CallSword()
    {
        if (callSwordCooldown <= timeSinceLastcallSword)
        { 

            game.DungeonRooms.AddEnemy(new BossSword(game, positionRectangle.X + 75, positionRectangle.Y+80, room));
            callSwordCooldown = 3;
            timeSinceLastcallSword = 0;
        }



    }
    private void UpdateAnimation()
    {

        if (direction.X < 0)
        {
            xPosition = 200;
        }
        else if (direction.X > 0)
        {
            xPosition = 0;
        }
        else if (direction.Y > 0)
        {
            xPosition = 300;
        }
        else if (direction.Y < 0)
            xPosition = 100;
        sourceRectangle = new Rectangle(xPosition, currentFrame * 170, 100, 170);

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

        Random random = new Random();
        int directionChoice = random.Next(4);  // Randomly choose between 0 and 1

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
        game.SpriteBatch.Draw(game.Textures.BOSS1, positionRectangle, sourceRectangle, Color.White);


    }


}
