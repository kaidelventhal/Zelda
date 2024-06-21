using Microsoft.Xna.Framework;
using System;
using System.Security.Cryptography;

namespace Zelda.Commands
{
    public class CommandCheatG : ICommand
    {
        private Game1 game;

        public CommandCheatG(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            MainCharacterState.invincible = true;
        }

    }
    public class CommandCheatI : ICommand
    {
        private Game1 game;

        public CommandCheatI(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            if (MainCharacterState.InventoryItems.ContainsKey(Constants.items.Bomb))
            {
                MainCharacterState.InventoryItems[Constants.items.Bomb] += 10;
            }
            else
            {
                MainCharacterState.InventoryItems.Add(Constants.items.Bomb, 10);
            }
            
        }

    }
    public class CommandCheatK : ICommand
    {
        private Game1 game;

        public CommandCheatK(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            MainCharacterState.InventoryItems[Constants.items.Key] += 10;
        }

    }
    public class CommandCheatJ : ICommand
    {
        private Game1 game;

        public CommandCheatJ(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            MainCharacterState.InventoryItems[Constants.items.Rupee] += 10;
        }

    }
    public class CommandCheatH : ICommand
    {
        private Game1 game;

        public CommandCheatH(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            MainCharacterState.Health = Constants.linkMaxHealth;
        }

    }
}
