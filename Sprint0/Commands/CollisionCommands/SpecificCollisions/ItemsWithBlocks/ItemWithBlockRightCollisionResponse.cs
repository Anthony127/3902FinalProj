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

namespace Sprint0.Commands.CollisionCommands.SpecificCollisions.EnemyWithBlocks.Koopa
{
    class ItemWithBlockRightCollisionResponse : ICommand
    {
        private IItem firstEntity;
        private IBlock secondEntity;
        private ICollision collision;

        public ItemWithBlockRightCollisionResponse(ICollision collision)
        {
            this.firstEntity = (IItem)collision.FirstEntity;
            this.secondEntity = (IBlock)collision.SecondEntity;
            this.collision = collision;
        }

        public void Execute()
        {
            if (collision.Overlap.Height > .45 * collision.SecondEntity.GetHitbox().Width)
            {
                firstEntity.SetLocation(new Vector2(firstEntity.GetLocation().X + collision.Overlap.Width, firstEntity.GetLocation().Y));
                IPhysics firstEntityPhysics = (IPhysics)firstEntity;
                firstEntityPhysics.Velocity = new Vector2(-1 * firstEntityPhysics.Velocity.X, firstEntityPhysics.Velocity.Y);
            }
        }
    }
}
