using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
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
    class GenericDynamicWithBlockBottomCollisionResponse : ICommand
    {
        private ICollidable firstEntity;
        private IBlock secondEntity;
        private ICollision collision;

        public GenericDynamicWithBlockBottomCollisionResponse(ICollision collision)
        {
            firstEntity = collision.FirstEntity;
            secondEntity = (IBlock)collision.SecondEntity;
            this.collision = collision;
        }

        public void Execute()
        {
            firstEntity.Location = new Vector2(firstEntity.Location.X, firstEntity.Location.Y + collision.Overlap.Height);
            collision.FirstEntity.Hitbox = new Rectangle((int)firstEntity.Location.X, (int)firstEntity.Location.Y, collision.FirstEntity.Hitbox.Width, collision.FirstEntity.Hitbox.Height);
            IPhysics firstEntityPhysics = (IPhysics)firstEntity;
            firstEntityPhysics.Velocity = new Vector2(firstEntityPhysics.Velocity.X, 0);
            secondEntity.Bump();
            SoundFactory.Instance.PlaySoundEffect("SOUND_BUMP");
        }
    }
}