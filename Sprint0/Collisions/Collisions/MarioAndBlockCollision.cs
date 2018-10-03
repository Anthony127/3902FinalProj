using Microsoft.Xna.Framework;
using Sprint0.Interfaces;

namespace Sprint0.Collisions.Collisions
{
    class MarioAndBlockCollision : ICollision
    {
        private IMario firstEntity;
        private IBlock secondEntity;
        private Rectangle overlap;

        public MarioAndBlockCollision(IMario mario, IBlock block)
        {
            firstEntity = mario;
            secondEntity = block;
            overlap = Rectangle.Intersect(mario.GetHitbox(), block.GetHitbox());
            //System.Console.WriteLine("COLLISION: Width: " + overlap.Width + " Height: " + overlap.Height + "\n");
        }

        public object GetFirstEntity()
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

        public object GetSecondEntity()
        {
            return secondEntity;
        }

        string ICollision.GetType()
        {
            return "MarioAndBlockCollision";
        }
    }
}
