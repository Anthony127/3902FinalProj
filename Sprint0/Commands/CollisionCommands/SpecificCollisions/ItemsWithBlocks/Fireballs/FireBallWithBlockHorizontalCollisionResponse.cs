using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using SuperPixelBrosGame;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.States.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Commands.CollisionCommands.SpecificCollisions.ItemsWithBlocks.Fireballs
{
    class FireBallWithBlockHorizontalCollisionResponse : ICommand
    {
        private IItem firstEntity;
        private ICollision collision;
        private float HEIGHTBENCHMARK = 1.35f;

        public FireBallWithBlockHorizontalCollisionResponse(ICollision collision)
        {
            this.firstEntity = (IItem)collision.FirstEntity;
            this.collision = collision;
        }

        public void Execute()
        {
            if (collision.Overlap.Height > HEIGHTBENCHMARK * collision.Overlap.Width)
            {
                IPhysics firstEntityPhysics = (IPhysics)firstEntity;
                firstEntityPhysics.Velocity = new Vector2(0, 0);
                firstEntity.Id = "FIEX";
            }
        }
    }
}
