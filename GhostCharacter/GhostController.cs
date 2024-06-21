using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zelda
{
    public class GhostController : IController
    {
        private Dictionary<string, ICommand> LinkCommandNameToGhostCommands = new Dictionary<string, ICommand>();

        private string[] commandNames = {};
        private int frame = 0;

        public GhostController(Game1 game)
        {
            LinkCommandNameToGhostCommands.Add(typeof(CommandLinkShoot).Name, new CommandGhostShoot(game));
            LinkCommandNameToGhostCommands.Add(typeof(CommandMoveLeft).Name, new CommandGhostMoveLeft(game));
            LinkCommandNameToGhostCommands.Add(typeof(CommandMoveRight).Name, new CommandGhostMoveRight(game));
            LinkCommandNameToGhostCommands.Add(typeof(CommandMoveUp).Name, new CommandGhostMoveUp(game));
            LinkCommandNameToGhostCommands.Add(typeof(CommandMoveDown).Name, new CommandGhostMoveDown(game));
            LinkCommandNameToGhostCommands.Add(typeof(CommandLinkSwordAttack).Name, new CommandGhostSwordAttack(game));

            if(File.Exists(Constants.ghostFileName))
            {
                commandNames = Array.FindAll(File.ReadAllLines(Constants.ghostFileName), command => LinkCommandNameToGhostCommands.Keys.Contains(command));
                if(commandNames.Length <= 0)
                {
                    
                }
                File.Delete(Constants.ghostFileName);
            }
        }

        public void Update()
        {
            if (frame < commandNames.Length && LinkCommandNameToGhostCommands.Keys.Contains(commandNames[frame]))
            {
                LinkCommandNameToGhostCommands[commandNames[frame]].Execute();
            }
            frame++;
        }
    }
}
