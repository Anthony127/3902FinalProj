using Microsoft.Xna.Framework;
using Sprint0.Collisions.Collisions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Interfaces
{
    public interface ICollision
    {
        Rectangle GetOverlap();
        CollisionConstants.Direction GetFirstEntityRelativePosition();
        ICollidable GetFirstEntity();
        ICollidable GetSecondEntity();

    }
}
