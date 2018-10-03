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
            foreach (IEnemy enemy in entities)
            {
                if (mario.GetHitbox().Intersects(enemy.GetHitbox()))
                {
                    return new MarioAndEnemyCollision(mario, enemy);
                }
            }
            return null;
        }

        public ICollision ScanForCollisions(IMario mario, IList<IItem> entities)
        {
            foreach (IItem item in entities)
            {
                if (mario.GetHitbox().Intersects(item.GetHitbox()))
                {
                    return new MarioAndItemCollision(mario, item);
                }
            }
            return null;
        }

        public ICollision ScanForCollisions(IMario mario, IList<IBlock> entities)
        {
            foreach (IBlock block in entities)
            {
                if (mario.GetHitbox().Intersects(block.GetHitbox()))
                {
                    return new MarioAndBlockCollision(mario, block);
                }
            }
            return null;
        }
    }
}
