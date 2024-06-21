using Microsoft.Xna.Framework;
using System;

namespace Zelda
{
    public class CommandGhostMoveRight : ICommand
    {
        Game1 game;
        GhostCharacterSprite sprite;
        public CommandGhostMoveRight(Game1 game)
        {
            this.game = game;
            sprite = new GhostSpriteMoveRight(game);
        }

        public void Execute()
        {
            GhostCharacterState.LDir = new Vector2(1, 0);
            GhostCharacterState.XPos = GhostCharacterState.XPos + Constants.linkSpeed;
            game.ghostCharacter = sprite;
            //Console.WriteLine("Ghost Move Right");
        }
    }
}