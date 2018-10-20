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
    class GenericDynamicWithBlockTopCollisionResponse : ICommand
    {
        private IMario firstEntity;
        private ICollision collision;

        public GenericDynamicWithBlockTopCollisionResponse(ICollision collision)
        {
            firstEntity = (IMario)collision.FirstEntity;
            this.collision = collision;
        }

        public void Execute()
        {
            firstEntity.SetLocation(new Vector2(firstEntity.GetLocation().X, firstEntity.GetLocation().Y - collision.Overlap.Height));
        }
    }
}