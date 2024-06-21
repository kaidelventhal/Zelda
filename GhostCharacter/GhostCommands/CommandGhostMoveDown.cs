using Microsoft.Xna.Framework;
using System;

namespace Zelda
{
    public class CommandGhostMoveDown : ICommand
    {
        Game1 game;
        GhostCharacterSprite sprite;
        public CommandGhostMoveDown(Game1 game)
        {
            this.game = game;
            sprite = new GhostSpriteMoveDown(game);
        }

        public void Execute()
        {
            GhostCharacterState.LDir = new Vector2(0, -1);
            GhostCharacterState.YPos = GhostCharacterState.YPos + Constants.linkSpeed;
            game.ghostCharacter = sprite;
            Console.WriteLine("Ghost Move Down");
        }
    }
}