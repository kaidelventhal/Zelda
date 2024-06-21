using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zelda.Commands;
namespace Zelda;

public class CheatCodeController : IController
{

    private List<string> keys = new List<string>(); 
    Game1 game;
    Dictionary<string, ICommand> commands;
        
    public CheatCodeController(Game1 game)
    {
     
        this.game = game;
        commands = new Dictionary<string, ICommand>
        {
            { "H",new CommandCheatH(game)},
            { "I",new CommandCheatI(game)},
            { "K",new CommandCheatK(game)},
            { "J",new CommandCheatJ(game)},
            { "G",new CommandCheatG(game)},
        };
       
    }

    public void LogKey(string key)
    {
        keys.Add(key);
    }

    public void Update()
    {
        if (keys.Count>4&&keys[keys.Count-4] == "O" && keys[keys.Count - 3] == "L" && keys[keys.Count - 2] == "P")
        {
            Console.WriteLine("Cheat mode detected!");

            // Execute command related to cheat
            if (commands.ContainsKey(keys[keys.Count - 1]))
            {
                commands[keys[keys.Count - 1]].Execute();
                keys.Clear();
            }
            
        }
        
    }
}
