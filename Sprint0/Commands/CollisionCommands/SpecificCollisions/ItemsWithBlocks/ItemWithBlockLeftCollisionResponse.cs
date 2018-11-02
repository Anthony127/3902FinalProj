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
    class ItemWithBlockLeftCollisionResponse : ICommand
    {
        private IItem firstEntity;
        private ICollision collision;

        public ItemWithBlockLeftCollisionResponse(ICollision collision)
        {
            this.firstEntity = (IItem)collision.FirstEntity;
            this.collision = collision;
        }

        public void Execute()
        {
            if (collision.Overlap.Height > .45 * collision.SecondEntity.Hitbox.Width)
            {
                firstEntity.Location = new Vector2(firstEntity.Location.X - collision.Overlap.Width, firstEntity.Location.Y);
                collision.FirstEntity.Hitbox = new Rectangle((int)firstEntity.Location.X, (int)firstEntity.Location.Y, collision.FirstEntity.Hitbox.Width, collision.FirstEntity.Hitbox.Height);
                IPhysics firstEntityPhysics = (IPhysics)firstEntity;
                firstEntityPhysics.Velocity = new Vector2(-1 * firstEntityPhysics.Velocity.X, firstEntityPhysics.Velocity.Y);
            }
        }
    }
}