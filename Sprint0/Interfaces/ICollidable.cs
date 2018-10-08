using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Interfaces
{
    public interface ICollidable
    {
        Rectangle GetHitbox();
        void SetHitbox(Rectangle hitbox);
        Vector2 GetLocation();
    }
}
