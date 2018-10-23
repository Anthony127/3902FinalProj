using SuperPixelBrosGame;
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
        private IItem firstEntity;
        private IEnemy secondEntity;

        public FireBallWithEnemyCollisionResponse(ICollision collision)
        {
            firstEntity = (IItem)collision.FirstEntity;
            secondEntity = (IEnemy)collision.SecondEntity;
        }

        public void Execute()
        {
            secondEntity.PopOff();
            PlayerLevel.Instance.despawnList.Add((ICollidable)firstEntity);
        }
    }
}
