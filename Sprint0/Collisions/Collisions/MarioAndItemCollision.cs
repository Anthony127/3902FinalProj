using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using System;

namespace Sprint0.Collisions.Collisions
{
    class MarioAndItemCollision : ICollision
    {
        private IMario firstEntity;
        private IItem secondEntity;
        private Rectangle overlap;

        public MarioAndItemCollision(IMario mario, IItem item)
        {
            firstEntity = mario;
            secondEntity = item;
            overlap = Rectangle.Intersect(mario.GetCurrentHitbox(), item.GetHitbox());
        }

        public object GetFirstEntity()
        {
            return firstEntity;
        }

        public CollisionConstants.Direction GetFirstEntityRelativePosition()
        {
            Vector2 marioLocation = firstEntity.GetLocation();
            Vector2 itemLocation = secondEntity.GetLocation();
            bool vertical = true;
            if (overlap.Height > overlap.Width)
            {
                vertical = false;
            }
            if (vertical)
            {
                if (marioLocation.Y > itemLocation.Y)
                {
                    return CollisionConstants.Direction.Down;
                }
                else
                {
                    return CollisionConstants.Direction.Up;
                }
            }
            else
            {
                if (marioLocation.X < itemLocation.X)
                {
                    return CollisionConstants.Direction.Left;
                }
                else
                {
                    return CollisionConstants.Direction.Right;
                }
            }
        }

        public Rectangle GetOverlap()
        {
            Rectangle marioHitbox = firstEntity.GetCurrentHitbox();
            Rectangle itemHitbox = secondEntity.GetHitbox();

            return Rectangle.Intersect(marioHitbox, itemHitbox);
        }

        public object GetSecondEntity()
        {
            return secondEntity;
        }

        string ICollision.GetType()
        {
            return "MarioAndItemCollision";
        }
    }
}
