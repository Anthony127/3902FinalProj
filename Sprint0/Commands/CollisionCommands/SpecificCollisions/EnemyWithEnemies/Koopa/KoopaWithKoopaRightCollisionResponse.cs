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
    class KoopaWithKoopaRightCollisionResponse : ICommand
    {
        private IEnemy firstEntity;
        private IEnemy secondEntity;
        private ICollision collision;
        private float SHELLSPEED = (float)-2.5;

        public KoopaWithKoopaRightCollisionResponse(ICollision collision)
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
                    firstEntity.Location = new Vector2(firstEntity.Location.X - collision.Overlap.Width, firstEntity.Location.Y);
                    firstEntity.RunLeft();
                    if (secondEntityPhysics.Velocity.X == 0)
                    {
                        secondEntityPhysics.Velocity = new Vector2(SHELLSPEED, secondEntityPhysics.Velocity.Y);
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
                firstEntity.Location = new Vector2(firstEntity.Location.X - collision.Overlap.Width, firstEntity.Location.Y);
                firstEntity.RunLeft();
            }
        }
    }
}
