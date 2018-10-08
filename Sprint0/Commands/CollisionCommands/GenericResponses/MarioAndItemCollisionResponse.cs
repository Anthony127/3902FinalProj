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
    class MarioAndItemCollisionResponse : ICommand
    {
        private IMario firstEntity;
        private IItem secondEntity;
        private ICollision collision;

        public MarioAndItemCollisionResponse(ICollision collision)
        {
            this.firstEntity = (IMario)collision.GetFirstEntity();
            this.secondEntity = (IItem)collision.GetSecondEntity();
            this.collision = collision;
        }

        public void Execute()
        {
            Level.PlayerLevel.Instance.itemArray.Remove(secondEntity);
        }
    }
}