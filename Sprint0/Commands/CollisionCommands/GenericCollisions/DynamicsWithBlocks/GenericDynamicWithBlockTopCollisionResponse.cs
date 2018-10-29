using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using SuperPixelBrosGame.Collisions.Collisions;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.Physics.PhysicsHandler;
using SuperPixelBrosGame.States.Mario.Condition;
using SuperPixelBrosGame.States.Mario.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPixelBrosGame.Commands.CollisionCommands
{
    class GenericDynamicWithBlockTopCollisionResponse : ICommand
    {
        private ICollidable firstEntity;
        private ICollision collision;

        public GenericDynamicWithBlockTopCollisionResponse(ICollision collision)
        {
            firstEntity = collision.FirstEntity;
            this.collision = collision;
        }

        public void Execute()
        {
            IPhysics physicsFirstEntity = (IPhysics)firstEntity;
            PhysicsHandler.SetYLocation(physicsFirstEntity, firstEntity.GetLocation().Y - collision.Overlap.Height);
            PhysicsHandler.SetYVelocity(physicsFirstEntity, 0);
            if (firstEntity is IMario player)
            {
                if (player.GetMovementState() is MarioLeftJumpState || player.GetMovementState() is MarioRightJumpState)
                {
                    player.Idle();
                }
            }

        }
    }
}