using Microsoft.Xna.Framework;
using SuperPixelBrosGame.Collisions.Collisions;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.States.Blocks;
using SuperPixelBrosGame.States.Mario.Condition;
using SuperPixelBrosGame.States.Mario.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPixelBrosGame.Commands.CollisionCommands
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
            if (secondEntity.GetBlockState() is NotActivatedBlockState)
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
                        }
                        else
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
}
