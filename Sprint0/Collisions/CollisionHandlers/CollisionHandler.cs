using Microsoft.Xna.Framework;
using Sprint0.Collisions.Collisions;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Collisions.CollisionHandlers
{
    class CollisionHandler : ICollisionHandler
    {
        public void HandleCollision(ICollision collision)
        {
            if (collision is MarioAndBlockCollision)
            {
                IMario firstEntity = (IMario)collision.GetFirstEntity();
                IBlock secondEntity = (IBlock)collision.GetSecondEntity();

                switch (collision.GetFirstEntityRelativePosition())
                {
                    case CollisionConstants.Direction.Down:
                        secondEntity.Activate();
                        firstEntity.SetLocation(new Vector2(firstEntity.GetLocation().X, firstEntity.GetLocation().Y + collision.GetOverlap().Height));
                        break;
                    case CollisionConstants.Direction.Up:
                        firstEntity.SetLocation(new Vector2(firstEntity.GetLocation().X, firstEntity.GetLocation().Y - collision.GetOverlap().Height));
                        break;
                    case CollisionConstants.Direction.Left:
                        firstEntity.SetLocation(new Vector2(firstEntity.GetLocation().X - collision.GetOverlap().Width, firstEntity.GetLocation().Y));
                        break;
                    case CollisionConstants.Direction.Right:
                        firstEntity.SetLocation(new Vector2(firstEntity.GetLocation().X + collision.GetOverlap().Width, firstEntity.GetLocation().Y));
                        break;
                }

            }
            else if (collision is MarioAndEnemyCollision)
            {
                IMario firstEntity = (IMario)collision.GetFirstEntity();
                IEnemy secondEntity = (IEnemy)collision.GetSecondEntity();

                switch (collision.GetFirstEntityRelativePosition())
                {
                    case CollisionConstants.Direction.Down:
                        firstEntity.TakeDamage();
                        break;
                    case CollisionConstants.Direction.Up:
                        firstEntity.SetLocation(new Vector2(firstEntity.GetLocation().X, firstEntity.GetLocation().Y - collision.GetOverlap().Height));
                        Level.PlayerLevel.Instance.enemyArray.Remove(secondEntity);
                        secondEntity.TakeDamage();
                        break;
                    case CollisionConstants.Direction.Left:
                        firstEntity.TakeDamage();
                        break;
                    case CollisionConstants.Direction.Right:
                        firstEntity.TakeDamage();
                        break;
                }

            }
            else if (collision is MarioAndItemCollision)
            {
                IMario firstEntity = (IMario)collision.GetFirstEntity();
                IItem secondEntity = (IItem)collision.GetSecondEntity();
                firstEntity.PowerUp();

            }
        }
    }
}
