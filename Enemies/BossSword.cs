using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml.Linq;
using Zelda.ZeldaItems;
using Zelda;
using Zelda.Projectiles;
namespace Zelda.Enemies;

public class BossSword : ISprite
{
    private Rectangle positionRectangle;
    private Rectangle sourceRectangle;
    private Game1 game;
    private Vector2 position;
    private Vector2 direction;
    private Vector2 directionS;
    private float speed=100f;
    private double timer;
    private double changeDirectionTime = 2;
    private static Random random = new Random();
    private int currentFrame = 0;
    private int xPosition;
    private int yPosition;
    private int room;
    private int health;
    public static float rotation;
    private Boss boss;
    private bool mainCharacterCollision = false;
    public BossSword(Game1 game, int xPosition, int yPosition, int room )
    {
        this.game = game;
        this.room = room;

        positionRectangle = new Rectangle(xPosition, yPosition, 40, 80);
        sourceRectangle = new Rectangle(0, 0, 48, 139);
        timer = changeDirectionTime;
        position.X = positionRectangle.X;
        position.Y = positionRectangle.Y;
        health = 999;
        
    }


    public virtual void Update()
    {
        GameTime gameTime = Game1.GlobalGameTime;
        timer -= gameTime.ElapsedGameTime.TotalSeconds;
        if (timer <= 0)
        {

            timer = changeDirectionTime;
            //direction.Normalize();
            Console.WriteLine(direction+"1");
            game.DungeonRooms.AddProjectile(new SwordLight(game, positionRectangle.X , positionRectangle.Y, direction, true));
            SoundLoader.bossAttack.Play();
            game.DungeonRooms.RemoveEnemy(this);
        }
        positionRectangle.X += (int)Boss.directionM.X;
        positionRectangle.Y += (int)Boss.directionM.Y;
        position.X = positionRectangle.X;
        position.Y = positionRectangle.Y;
        Vector2 playerPosition = new Vector2(MainCharacterState.XPos, MainCharacterState.YPos);
        Vector2 directionS = playerPosition - position;
        rotation = (float)Math.Atan2(directionS.Y, directionS.X)+5;
                direction = directionS;

        if (Boss.BossD)
        {
            game.DungeonRooms.RemoveEnemy(this);
        }
        if (game.DungeonRooms.HitsProjectile(positionRectangle, true))
        {
            health--;
            Console.WriteLine("bat took damage");
        }
        if (health == 0)
        {
            game.DungeonRooms.AddItem(new BossDeathExplosion(game, positionRectangle.X + 10, positionRectangle.Y + 10, room));

            game.DungeonRooms.RemoveEnemy(this);
        }
        mainCharacterCollision = CollisionHandler.mainCharacterEnemyColision(game, positionRectangle, mainCharacterCollision);



        CheckBounds();
        UpdateAnimation();


    }

    private void UpdateAnimation()
    {

        sourceRectangle = new Rectangle(0, 0, 48, 139);
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

        //direction = new Vector2(random.Next(-1, 2), random.Next(-1, 2));
        direction = directionS;
        Console.WriteLine(direction);

        Console.WriteLine(direction);
    }

    public virtual void Draw()
    {
        game.SpriteBatch.Draw(game.Textures.BOSSSword1, position, sourceRectangle, Color.White, rotation, new Vector2(50/ 2, 100 / 2), 1.0f, SpriteEffects.None, 0f);


    }


}
