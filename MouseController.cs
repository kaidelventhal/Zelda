using Microsoft.Xna.Framework.Input;
using System;
using Zelda.Commands;

namespace Zelda
{
    public class MouseController : IController
    {
        MouseState mState;
        MouseState previousState;
        //ICommand CurrentCommand;
        ICommand nextRoom;
        ICommand previousRoom;
        Game1 game;
        public MouseController(Game1 game)
        {
            this.game = game;
            mState = new MouseState();
            nextRoom= new CommandNextRoom(game);
            previousRoom = new CommandPreviousRoom(game);
            
        }

        public void Update()
        {
            
            mState = Mouse.GetState();
            if (previousState.LeftButton == ButtonState.Pressed && mState.LeftButton == ButtonState.Released)
            {
                previousRoom.Execute();
            }
            if(previousState.RightButton == ButtonState.Pressed&&mState.RightButton==ButtonState.Released)
            {
                nextRoom.Execute();
            }
            previousState = mState;
        }
    }
}
