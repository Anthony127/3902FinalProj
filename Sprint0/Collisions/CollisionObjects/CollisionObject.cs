using Microsoft.Xna.Framework;
using SuperPixelBrosGame.Interfaces;

namespace SuperPixelBrosGame.Collisions.Collisions
{
    class CollisionObject : ICollision
    {
        private ICollidable firstEntity;
        private ICollidable secondEntity;
        private Rectangle overlap;
        private CollisionConstants.Direction firstEntityRelativePosition;

        public ICollidable FirstEntity
        {
            get
            {
                return firstEntity;
            }
        }

        public ICollidable SecondEntity
        {
            get
            {
                return secondEntity;
            }
        }

        public Rectangle Overlap
        {
            get
            {
                return overlap;
            }
        }

        public CollisionConstants.Direction FirstEntityRelativePosition
        {
            get
            {
                return firstEntityRelativePosition;
            }
        }

        public CollisionObject(ICollidable firstEntity, ICollidable secondEntity)
        {
            this.firstEntity = firstEntity;
            this.secondEntity = secondEntity;
            overlap = Rectangle.Intersect(firstEntity.GetHitbox(), secondEntity.GetHitbox());
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
                    firstEntityRelativePosition = CollisionConstants.Direction.Down;
                }
                else
                {
                    firstEntityRelativePosition = CollisionConstants.Direction.Up;
                }
            }
            else
            {
                if (marioLocation.X < blockLocation.X)
                {
                    firstEntityRelativePosition = CollisionConstants.Direction.Left;
                }
                else
                {
                    firstEntityRelativePosition = CollisionConstants.Direction.Right;
                }
            }

        }
    }
}
