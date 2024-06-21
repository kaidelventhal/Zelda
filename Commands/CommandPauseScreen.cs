using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Zelda.RoomRoomObjects;
using Zelda.Projectiles;
using Zelda.Enemies;
using Zelda.Rooms;
using System.Collections.Generic;
using System;


namespace Zelda.Commands
{
    public class CommandPauseScreen : ICommand
    {
        private Game1 game;
        private bool isPaused;

        public CommandPauseScreen(Game1 game)
        {
            this.game = game;
            isPaused = false;
        }

        public void Execute()
        {            
            isPaused = !isPaused;
            game.IsPaused = isPaused;
            Console.WriteLine("game pausued " + isPaused);
        }
        }
    }

