using Microsoft.Xna.Framework;
using SuperPixelBrosGame.Collisions.Collisions;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.Level;
using SuperPixelBrosGame.States.Enemies;
using SuperPixelBrosGame.States.Mario.Condition;
using SuperPixelBrosGame.States.Mario.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPixelBrosGame.Commands.CollisionCommands
{
    class GenericPlayerWithEnemyPositiveCollisionResponse : ICommand
    {
        private IMario firstEntity;
        private IEnemy secondEntity;
        private ICollision collision;

        public GenericPlayerWithEnemyPositiveCollisionResponse(ICollision collision)
        {
            firstEntity = (IMario)collision.FirstEntity;
            secondEntity = (IEnemy)collision.SecondEntity;
            this.collision = collision;
        }

        public void Execute()
        {
            if (!(firstEntity is StarMario))
            {
                firstEntity.SetLocation(new Vector2(firstEntity.GetLocation().X, firstEntity.GetLocation().Y - collision.Overlap.Height));
                secondEntity.TakeDamage();
            }
            else
            {
                PlayerLevel.Instance.enemyArray.Remove(secondEntity);
            }

        }
    }
}