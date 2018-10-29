using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using SuperPixelBrosGame;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.States.Mario.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Commands.CollisionCommands.SpecificCollisions.PlayerWithBlocks.ItemBlock
{
    class MarioWithItemBlockBottomCollisionResponse : ICommand
    {
        private IMario firstEntity;
        private IBlock secondEntity;
        private ICollision collision;

        public MarioWithItemBlockBottomCollisionResponse(ICollision collision)
        {
            this.firstEntity = (IMario)collision.FirstEntity;
            this.secondEntity = (IBlock)collision.SecondEntity;
            this.collision = collision;
        }

        public void Execute()
        {
            secondEntity.Bump();
            if (firstEntity.MovementState is MarioLeftJumpState || firstEntity.MovementState is MarioRightJumpState)
            {
                secondEntity.Activate();
            }
            IPhysics firstEntityPhysics = (IPhysics)firstEntity;
            firstEntityPhysics.Velocity = new Vector2(firstEntityPhysics.Velocity.X, 0);
            firstEntity.Location = new Vector2(firstEntity.Location.X, firstEntity.Location.Y + collision.Overlap.Height);
        }
    }
}
