using Sprint0.Collisions.Collisions;
using Sprint0.Interfaces;
using Sprint0.States.Mario.Condition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Commands.CollisionCommands
{
    class MarioAndEnemyCollisionResponse : ICommand
    {
        private IMario firstEntity;
        private IEnemy secondEntity;
        private ICollision collision;

        public MarioAndEnemyCollisionResponse(ICollision collision)
        {
            this.firstEntity = (IMario)collision.GetFirstEntity();
            this.secondEntity = (IEnemy)collision.GetSecondEntity();
            this.collision = collision;
        }

        public void Execute()
        {
            if (firstEntity is StarMario)
            {
                Level.PlayerLevel.Instance.enemyArray.Remove(secondEntity);
            }
        }
    }
}
