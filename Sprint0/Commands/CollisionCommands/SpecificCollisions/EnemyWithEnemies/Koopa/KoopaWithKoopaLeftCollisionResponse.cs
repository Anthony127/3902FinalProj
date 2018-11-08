using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using SuperPixelBrosGame;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.Level;
using SuperPixelBrosGame.States.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Commands.CollisionCommands.SpecificCollisions.PlayerWIthEnemies.Koopa
{
    class KoopaWithKoopaLeftCollisionResponse : ICommand
    {
        private IEnemy firstEntity;
        private IEnemy secondEntity;
        private ICollision collision;

        public KoopaWithKoopaLeftCollisionResponse(ICollision collision)
        {
            firstEntity = (IEnemy)collision.FirstEntity;
            secondEntity = (IEnemy)collision.SecondEntity;
            this.collision = collision;
        }

        public void Execute()
        {
            if (firstEntity.ConditionState is EnemyDefeatedState)
            {
                IPhysics firstEntityPhysics = (IPhysics)firstEntity;
                IPhysics secondEntityPhysics = (IPhysics)secondEntity;
                if (secondEntity.ConditionState is EnemyDefeatedState)
                {
                    firstEntity.Location = new Vector2(firstEntity.Location.X + collision.Overlap.Width, firstEntity.Location.Y);
                    //collision.FirstEntity.Hitbox = new Rectangle((int)firstEntity.Location.X, (int)firstEntity.Location.Y, collision.FirstEntity.Hitbox.Width, collision.FirstEntity.Hitbox.Height);
                    firstEntity.RunRight();
                    if (secondEntityPhysics.Velocity.X == 0)
                    {
                        secondEntityPhysics.Velocity = new Vector2((float)2.5, secondEntityPhysics.Velocity.Y);
                        SoundFactory.Instance.PlaySoundEffect("SOUND_BUMP");
                    }
                }
                else if (firstEntityPhysics.Velocity.X != 0)
                {
                    secondEntity.PopOff();
                    SoundFactory.Instance.PlaySoundEffect("SOUND_KICK");
                }
            }
            else
            {
                firstEntity.Location = new Vector2(firstEntity.Location.X + collision.Overlap.Width, firstEntity.Location.Y);
                //collision.FirstEntity.Hitbox = new Rectangle((int)firstEntity.Location.X, (int)firstEntity.Location.Y, collision.FirstEntity.Hitbox.Width, collision.FirstEntity.Hitbox.Height);
                firstEntity.RunRight();
            }
        }
    }
}
