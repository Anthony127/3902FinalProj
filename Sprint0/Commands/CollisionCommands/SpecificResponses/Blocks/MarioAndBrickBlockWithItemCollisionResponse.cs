using Microsoft.Xna.Framework;
using Sprint0.Collisions.Collisions;
using Sprint0.Interfaces;
using Sprint0.States.Mario.Condition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Commands.CollisionCommands
{
    class MarioAndBrickBlockWithItemCollisionResponse : ICommand
    {
        private IMario firstEntity;
        private IBlock secondEntity;
        private ICollision collision;

        public MarioAndBrickBlockWithItemCollisionResponse(ICollision collision)
        {
            this.firstEntity = (IMario)collision.GetFirstEntity();
            this.secondEntity = (IBlock)collision.GetSecondEntity();
            this.collision = collision;
        }

        public void Execute()
        {
            if (collision.GetFirstEntityRelativePosition() is CollisionConstants.Direction.Down)
            {
                secondEntity.Activate();
            }
        }
    }
}