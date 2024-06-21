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

namespace Zelda
{
    public class Gladiator : ISprite
    {
        private Game1 game;
        private Rectangle doorSource;
        private Rectangle doorDestination;
        private int timer;
        private int count;
        private Boolean initialized;
        string score;
        public Gladiator(Game1 game) 
        {
            this.game = game;
            initialized = false;
            
            timer = 0;
            score = "Score: " + count;
        }
        public void Draw()
        {
            game.SpriteBatch.Draw(game.Textures.GameBoardTexture, doorDestination, doorSource, Color.White);
            game.SpriteBatch.DrawString(game.Textures.CountFont, score, new Vector2(350, 100), Color.White,1.0F,new Vector2(0,0),1.0F,SpriteEffects.None,-1.0F);
        }

        public void Update()
        {
            score = "Score: " + count;
            if (!initialized)
            {
                game.DungeonRooms.CurrentRoom = 0;
                doorSource = new Rectangle(815, 77, 32, 32);
                doorDestination = new Rectangle(896 + Constants.dungeonLoaderOffsetX, 289 + Constants.dungeonLoaderOffsetY, doorSource.Width * 4, doorSource.Height * 4);
                game.DungeonRooms.getCurrentRoom().Colliable.Add(doorDestination);
                game.DungeonRooms.getCurrentRoom().Items = new RoomObjects(game, new List<ISprite>());
                initialized = true;
            }
            if (timer++ % 400 == 0)
            {
                count++;
                int spawnX = (int)((Constants.gameWindowWidth -3*Constants.wallWidth)* Constants.random.NextDouble());
                int spawnY = (int)((Constants.gameWindowHeight - 3 * Constants.wallWidth) * Constants.random.NextDouble());
                double r = Constants.random.NextDouble();
                if (r < .25)
                {
                    game.DungeonRooms.AddEnemy(new Gel(game, spawnX + Constants.dungeonLoaderOffsetX + Constants.wallWidth, spawnY + Constants.dungeonLoaderOffsetY + Constants.wallWidth));
                }
                else if (r < .5)
                {
                    game.DungeonRooms.AddEnemy(new Skeleton(game, spawnX + Constants.dungeonLoaderOffsetX + Constants.wallWidth, spawnY + Constants.dungeonLoaderOffsetY + Constants.wallWidth, false));
                }else if (r < .8)
                {
                    game.DungeonRooms.AddEnemy(new Goriya(game, spawnX + Constants.dungeonLoaderOffsetX + Constants.wallWidth, spawnY + Constants.dungeonLoaderOffsetY + Constants.wallWidth));
                }
                else if (r < .9)
                {
                    game.DungeonRooms.AddEnemy(new Darknut(game, spawnX + Constants.dungeonLoaderOffsetX + Constants.wallWidth, spawnY + Constants.dungeonLoaderOffsetY + Constants.wallWidth));
                }else if (r < 95)
                {
                    game.DungeonRooms.AddEnemy(new Wizzrobe(game, spawnX + Constants.dungeonLoaderOffsetX + Constants.wallWidth, spawnY + Constants.dungeonLoaderOffsetY + Constants.wallWidth));
                }
                
            }
            
        }
    }
}
