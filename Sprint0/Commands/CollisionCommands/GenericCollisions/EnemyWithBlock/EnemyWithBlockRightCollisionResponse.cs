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


namespace Sprint0.Commands.CollisionCommands.GenericCollisions.EnemyWithBlock
{
    class EnemyWithBlockRightCollisionResponse : ICommand
    {
        private IEnemy firstEntity;
        private ICollision collision;

        public EnemyWithBlockRightCollisionResponse(ICollision collision)
        {
            firstEntity = (IEnemy)collision.FirstEntity;
            this.collision = collision;
        }

        public void Execute()
        {
            firstEntity.Location = new Vector2(firstEntity.Location.X + collision.Overlap.Width, firstEntity.Location.Y);
            collision.FirstEntity.Hitbox = new Rectangle((int)firstEntity.Location.X, (int)firstEntity.Location.Y, collision.FirstEntity.Hitbox.Width, collision.FirstEntity.Hitbox.Height);
            firstEntity.RunRight();
            if (firstEntity is Koopa && firstEntity.ConditionState is EnemyDefeatedState)
            {
                SoundFactory.Instance.PlaySoundEffect("SOUND_BUMP");
            }
        }
    }
}
