using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using Zelda.RoomRoomObjects;
using Zelda.Projectiles;
using Zelda.Commands;
using Microsoft.Xna.Framework.Graphics;
using System.IO;

namespace Zelda
{
    public class KeyboardController : IController
    {
        private Dictionary<Keys, ICommand> KeysToCommands = new Dictionary<Keys, ICommand>();
        private HashSet<Keys> previousPressed = new HashSet<Keys>();
        private Game1 game;
        public KeyboardController(Game1 game)
        {
            this.game = game;
            KeysToCommands.Add(Keys.D0, new CommandQuit(game));
            KeysToCommands.Add(Keys.NumPad0, new CommandQuit(game));
            KeysToCommands.Add(Keys.Q, new CommandQuit(game));
            KeysToCommands.Add(Keys.R, new CommandReset(game));

            KeysToCommands.Add(Keys.W, new CommandMoveUp(game));
            KeysToCommands.Add(Keys.S, new CommandMoveDown(game));
            KeysToCommands.Add(Keys.D, new CommandMoveRight(game));
            KeysToCommands.Add(Keys.A, new CommandMoveLeft(game));
            KeysToCommands.Add(Keys.Up, new CommandMoveUp(game));
            KeysToCommands.Add(Keys.Down, new CommandMoveDown(game));
            KeysToCommands.Add(Keys.Right, new CommandMoveRight(game));
            KeysToCommands.Add(Keys.Left, new CommandMoveLeft(game));

            KeysToCommands.Add(Keys.B, new CommandLinkNextItem(game));

            KeysToCommands.Add(Keys.F, new CommandLinkShoot(game));
            KeysToCommands.Add(Keys.Z, new CommandLinkSwordAttack(game));
            KeysToCommands.Add(Keys.N, new CommandGameMode(game));

           
            KeysToCommands.Add(Keys.Escape, new CommandPauseScreen(game));
            KeysToCommands.Add(Keys.M, new CommandToggleMusic(game));
            KeysToCommands.Add(Keys.Enter, new CommandStartGame(game));

        }
        public void Update()
        {
            KeyboardState currentKeyboardState = Keyboard.GetState();
            HashSet<Keys> pressedSet = new HashSet<Keys>(currentKeyboardState.GetPressedKeys());
       
            
            foreach (Keys key in pressedSet)
            {
                /* Commands that need to be debounced. one click
                 * If statement is designed like this to sepcofically exclude Zelda movements 
                 * while changing items, weapons, obstacles, enemy, and etc. are all 
                 * one keyboard click events
                 */
                // Execute movement commands directly
                if (!game.IsPaused&&game.DungeonRooms.TransitionTime<0)
                {
                    if (key == Keys.W || key == Keys.A || key == Keys.S || key == Keys.D || key == Keys.Up || key == Keys.Down || key == Keys.Right || key == Keys.Left)
                    {
                        KeysToCommands[key]?.Execute();
                        recordCommand(KeysToCommands[key]);
                    }
                    // For other keys, ensure they were not previously pressed (debounce logic)
                    else if (!previousPressed.Contains(key))
                    {
                        if (KeysToCommands.ContainsKey(key))
                        {
                            KeysToCommands[key].Execute();
                            recordCommand(KeysToCommands[key]);
                        }
                        recordKey(key);
                    }
                }
                else
                {
                    //keys that can be pressed in load screen.
                    if ((key == Keys.Escape || key == Keys.M || key == Keys.D0||key ==Keys.B||key==Keys.Enter || key == Keys.R || key == Keys.Q || key == Keys.N) && !previousPressed.Contains(key))
                    {
                        KeysToCommands[key].Execute();
                        recordCommand(KeysToCommands[key]);
                    }
                }

             }
            previousPressed = pressedSet;
        }

        private void recordCommand(ICommand command)
        {
            File.AppendAllText(Constants.ghostFileName, command.GetType().Name + Environment.NewLine);
        }

        private void recordKey(Keys key)
        {
            new CommandLogKey(game, key).Execute();
        }
    }
}
