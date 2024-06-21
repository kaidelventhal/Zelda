using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml.Linq;
using Zelda.ZeldaItems;

namespace Zelda.Enemies;

public class Boss2 : ISprite
{
    private Rectangle positionRectangle;
    private Rectangle sourceRectangle;
    private Rectangle sowrdRectangle;
    private Rectangle sowrdresoureceRectangle;
    private Game1 game;
    private Vector2 position;
    private Vector2 direction;
    private Vector2 directionM;
    private float speed=4;
    private double timer;
    private double changeDirectionTime = 4;
    private static Random random = new Random();
    public int xPosition;
    public int yPosition;
    private int room;
    private int health;
    private bool mainCharacterCollision = false;
    private int currentFrame = 0;
    private double timeSinceLastFrame;
    private double directionChangeCooldown = 1; 
    private double timeSinceLastDirectionChange = 0;
    public Boss2(Game1 game, int xPosition, int yPosition, int room)
    {
        this.game = game;
        this.room = room;
        positionRectangle = new Rectangle(xPosition, yPosition, 100, 170);
        sourceRectangle = new Rectangle(10, 40, 100, 170);
        //sowrdRectangle = new Rectangle(10, 40, 100, 114);
        sowrdresoureceRectangle = new Rectangle(0, 0, 100, 114);

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
        if (timer <= 0)
        {
            ChangeDirection();
            timer = changeDirectionTime;
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
            game.DungeonRooms.AddItem(new BossDeathExplosion(game, positionRectangle.X + 10, positionRectangle.Y + 10, room));
            SoundLoader.bossDeath.Play();
            game.DungeonRooms.RemoveEnemy(this);
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
        SoundLoader.bossAttack.Play();
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
        game.SpriteBatch.Draw(game.Textures.BOSS1, positionRectangle, sourceRectangle, Color.Red);
        game.SpriteBatch.Draw(game.Textures.BOSSSword2, new(position.X+80, position.Y + 60), sowrdresoureceRectangle, Color.White, 0f, new Vector2(100 / 2, 114 / 2), 1.0f, SpriteEffects.None, 0f);
        game.SpriteBatch.Draw(game.Textures.BOSSSword2, new(position.X+30,position.Y+60), sowrdresoureceRectangle, Color.White, 3.14f, new Vector2(100 / 2, 114 / 2), 1.0f, SpriteEffects.None, 0f);
    }


}
