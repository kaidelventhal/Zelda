

using Microsoft.Xna.Framework;
using System;

namespace Zelda
{
    public interface IProjectile
    {
        void Update();

        void Draw();

        public bool HitsProjectile(Rectangle hitbox, bool enemy);
    }
}
