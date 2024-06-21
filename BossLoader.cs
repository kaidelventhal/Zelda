using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zelda.Enemies;
using Zelda.RoomRoomObjects;
using Zelda.Rooms;
using Zelda.ZeldaItems;

namespace Zelda
{
    public class BossLoader : ISprite
    {
        private Game1 game;
        private Rectangle doorSource;
        private Rectangle doorDestination;
        private int timer;
        private int count;
        private Boolean initialized;
        private Boolean initializedBoss;
        string score;
        public BossLoader(Game1 game) 
        {
            this.game = game;
            initialized = false;
            initializedBoss = false;
            
            timer = 0;
            score = "Score: " + count;
        }
        public void Draw()
        {
            game.SpriteBatch.Draw(game.Textures.GameBoardTexture, doorDestination, doorSource, Color.White);
           
        }

        public void Update()
        {
            score = "Score: " + count;

            if (!initialized)
            {
                game.DungeonRooms.AddItem(new Tree(game, 100 + Constants.dungeonLoaderOffsetX, 220 + Constants.dungeonLoaderOffsetY, false));
                initialized = true;
            }
            if (game.DungeonRooms.CurrentRoom == 0&&!initializedBoss)
            {
                game.DungeonRooms.AddEnemy(new Boss(game, 128 + Constants.dungeonLoaderOffsetX, 320 + Constants.dungeonLoaderOffsetY, 0));
               
                initializedBoss = true;

            }

        }
    }
}
