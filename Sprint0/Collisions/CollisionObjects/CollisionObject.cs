using Microsoft.Xna.Framework;
using SuperPixelBrosGame.Interfaces;

namespace SuperPixelBrosGame.Collisions.Collisions
{
    class CollisionObject : ICollision
    {
        private ICollidable firstEntity;
        private ICollidable secondEntity;
        private Rectangle overlap;

        public CollisionObject(ICollidable firstEntity, ICollidable secondEntity)
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
            Point marioLocation = firstEntity.GetHitbox().Location;
            Point blockLocation = secondEntity.GetHitbox().Location;
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
