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
        private ICollidable firstEntity;
        private ICollision collision;

        public FireBallWithBlockHorizontalCollisionResponse(ICollision collision)
        {
            this.firstEntity = collision.FirstEntity;
            this.collision = collision;
        }

        public void Execute()
        {
            if (collision.Overlap.Height > .45 * collision.SecondEntity.Hitbox.Width)
            {
                firstEntity.Despawn();
            }
        }
    }
}
