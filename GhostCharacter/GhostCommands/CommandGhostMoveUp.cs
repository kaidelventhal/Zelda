using Microsoft.Xna.Framework;
using System;

namespace Zelda
{
    public class CommandGhostMoveUp : ICommand
    {
        Game1 game;
        GhostCharacterSprite sprite;
        public CommandGhostMoveUp(Game1 game)
        {
            this.game = game;
            sprite = new GhostSpriteMoveUp(game);
        }

        public void Execute()
        {
            GhostCharacterState.LDir = new Vector2(0, 1);
            GhostCharacterState.YPos = GhostCharacterState.YPos - Constants.linkSpeed;
            game.ghostCharacter = sprite;
            //Console.WriteLine("Ghost Move Up");
        }
    }
}