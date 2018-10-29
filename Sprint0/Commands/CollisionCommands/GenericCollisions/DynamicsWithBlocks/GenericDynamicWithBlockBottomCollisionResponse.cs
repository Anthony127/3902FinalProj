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
    class GenericDynamicWithBlockBottomCollisionResponse : ICommand
    {
        private ICollidable firstEntity;
        private IBlock secondEntity;
        private ICollision collision;

        public GenericDynamicWithBlockBottomCollisionResponse(ICollision collision)
        {
            firstEntity = collision.FirstEntity;
            secondEntity = (IBlock)collision.SecondEntity;
            this.collision = collision;
        }

        public void Execute()
        {
            firstEntity.SetLocation(new Vector2(firstEntity.GetLocation().X, firstEntity.GetLocation().Y + collision.Overlap.Height));
            IPhysics firstEntityPhysics = (IPhysics)firstEntity;
            PhysicsHandler.SetYVelocity(firstEntityPhysics, 0);
            secondEntity.Bump();
        }
    }
}