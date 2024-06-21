using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Zelda.Projectiles;
using Zelda.Rooms;
namespace Zelda
{
    public abstract class GhostCharacterSprite : ISprite
    {

        protected Game1 game;

        public GhostCharacterSprite(Game1 game)
        {
            this.game = game;

        }
        public virtual void Update()
        {
            if (game.DungeonRooms.TransitionTime > 0)
            {
                if (GhostCharacterState.LDir.X == -1)
                {
                    game.ghostCharacter = new GhostSpriteStationaryLeft(game);
                    GhostCharacterState.XPos += 8;
                }
                else if (GhostCharacterState.LDir.X == 1)
                {
                    game.ghostCharacter = new GhostSpriteStationaryRight(game);
                    GhostCharacterState.XPos -= 10;
                }
                else if (GhostCharacterState.LDir.Y == -1)
                {
                    game.ghostCharacter = new GhostSpriteStationaryUp(game);
                    GhostCharacterState.YPos += 5;
                }
                else if (GhostCharacterState.LDir.Y == 1)
                {
                    game.ghostCharacter = new GhostSpriteStationaryDown(game);
                    GhostCharacterState.YPos -= 5;
                }
            }
            else
            {
                    CollisionHandler.ghostCharacterRoomCollision(game);
            }
        }

        public virtual void Draw()
        {

        }

    }
}