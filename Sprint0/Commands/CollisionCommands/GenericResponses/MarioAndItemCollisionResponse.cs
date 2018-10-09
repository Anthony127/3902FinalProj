using Microsoft.Xna.Framework;
using SuperPixelBrosGame.Collisions.Collisions;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.States.Mario.Condition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPixelBrosGame.Commands.CollisionCommands
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