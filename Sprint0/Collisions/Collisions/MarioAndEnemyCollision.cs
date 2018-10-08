using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using System;

namespace Sprint0.Collisions.Collisions
{
    class MarioAndEnemyCollision : ICollision
    {
        private ICollidable firstEntity;
        private ICollidable secondEntity;
        private Rectangle overlap;

        public MarioAndEnemyCollision(ICollidable firstEntity, ICollidable secondEntity)
        {
            this.firstEntity = firstEntity;
            this.secondEntity = secondEntity;
            overlap = Rectangle.Intersect(firstEntity.GetHitbox(), secondEntity.GetHitbox());
        }

        public ICollidable GetFirstEntity()
        {
            return firstEntity;
        }

        public CollisionConstants.Direction GetFirstEntityRelativePosition()
        {
            Vector2 marioLocation = firstEntity.GetLocation();
            Vector2 blockLocation = secondEntity.GetLocation();
            bool vertical = true;
            if (overlap.Height > overlap.Width)
            {
                vertical = false;
            }
            if (vertical)
            {
                if (marioLocation.Y > blockLocation.Y)
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
                if (marioLocation.X < blockLocation.X)
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
            return overlap;
        }

        public ICollidable GetSecondEntity()
        {
            return secondEntity;
        }
    }
}
