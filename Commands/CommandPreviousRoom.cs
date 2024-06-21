using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zelda.Commands
{
    public class CommandPreviousRoom : ICommand
    {
        private Game1 game;
        public void Execute()
        {
            game.DungeonRooms.previousRoom();
        }
        public CommandPreviousRoom(Game1 game)
        {
            this.game = game;
        }
    }
}
