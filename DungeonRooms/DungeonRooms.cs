using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Xml;
using System.Data.SqlTypes;
using System;
using System.Xml.Linq;
using Zelda.Enemies;
using Zelda.Projectiles;
using System.Security.Cryptography.X509Certificates;
using Zelda.RoomRoomObjects;



namespace Zelda.Rooms
{
    public class DungeonRooms : ISprite
    {
        Rectangle window;
        List<Room> rooms;
        public List<Room> Rooms
            { get { return rooms; } }
        private int currentRoom;
        int transitionTime;
        public int TransitionTime { get { return transitionTime; } set { transitionTime = value; } }
        public int CurrentRoom
            {  get { return currentRoom; } set { currentRoom = value; } }
        private int nextRoomTrans;
        public int NextRoomTrans { get { return nextRoomTrans; } } 
        Game1 game;
        public DungeonRooms(Game1 game)
        {
            DungeonLoader loader = new DungeonLoader(game);
            rooms = loader.LoadDungeon("../../../DungeonRooms/ZeldaInput.xml");
            transitionTime = -1;
            this.game = game;
            this.currentRoom = 1;
        }
        public void Draw()
        {
            getCurrentRoom().Draw();
        }

        public void Update()
        {
            if (transitionTime-- == 0)
            {
                currentRoom = nextRoomTrans;
            }
            getCurrentRoom().Update();
            
        }

        public void AddItem(ISprite item)
        {
            getCurrentRoom().Items.AddItem(item);
        }
        public void RemoveItem(ISprite item)
        {
            getCurrentRoom().Items.RemoveItem(item);
        }
        public void AddProjectile(IProjectile projectile)
        {
            getCurrentRoom().Projectiles.addProjectile(projectile);
        }
        public void RemoveProjectile(IProjectile projectile)
        {
            getCurrentRoom().Projectiles.removeProjectile(projectile);
        }

        public void ClearProjectiles()
        {
            getCurrentRoom().Projectiles.clearProjectiles();
        }
        public bool HitsProjectile(Rectangle hitbox, bool enemy)
        {
            return getCurrentRoom().Projectiles.HitsProjectile(hitbox, enemy);
        }
        public bool HitsProjectile(Rectangle hitbox, bool enemy, string type)
        {
            return getCurrentRoom().Projectiles.HitsProjectile(hitbox, enemy,type);
        }
        public void nextRoom()
        {
            ClearProjectiles();
            currentRoom++;
            if(currentRoom> rooms.Count-1)
            {
                currentRoom = 0;
            }
            Console.WriteLine(currentRoom);

        }
        public void previousRoom()
        {
            ClearProjectiles();
            currentRoom--;
            if (currentRoom < 0)
            {
                currentRoom = rooms.Count-1;
            }
            Console.WriteLine(currentRoom);
            
        }
        public void changeRoom(int Roomnumber,int transitionTime)
        {
            
            ClearProjectiles();
            getCurrentRoom().changeRoom(rooms[Roomnumber].Window);
            this.transitionTime = transitionTime;
            nextRoomTrans = Roomnumber;
            
            Console.WriteLine(currentRoom);

        }
        public void RemoveEnemy(ISprite enemy)
        {
            getCurrentRoom().Enemies.RemoveEnemy(enemy);

        }
        public void AddEnemy(ISprite Enemy)
        {
            getCurrentRoom().Enemies.AddEnemy(Enemy);

        }
        public Room getCurrentRoom()
        {
            return rooms[currentRoom];
        }
    }
}
