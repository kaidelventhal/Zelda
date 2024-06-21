using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Zelda.RoomRoomObjects;
using Zelda.Projectiles;
using Zelda.Enemies;
using Zelda.Rooms;
using System.Collections.Generic;
using System;


namespace Zelda
{
    public class CommandEndGame : ICommand
    {
        private Game1 game;
        private bool isOver;
        
        public CommandEndGame(Game1 game)
        {
            this.game = game;
            isOver = false;
        }

        public void Execute()
        {
            isOver = !isOver;
            game.IsOver = isOver;
            Console.WriteLine("game over " + isOver);
        }  
    }
}