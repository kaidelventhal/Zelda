using System;

namespace Zelda
{
    public class CommandGhostSwordAttack : ICommand
    {
        Game1 game;
        public CommandGhostSwordAttack(Game1 game)
        {
            this.game = game;

        }

        public void Execute()
        {
            Console.WriteLine("Ghost Sword Attack");
        }
    }
}
