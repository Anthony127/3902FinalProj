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
        /* So the idea here is to have the handler call GetType() and get back like MarioAndEnemy (or maybe KoopaAndKoopa down the line), then it knows
         * what the first and second entities should be. Thus, it should cast GetFirstEntity() and GetSecondEntity() to what it knows they should be and
         then have that specific handler do whatever else it does */

        string GetType(); //I feel like this should return one of like several enums: MarioAndEnemy, MarioAndBlock, MarioAndItem (maybe handle during refactor?)
        Rectangle GetOverlap();
        CollisionConstants.Direction GetFirstEntityRelativePosition();
        Object GetFirstEntity();
        Object GetSecondEntity();

    }
}
