using Microsoft.Xna.Framework;
using Sprint0.Collisions.Collisions;
using Sprint0.Interfaces;
using Sprint0.States.Enemies;
using Sprint0.States.Mario.Condition;
using Sprint0.States.Mario.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Commands.CollisionCommands
{
    class MarioAndGoombaCollisionResponse : ICommand
    {
        private IMario firstEntity;
        private IEnemy secondEntity;
        private ICollision collision;

        public MarioAndGoombaCollisionResponse(ICollision collision)
        {
            this.firstEntity = (IMario)collision.GetFirstEntity();
            this.secondEntity = (IEnemy)collision.GetSecondEntity();
            this.collision = collision;
        }

        public void Execute()
        {
            if (collision.GetFirstEntityRelativePosition() is CollisionConstants.Direction.Up && !(secondEntity.GetConditionState() is EnemyDefeatedState))
            {
                firstEntity.SetLocation(new Vector2(firstEntity.GetLocation().X, firstEntity.GetLocation().Y - collision.GetOverlap().Height));
                secondEntity.TakeDamage();
            }
            else if (!(secondEntity.GetConditionState() is EnemyDefeatedState))
            {
                firstEntity.TakeDamage();
            }
        }
    }
}