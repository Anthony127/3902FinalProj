using Microsoft.Xna.Framework;
using SuperPixelBrosGame.Collisions.Collisions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPixelBrosGame.Interfaces
{
    public interface ICollision
    {
        Rectangle GetOverlap();
        CollisionConstants.Direction GetFirstEntityRelativePosition();
        ICollidable GetFirstEntity();
        ICollidable GetSecondEntity();

    }
}
