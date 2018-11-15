using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using SuperPixelBrosGame.Collisions.Collisions;
using SuperPixelBrosGame.HUDComponents;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.Level;
using SuperPixelBrosGame.States.Enemies;
using SuperPixelBrosGame.States.Mario.Condition;
using SuperPixelBrosGame.States.Mario.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPixelBrosGame.Commands.CollisionCommands
{
    class GenericPlayerWithEnemyPositiveCollisionResponse : ICommand
    {
        private IMario firstEntity;
        private IEnemy secondEntity;
        private ICollision collision;

        public GenericPlayerWithEnemyPositiveCollisionResponse(ICollision collision)
        {
            firstEntity = (IMario)collision.FirstEntity;
            secondEntity = (IEnemy)collision.SecondEntity;
            this.collision = collision;
        }

        public void Execute()
        {
            int score = ScoreKeeper.Instance.IncreaseScore();
            PlayerLevel.Instance.ScoreArray.Add(ScoreFactory.CreateScore(score, secondEntity.Location));
            ScoreKeeper.Instance.IncMultiplier();
            
            if (!(secondEntity.ConditionState is EnemyDefeatedState))
            {
                if (!(firstEntity is StarMario))
                {
                    firstEntity.Location = new Vector2(firstEntity.Location.X, firstEntity.Location.Y - collision.Overlap.Height);
                    secondEntity.TakeDamage();
                    firstEntity.Idle();
                    firstEntity.Jump();
                    SoundFactory.Instance.PlaySoundEffect("SOUND_STOMP");
                }
                else
                {
                    secondEntity.PopOff();
                    SoundFactory.Instance.PlaySoundEffect("SOUND_KICK");
                }
            }

        }
    }
}