using Microsoft.Xna.Framework;
using SuperPixelBrosGame.Collisions.Collisions;
using SuperPixelBrosGame.Interfaces;
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
            if (collision.GetFirstEntityRelativePosition() is CollisionConstants.Direction.Up && !(secondEntity.GetConditionState() is EnemyDefeatedState) && collision.GetOverlap().Height < 4)
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