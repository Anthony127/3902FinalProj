using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using SuperPixelBrosGame.Collisions.Collisions;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.Physics.PhysicsHandler;
using SuperPixelBrosGame.States.Mario.Condition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPixelBrosGame.Commands.CollisionCommands
{
    class GenericDynamicWithBlockRightCollisionResponse : ICommand
    {
        private ICollidable firstEntity;
        private ICollision collision;

        public GenericDynamicWithBlockRightCollisionResponse(ICollision collision)
        {
            firstEntity = collision.FirstEntity;
            this.collision = collision;
        }

        public void Execute()
        {
            firstEntity.Location = new Vector2(firstEntity.Location.X + collision.Overlap.Width, firstEntity.Location.Y);
            IPhysics firstEntityPhysics = (IPhysics)firstEntity;
            firstEntityPhysics.Velocity = new Vector2(0, firstEntityPhysics.Velocity.Y);
        }
    }
}