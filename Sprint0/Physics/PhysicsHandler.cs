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
    class PhysicsHandler
    {
        private const float GRAVITY = 0.3f;
        private const int JUMP = 7;

        public PhysicsHandler()
        {
        }

        public void UpdatePhysics(IPhysics target)
        {
            target.Velocity = new Vector2(target.Velocity.X + target.Friction.X, target.Velocity.Y + GRAVITY);
            target.Location = new Vector2(target.Location.X + target.Velocity.X, target.Location.Y + target.Velocity.Y);
        }
    }
}
