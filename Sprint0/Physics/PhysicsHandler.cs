using Microsoft.Xna.Framework;
using Sprint0.Commands.CollisionCommands.GenericCollisions.PlayerWithItem;
using Sprint0.Commands.CollisionCommands.SpecificCollisions.PlayerWithBlocks.BrickBlock;
using Sprint0.Commands.CollisionCommands.SpecificCollisions.PlayerWithBlocks.HiddenBlock;
using Sprint0.Commands.CollisionCommands.SpecificCollisions.PlayerWithBlocks.ItemBlock;
using Sprint0.Commands.CollisionCommands.SpecificCollisions.PlayerWithItems;
using Sprint0.Interfaces;
using SuperPixelBrosGame.Collisions.Collisions;
using SuperPixelBrosGame.Commands.CollisionCommands;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.MasterClasses;
using SuperPixelBrosGame.States.Mario.Condition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SuperPixelBrosGame.Physics.PhysicsHandler
{
    abstract class PhysicsHandler
    {
        private const float GRAVITY = 0.3f;
        private const int JUMP = 7;

        public static void UpdatePhysics(IPhysics target)
        {
            PhysicsHandler.SetXVelocity(target, target.Velocity.X + target.Friction.X);
            PhysicsHandler.SetYVelocity(target, target.Velocity.Y + GRAVITY);
            PhysicsHandler.SetXLocation(target, target.Location.X + target.Velocity.X);
            PhysicsHandler.SetYLocation(target, target.Location.Y + target.Velocity.Y);
        }

        public static void SetXVelocity(IPhysics target, float velocity)
        {
            target.Velocity = new Vector2(velocity, target.Velocity.Y);
        }

        public static void SetYVelocity(IPhysics target, float velocity)
        {
            target.Velocity = new Vector2(target.Velocity.X, velocity);
        }

        public static void SetXLocation(IPhysics target, float location)
        {
            target.Location = new Vector2(location, target.Location.Y);
        }

        public static void SetYLocation(IPhysics target, float location)
        {
            target.Location = new Vector2(target.Location.X, location);
        }
    }
}
