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
    class GenericPlayerWithEnemyNegativeCollisionResponse : ICommand
    {
        private IMario firstEntity;
        private IEnemy secondEntity;

        public GenericPlayerWithEnemyNegativeCollisionResponse(ICollision collision)
        {
            firstEntity = (IMario)collision.FirstEntity;
            secondEntity = (IEnemy)collision.SecondEntity;
        }

        public void Execute()
        {
            if (!(firstEntity is StarMario))
            {
                firstEntity.TakeDamage();
            }
            else
            {
                PlayerLevel.Instance.enemyArray.Remove(secondEntity);
            }
        }
    }
}