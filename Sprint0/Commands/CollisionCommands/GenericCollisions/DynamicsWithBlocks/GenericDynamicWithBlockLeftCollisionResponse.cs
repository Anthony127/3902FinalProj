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
    class GenericDynamicWithBlockLeftCollisionResponse : ICommand
    {
        private IMario firstEntity;
        private IBlock secondEntity;
        private ICollision collision;

        public GenericDynamicWithBlockLeftCollisionResponse(ICollision collision)
        {
            firstEntity = (IMario)collision.FirstEntity;
            secondEntity = (IBlock)collision.SecondEntity;
            this.collision = collision;
        }

        public void Execute()
        {
            firstEntity.SetLocation(new Vector2(firstEntity.GetLocation().X - collision.Overlap.Width, firstEntity.GetLocation().Y));
        }
    }
}