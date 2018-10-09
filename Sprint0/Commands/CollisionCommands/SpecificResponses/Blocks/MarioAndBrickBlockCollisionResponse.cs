using Microsoft.Xna.Framework;
using SuperPixelBrosGame.Collisions.Collisions;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.States.Mario.Condition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPixelBrosGame.Commands.CollisionCommands
{
    class MarioAndBrickBlockCollisionResponse : ICommand
    {
        private IMario firstEntity;
        private IBlock secondEntity;
        private ICollision collision;

        public MarioAndBrickBlockCollisionResponse(ICollision collision)
        {
            this.firstEntity = (IMario)collision.GetFirstEntity();
            this.secondEntity = (IBlock)collision.GetSecondEntity();
            this.collision = collision;
        }

        public void Execute()
        {
            if (!(firstEntity.GetConditionState() is SmallMarioState) && collision.GetFirstEntityRelativePosition() is CollisionConstants.Direction.Down)
            {
                Level.PlayerLevel.Instance.blockArray.Remove(secondEntity);
            }
        }
    }
}
