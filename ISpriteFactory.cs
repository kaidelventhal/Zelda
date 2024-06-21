using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zelda
{
    public interface ISpriteFactory
    {
        // Create a sprite for attacking left
        ISprite CreateSpriteAttackLeft(Game1 game);

        // Create a sprite for attacking right
        ISprite CreateSpriteAttackRight(Game1 game);

        // Create a sprite for attacking up
        ISprite CreateSpriteAttackUp(Game1 game);

        // Create a sprite for attacking down
        ISprite CreateSpriteAttackDown(Game1 game);
    }
}
