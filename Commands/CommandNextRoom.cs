using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zelda.Commands
{
    public class CommandNextRoom : ICommand
    {
        private Game1 game;
        public void Execute()
        {
            game.DungeonRooms.nextRoom();
        }
        public CommandNextRoom(Game1 game)
        {
            this.game = game;
        }
    }
}