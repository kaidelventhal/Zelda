using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Zelda.Projectiles;
using Zelda.Rooms;
namespace Zelda
{
    public abstract class MainCharacterSprite : ISprite
    {
        
        protected Game1 game;
        
        
        public MainCharacterSprite(Game1 game)
        {
            this.game = game;
            
        }
        public void nextItem()
        {
            Constants.items item = MainCharacterState.CurrentItem;
            Constants.items nextItem = item;
            
            List<Constants.items> list = new List<Constants.items> {Constants.items.Bow, Constants.items.Bomb, Constants.items.Boomerang, Constants.items.Candle, Constants.items.Ring};
            int count = list.IndexOf(item)+1;
            while (true)
            {
                if (MainCharacterState.InventoryItems.ContainsKey(list[count%list.Count]))
                {
                    break;
                }
                count++;
            }
            MainCharacterState.CurrentItem = list[count % list.Count];


        }



        public virtual void Update()
        {
            if (MainCharacterState.Health <= 0)
            {
                new CommandEndGame(game).Execute();
            }

            if (game.DungeonRooms.TransitionTime == Constants.roomTransitionTime)
            {
                if (MainCharacterState.LDir.X == -1)
                {
                    game.mainCharacter = new SpriteMoveLeft(game);
                   
                }
                else if (MainCharacterState.LDir.X == 1)
                {
                    game.mainCharacter = new SpriteMoveRight(game);
                    
                }
                else if (MainCharacterState.LDir.Y == -1)
                {
                    game.mainCharacter = new SpriteMoveUp(game);
                    
                }
                else if (MainCharacterState.LDir.Y == 1)
                {
                    game.mainCharacter = new SpriteMoveDown(game);
                    
                }
            }
            if (game.DungeonRooms.TransitionTime > 0)
            {
                if (MainCharacterState.LDir.X == -1)
                {
                    MainCharacterState.XPos += (Constants.gameWindowWidth-2*Constants.wallWidth)/ Constants.roomTransitionTime;
                }
                else if (MainCharacterState.LDir.X == 1)
                {
                    MainCharacterState.XPos -= (Constants.gameWindowWidth -2*Constants.wallWidth) / Constants.roomTransitionTime;
                }
                else if (MainCharacterState.LDir.Y == -1)
                {
                    MainCharacterState.YPos += (Constants.gameWindowHeight -3*Constants.wallWidth) / Constants.roomTransitionTime;
                }
                else if (MainCharacterState.LDir.Y == 1)
                {
                    MainCharacterState.YPos -= (Constants.gameWindowHeight - 3*Constants.wallWidth) / Constants.roomTransitionTime;
                }
            }
            else
            {
                if (!MainCharacterState.Attack)
                {
                    //This is to make sprite go to stationary if no direction key was pressed
                    if (MainCharacterState.LastChange == MainCharacterState.Frame - 1)
                    {
                        MainCharacterState.Direction = new Vector2(0, 0);
                        if (MainCharacterState.LDir.X == -1)
                        {
                            game.mainCharacter = new SpriteStationaryLeft(game);
                        }
                        else if (MainCharacterState.LDir.X == 1)
                        {
                            game.mainCharacter = new SpriteStationaryRight(game);
                        }
                        else if (MainCharacterState.LDir.Y == -1)
                        {
                            game.mainCharacter = new SpriteStationaryUp(game);
                        }
                        else if (MainCharacterState.LDir.Y == 1)
                        {
                            game.mainCharacter = new SpriteStationaryDown(game);
                        }

                    }
                    MainCharacterState.Frame++;
                    CollisionHandler.mainCharacterRoomCollision(game);
                }
                if (MainCharacterState.Attack)
                {
                    Boolean noneAlready = true;
                    IProjectile attackProj = new Attack(game, MainCharacterState.XPos, MainCharacterState.YPos, MainCharacterState.LDir, false);
                    foreach (IProjectile attack in GameProjectiles.Projectiles)
                    {
                        if (attack.GetType().Equals(attackProj.GetType()))
                        {
                            noneAlready = false;
                        }
                    }
                    if(noneAlready)game.DungeonRooms.AddProjectile(attackProj);
                }
                Rectangle projectileCollision = new Rectangle(MainCharacterState.DestinationRectangle.X + MainCharacterState.DestinationRectangle.Width / 8, MainCharacterState.DestinationRectangle.Y + MainCharacterState.DestinationRectangle.Height / 8, MainCharacterState.DestinationRectangle.Width * 3 / 4, MainCharacterState.DestinationRectangle.Height * 3 / 4);

                if (game.DungeonRooms.HitsProjectile(projectileCollision, false)&&game.DungeonRooms.TransitionTime<-50&&!MainCharacterState.invincible)
                {
                    
                    Console.WriteLine("Link took damage, health = " + MainCharacterState.Health);
                    game.mainCharacter.takeDamage();


                }
            }
        }

        public virtual void Draw()
        {
            
        }

        
        public void Shoot()
        {

            IProjectile shot = null;
            switch (MainCharacterState.CurrentItem) // used a switch statement instead of multiple if statements
            {
                case Constants.items.Bow:
                    shot = new Arrow(game, MainCharacterState.XPos, MainCharacterState.YPos, MainCharacterState.LDir,false);
                    break;
                case Constants.items.Bomb:
                    if (MainCharacterState.InventoryItems[Constants.items.Bomb] > 0)
                    {
                        shot = new Bomb(game, MainCharacterState.XPos, MainCharacterState.YPos, MainCharacterState.LDir, false);
                        MainCharacterState.InventoryItems[Constants.items.Bomb]--;
                    }  
                    break;
                case Constants.items.Boomerang:
                    if (MainCharacterState.InventoryItems.ContainsKey(Constants.items.Boomerang))
                    {
                        MainCharacterState.InventoryItems.Remove(Constants.items.Boomerang);
                        shot = new Boomerang(game, MainCharacterState.XPos, MainCharacterState.YPos, MainCharacterState.LDir, false);
                    }
                    break;
                case Constants.items.Candle:
                    if (MainCharacterState.InventoryItems.ContainsKey(Constants.items.Candle))
                    {
                        MainCharacterState.InventoryItems.Remove(Constants.items.Candle);
                        shot = new Flame(game, MainCharacterState.XPos, MainCharacterState.YPos, MainCharacterState.LDir, false);
                    }
                    break;
                default:
                    // Optionally handle an unexpected item choice
                    break;
            }

            if (shot != null)
            {
                game.DungeonRooms.AddProjectile(shot);
                
            }

        }
        public Rectangle location()
        {
            return MainCharacterState.DestinationRectangle;
        }
        public void takeDamage()
        {
            if(MainCharacterState.CurrentItem == Constants.items.Ring)
            {
                MainCharacterState.Health--;
            }
            else
            {
                MainCharacterState.Health-=2;
            }
            
        }
    }
}