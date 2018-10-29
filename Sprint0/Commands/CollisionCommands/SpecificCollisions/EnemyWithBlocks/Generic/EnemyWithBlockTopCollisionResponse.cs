using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using SuperPixelBrosGame;
using SuperPixelBrosGame.Collisions.Collisions;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.States.Blocks;
using SuperPixelBrosGame.States.Mario.Condition;
using SuperPixelBrosGame.States.Mario.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Commands.CollisionCommands.SpecificCollisions.EnemyWithBlocks.Generic
{
    class EnemyWithBlockTopCollisionResponse : ICommand
    {
        private IEnemy firstEntity;
        private IBlock secondEntity;
        private ICollision collision;

        public EnemyWithBlockTopCollisionResponse(ICollision collision)
        {
            firstEntity = (IEnemy)collision.FirstEntity;
            secondEntity = (IBlock)collision.SecondEntity;
            this.collision = collision;
        }

        public void Execute()
        {
            firstEntity.Location = new Vector2(firstEntity.Location.X, firstEntity.Location.Y - collision.Overlap.Height);
            IPhysics physicsFirstEntity = (IPhysics)firstEntity;
            physicsFirstEntity.Velocity = new Vector2(physicsFirstEntity.Velocity.X, 0);
            if (secondEntity.BumpState is BumpedBlockState)
            {
                firstEntity.PopOff();
            }

        }
    }
}
