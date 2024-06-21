

using Microsoft.Xna.Framework;
using System;
using System.Runtime.CompilerServices;

namespace Zelda.ZeldaItems
{
    public class Tree : Iitem
    {
        private Rectangle sourceRectangle;
        private Rectangle spawnRectangle;
        private Rectangle destinationRectangle;

        bool spawnWhenAllDead;
        Game1 game;
        
        public Tree(Game1 game, int xPosition, int yPosition, bool spawnWhenAllDead)
        {
            sourceRectangle = new Rectangle(0, 0, 550, 420);
            spawnRectangle = new Rectangle(xPosition, yPosition, 100, 100);  


            this.game = game;
        }
        public void Draw()
        {
            game.SpriteBatch.Draw(game.Textures.BossTree, spawnRectangle, sourceRectangle, Color.White);
        }

        public void Update()
        {

            Console.WriteLine("tree creat");
        }
    }
}
