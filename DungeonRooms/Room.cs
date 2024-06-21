using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Transactions;
using Zelda.Enemies;
using Zelda.Projectiles;
using Zelda.RoomRoomObjects;


namespace Zelda.Rooms
{
    public class Room : ISprite
    {
        Rectangle window;
        public Rectangle Window { get { return window; } }
        Rectangle destination;
        public List<Rectangle> Colliable;
        private EnemyFactory enemies;
        public EnemyFactory Enemies { get { return enemies; } }
        private RoomObjects items;
        public RoomObjects Items {  get { return items; } set { items = value; } }
        Game1 game;
        private GameProjectiles projectiles;
        public GameProjectiles Projectiles { get { return projectiles; } }
        public int pauseEnemies = 0;
        public int PauseEnemies { get { return pauseEnemies; }set { pauseEnemies = value; } }

        Rectangle tempWindow;
        Rectangle nextRectangle;
        public Room(Game1 game, Rectangle sourceRectangle,Rectangle destinationRectangle, List<Rectangle> rectangleList, EnemyFactory enemies, RoomObjects items)
        {

            window = sourceRectangle;
            this.enemies = enemies;
            this.items = items;
            destination = destinationRectangle;
            Colliable = rectangleList;
            this.game = game;
            projectiles = new GameProjectiles(game);
        }
        public void Draw()
        {
            if (game.DungeonRooms.TransitionTime > 0)
            {
                game.SpriteBatch.Draw(game.Textures.Level1, destination, tempWindow, Color.White);
            }
            else
            {
                game.SpriteBatch.Draw(game.Textures.Level1, destination, window, Color.White);
                items.Draw();
                enemies.Draw();
                projectiles.Draw();
            }        
        }

        public void Update()
        {
            if (game.DungeonRooms.TransitionTime >= Constants.roomTransitionTime-1)
            {
                tempWindow = window;
            }
            if (game.DungeonRooms.TransitionTime>0)
            {
                if (tempWindow.X <nextRectangle.X)
                {
                    tempWindow.X+=tempWindow.Width/ Constants.roomTransitionTime;
                }
                else if (tempWindow.X > nextRectangle.X)
                {
                    tempWindow.X-= tempWindow.Width / Constants.roomTransitionTime;
                }

                else if (tempWindow.Y < nextRectangle.Y)
                {
                    tempWindow.Y+= tempWindow.Height / Constants.roomTransitionTime;
                }
                else if (tempWindow.Y > nextRectangle.Y)
                {
                    tempWindow.Y-=tempWindow.Height/ Constants.roomTransitionTime;
                }
            }
            items.Update();
            if (pauseEnemies-- < 0)
            {
                enemies.Update();
            }    
            projectiles.Update();
        }
        public void changeRoom(Rectangle toRectangle)
        {
            nextRectangle = toRectangle;
            SoundLoader.openDoor.Play();
        } 
    }
}
