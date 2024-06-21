using System;

namespace Zelda
{
    public class CommandGhostShoot : ICommand
    {
        Game1 game;
        public CommandGhostShoot(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            Console.WriteLine("Ghost Shoot");
        }
    }
}