using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using SuperPixelBrosGame;
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

namespace Sprint0.Commands.CollisionCommands.SpecificCollisions.PlayerWithBlocks.BrickBlock
{
    class MarioWithBrickBlockBottomCollisionResponse : ICommand
    {
        private IMario firstEntity;
        private IBlock secondEntity;
        private ICollision collision;

        public MarioWithBrickBlockBottomCollisionResponse(ICollision collision)
        {
            this.firstEntity = (IMario)collision.FirstEntity;
            this.secondEntity = (IBlock)collision.SecondEntity;
            this.collision = collision;
        }

        public void Execute()
        {
            secondEntity.Bump();
            if (!(firstEntity.ConditionState is SmallMarioState) && (firstEntity.MovementState is MarioLeftJumpState || firstEntity.MovementState is MarioRightJumpState))
            {
                secondEntity.Activate();
                PlayerLevel.Instance.blockArray.Remove(secondEntity);
            }
            IPhysics firstEntityPhysics = (IPhysics)firstEntity;
            firstEntityPhysics.Velocity = new Vector2(firstEntityPhysics.Velocity.X, 0);
            firstEntity.Location = new Vector2(firstEntity.Location.X, firstEntity.Location.Y + collision.Overlap.Height);
        }
    }
}
