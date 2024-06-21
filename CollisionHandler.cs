using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Zelda
{
    public static class CollisionHandler
    {

        public static void mainCharacterRoomCollision(Game1 game)
        {
            Rectangle hitbox = MainCharacterState.DestinationRectangle;
            Rectangle smallerHitbox = new Rectangle(hitbox.X + (60 / 4), hitbox.Y + (100 / 4), 60 / 2, 100 / 2);
    
            if (hitsBoundry(game, smallerHitbox)&&game.DungeonRooms.TransitionTime<0&&!MainCharacterState.Invincible)
            {
                MainCharacterState.DestinationRectangle = MainCharacterState.InboundsRectangle;
                MainCharacterState.XPos = MainCharacterState.DestinationRectangle.X;
                MainCharacterState.YPos = MainCharacterState.DestinationRectangle.Y;
            }
            else
            {
                MainCharacterState.InboundsRectangle = MainCharacterState.DestinationRectangle;
            }
        }

        public static void ghostCharacterRoomCollision(Game1 game)
        {
            Rectangle hitbox = GhostCharacterState.DestinationRectangle;
            Rectangle smallerHitbox = new Rectangle(hitbox.X + (60 / 4), hitbox.Y + (100 / 4), 60 / 2, 100 / 2);

            if (hitsBoundry(game, smallerHitbox))
            {
                GhostCharacterState.DestinationRectangle = GhostCharacterState.InboundsRectangle;
                GhostCharacterState.XPos = GhostCharacterState.DestinationRectangle.X;
                GhostCharacterState.YPos = GhostCharacterState.DestinationRectangle.Y;
            }
            else
            {
                GhostCharacterState.InboundsRectangle = GhostCharacterState.DestinationRectangle;
            }
        }
        public static bool hitsBoundry(Game1 game, Rectangle sprite)
        {
            foreach (Rectangle r in game.DungeonRooms.getCurrentRoom().Colliable)
            {
                if (r.Intersects(sprite))
                {
                    return true;
                }
            }
            return false;
        }
        public static bool hitsWall(Game1 game, Rectangle sprite)
        {
            if (sprite.X < Constants.dungeonLoaderOffsetX + Constants.wallWidth)
            {
                return true;
            }
            if (sprite.Y < Constants.dungeonLoaderOffsetY + Constants.wallWidth)
            {
                return true;
            }
            if (sprite.X + sprite.Width > Constants.dungeonLoaderOffsetX + Constants.gameWindowWidth - Constants.wallWidth)
            {
                return true;
            }
            if (sprite.Y + sprite.Height > Constants.dungeonLoaderOffsetY + Constants.gameWindowHeight - Constants.wallWidth)
            {
                return true;
            }
            return false;
        }

        public static bool mainCharacterEnemyColision(Game1 game, Rectangle positionRectangle, bool currentCollision)
        {
            if (!currentCollision && MainCharacterState.DestinationRectangle.Intersects(positionRectangle)&&game.DungeonRooms.TransitionTime<0)
            {
                game.mainCharacter.takeDamage();
                Console.WriteLine("Link Collided with Enemy");
                SoundLoader.takeDamage.Play();
                currentCollision = true;
            }

            if (!MainCharacterState.DestinationRectangle.Intersects(positionRectangle))
            {
                currentCollision = false;
            }

            return currentCollision;
        }
    }
}
