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
        ICollidable FirstEntity { get; }
        ICollidable SecondEntity { get; }
        CollisionConstants.Direction FirstEntityRelativePosition { get; }
        Rectangle Overlap { get; }

    }
}
