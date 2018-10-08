using Sprint0.Collisions.Collisions;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Collisions.CollisionDetectors
{
    class CollisionDetector : ICollisionDetector
    {
        public ICollision ScanForCollisions(IMario mario, IList<IEnemy> entities)
        {
            ICollidable firstEntity = (ICollidable)mario;
            foreach (IEnemy enemy in entities)
            {
                ICollidable entity = (ICollidable)enemy;
                if (firstEntity.GetHitbox().Intersects(entity.GetHitbox()))
                {
                    return new CollisionObject(firstEntity, entity);
                }
            }
            return null;
        }

        public ICollision ScanForCollisions(IMario mario, IList<IItem> entities)
        {
            ICollidable firstEntity = (ICollidable)mario;
            foreach (IItem item in entities)
            {
                ICollidable entity = (ICollidable)item;
                if (firstEntity.GetHitbox().Intersects(entity.GetHitbox()))
                {
                    return new CollisionObject(firstEntity, entity);
                }
            }
            return null;
        }

        public ICollision ScanForCollisions(IMario mario, IList<IBlock> entities)
        {
            ICollidable firstEntity = (ICollidable)mario;
            foreach (IBlock block in entities)
            {
                ICollidable entity = (ICollidable)block;
                if (firstEntity.GetHitbox().Intersects(entity.GetHitbox()))
                {
                    return new CollisionObject(firstEntity, entity);
                }
            }
            return null;
        }
    }
}
