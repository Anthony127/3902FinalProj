using Microsoft.Xna.Framework;
using Sprint0.Collisions.Collisions;
using Sprint0.Interfaces;
using Sprint0.States.Enemies;
using Sprint0.States.Mario.Condition;
using Sprint0.States.Mario.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Commands.CollisionCommands
{
    class MarioAndStarCollisionResponse : ICommand
    {
        private IMario firstEntity;
        private IItem secondEntity;
        private ICollision collision;

        public MarioAndStarCollisionResponse(ICollision collision)
        {
            this.firstEntity = (IMario)collision.GetFirstEntity();
            this.secondEntity = (IItem)collision.GetSecondEntity();
            this.collision = collision;
        }

        public void Execute()
        {
            firstEntity.CreateStarMario();
        }
    }
}
