using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using System;

namespace Sprint0.Collisions.Collisions
{
    class MarioAndEnemyCollision : ICollision
    {
        private IMario firstEntity;
        private IEnemy secondEntity;
        private Rectangle overlap;

        public MarioAndEnemyCollision(IMario mario, IEnemy enemy)
        {
            firstEntity = mario;
            secondEntity = enemy;
            overlap = Rectangle.Intersect(mario.GetCurrentHitbox(), enemy.GetHitbox());
            System.Console.WriteLine("COLLISION: Width: " + overlap.Width + " Height: " + overlap.Height + "\n");
        }

        public object GetFirstEntity()
        {
            return firstEntity;
        }

        public CollisionConstants.Direction GetFirstEntityRelativePosition()
        {
            Vector2 marioLocation = firstEntity.GetLocation();
            Vector2 enemyLocation = secondEntity.GetLocation();
            bool vertical = true;
            if (overlap.Height > overlap.Width)
            {
                vertical = false;
            }
            if (vertical)
            {
                if (marioLocation.Y > enemyLocation.Y)
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
                if (marioLocation.X < enemyLocation.X)
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
            return "MarioAndEnemyCollision";
        }
    }
}
