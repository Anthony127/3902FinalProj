using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using SuperPixelBrosGame;
using SuperPixelBrosGame.HUDComponents;
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
    class MarioWithKoopaLeftCollisionResponse : ICommand
    {
        private IMario firstEntity;
        private IEnemy secondEntity;

        public MarioWithKoopaLeftCollisionResponse(ICollision collision)
        {
            firstEntity = (IMario)collision.FirstEntity;
            secondEntity = (IEnemy)collision.SecondEntity;
        }

        public void Execute()
        {
            if (firstEntity is StarMario)
            {
                secondEntity.PopOff();
                SoundFactory.Instance.PlaySoundEffect("SOUND_KICK");
                int score = ScoreKeeper.Instance.IncreaseScore();
                PlayerLevel.Instance.ScoreArray.Add(ScoreFactory.Instance.CreateScore(score, secondEntity.Location));
            }
            if (secondEntity.ConditionState is EnemyDefeatedState)
            {
                IPhysics secondEntityPhysics = (IPhysics)secondEntity;
                if (secondEntityPhysics.Velocity.X == 0)
                {
                    SoundFactory.Instance.PlaySoundEffect("SOUND_KICK");
                    secondEntity.RunRight();
                    secondEntityPhysics.Velocity = new Vector2((float)2.5, secondEntityPhysics.Velocity.Y);
                }
                else if (secondEntityPhysics.Velocity.X < 0)
                {
                    firstEntity.TakeDamage();
                }
            }
            else
            {
                firstEntity.TakeDamage();
            }
        }
    }
}
