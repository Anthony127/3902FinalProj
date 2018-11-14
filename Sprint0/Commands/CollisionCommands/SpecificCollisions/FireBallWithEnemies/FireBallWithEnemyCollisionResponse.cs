using SuperPixelBrosGame;
using SuperPixelBrosGame.HUDComponents;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.Level;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Commands.CollisionCommands.SpecificCollisions.FireBallWithEnemies
{
    class FireBallWithEnemyCollisionResponse : ICommand
    {
        private readonly IItem firstEntity;
        private readonly IEnemy secondEntity;

        public FireBallWithEnemyCollisionResponse(ICollision collision)
        {
            firstEntity = (IItem)collision.FirstEntity;
            secondEntity = (IEnemy)collision.SecondEntity;
        }

        public void Execute()
        {
            secondEntity.PopOff();
            SoundFactory.Instance.PlaySoundEffect("SOUND_KICK");
            ScoreKeeper.Instance.IncreaseScore();
            PlayerLevel.Instance.DespawnList.Add((ICollidable)firstEntity);
        }
    }
}
