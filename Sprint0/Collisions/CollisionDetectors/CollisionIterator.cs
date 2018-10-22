using SuperPixelBrosGame.Collisions.Collisions;
using SuperPixelBrosGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPixelBrosGame.Collisions.CollisionDetectors
{
    class CollisionIterator : ICollisionIterator
    {
        private List<string> collisionTypesDetected = new List<string>();

        public void ProcessCollisions(IList<ICollidable> firstEntities, IList<ICollidable> secondEntities, ICollisionHandler collisionHandler)
        {
            collisionTypesDetected.Clear();
            ICollision collision = null;

            foreach (ICollidable firstEntity in firstEntities)
            {
                collisionTypesDetected.Clear();
                foreach (ICollidable secondEntity in secondEntities)
                {
                    if (firstEntity.GetHitbox().Intersects(secondEntity.GetHitbox()) && !firstEntity.Equals(secondEntity))
                    {
                        collision = new CollisionObject(firstEntity, secondEntity);
                        if (!collisionTypesDetected.Contains(collision.FirstEntityRelativePosition.ToString()))
                        {
                            collisionHandler.HandleCollision(collision);
                            collisionTypesDetected.Add(collision.FirstEntityRelativePosition.ToString());
                        }
                    }
                }
            }
        }
    }
}
