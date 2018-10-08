using Microsoft.Xna.Framework;
using Sprint0.Collisions.Collisions;
using Sprint0.Interfaces;
using Sprint0.States.Mario.Condition;
using Sprint0.States.Mario.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Commands.CollisionCommands
{
    class MarioAndHiddenBlockCollisionResponse : ICommand
    {
        private IMario firstEntity;
        private IBlock secondEntity;
        private ICollision collision;

        public MarioAndHiddenBlockCollisionResponse(ICollision collision)
        {
            this.firstEntity = (IMario)collision.GetFirstEntity();
            this.secondEntity = (IBlock)collision.GetSecondEntity();
            this.collision = collision;
        }

        public void Execute()
        {
            switch (collision.GetFirstEntityRelativePosition())
            {
                case CollisionConstants.Direction.Up:
                    firstEntity.SetLocation(new Vector2(firstEntity.GetLocation().X, firstEntity.GetLocation().Y + collision.GetOverlap().Height));
                    break;
                case CollisionConstants.Direction.Down:
                    if (firstEntity.GetMovementState() is MarioLeftJumpState || firstEntity.GetMovementState() is MarioRightJumpState)
                    {
                        secondEntity.Activate();
                    } else
                    {
                        firstEntity.SetLocation(new Vector2(firstEntity.GetLocation().X, firstEntity.GetLocation().Y - collision.GetOverlap().Height));
                    }
                    break;
                case CollisionConstants.Direction.Left:
                    firstEntity.SetLocation(new Vector2(firstEntity.GetLocation().X + collision.GetOverlap().Width, firstEntity.GetLocation().Y));
                    break;
                case CollisionConstants.Direction.Right:
                    firstEntity.SetLocation(new Vector2(firstEntity.GetLocation().X - collision.GetOverlap().Width, firstEntity.GetLocation().Y));
                    break;
            }
        }
    }
}
