using Microsoft.Xna.Framework;
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
    class KoopaWithBlockLeftCollisionResponse : ICommand
    {
        private IEnemy firstEntity;
        private IBlock secondEntity;
        private ICollision collision;

        public KoopaWithBlockLeftCollisionResponse(ICollision collision)
        {
            this.firstEntity = (IEnemy)collision.FirstEntity;
            this.secondEntity = (IBlock)collision.SecondEntity;
            this.collision = collision;
        }

        public void Execute()
        {
            if (firstEntity.ConditionState is EnemyDefeatedState)
            {
                secondEntity.Activate();
            }
            firstEntity.Location = new Vector2(firstEntity.Location.X - collision.Overlap.Width, firstEntity.Location.Y);
            firstEntity.RunRight();

        }
    }
}
