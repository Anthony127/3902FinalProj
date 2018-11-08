using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using SuperPixelBrosGame.Collisions.Collisions;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.Level;
using SuperPixelBrosGame.States.Mario.Condition;
using SuperPixelBrosGame.States.Mario.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPixelBrosGame.Commands.CollisionCommands
{
    class MarioWithWarpPipeTopCollisionResponse : ICommand
    {
        private IMario firstEntity;
        private WarpPipe secondEntity;
        private ICollision collision;

        public MarioWithWarpPipeTopCollisionResponse(ICollision collision)
        {
            firstEntity = (IMario)collision.FirstEntity;
            secondEntity = (WarpPipe)collision.SecondEntity;
            this.collision = collision;
        }

        public void Execute()
        {
            firstEntity.Location = new Vector2(firstEntity.Location.X, firstEntity.Location.Y - collision.Overlap.Height);
            collision.FirstEntity.Hitbox = new Rectangle((int)firstEntity.Location.X, (int)firstEntity.Location.Y, collision.FirstEntity.Hitbox.Width, collision.FirstEntity.Hitbox.Height);
            IPhysics physicsFirstEntity = (IPhysics)firstEntity;
            physicsFirstEntity.Velocity = new Vector2(physicsFirstEntity.Velocity.X, 0);
            if (firstEntity is IMario player && (player.MovementState is MarioLeftJumpState || player.MovementState is MarioRightJumpState))
            {
                if (physicsFirstEntity.Velocity.X < 0)
                {
                    player.MovementState = new MarioLeftRunState(player);
                }
                else if (physicsFirstEntity.Velocity.X > 0)
                {
                    player.MovementState = new MarioRightRunState(player);
                }
                else
                {
                    player.Idle();
                }
            }
            if ((firstEntity.MovementState is MarioLeftCrouchState || firstEntity.MovementState is MarioRightCrouchState) && (firstEntity.Location.X > (secondEntity.Location.X + 7)) && (firstEntity.Location.X < (secondEntity.Location.X + secondEntity.Hitbox.Width - 32)))
            {
                WarpPipe pipe = (WarpPipe)collision.SecondEntity;
                PlayerLevel.Instance.Warp(firstEntity, pipe.WarpDestination);
            }
        }
    }
}