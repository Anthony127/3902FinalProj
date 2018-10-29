using Microsoft.Xna.Framework;
using SuperPixelBrosGame;
using SuperPixelBrosGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sprint0.Commands.CollisionCommands.GenericCollisions.EnemyWithEnemy
{
    class GenericEnemyWithEnemyTopCollisionResponse : ICommand
    {
        private IEnemy firstEntity;
        private IEnemy secondEntity;
        private ICollision collision;

        public GenericEnemyWithEnemyTopCollisionResponse(ICollision collision)
        {
            firstEntity = (IEnemy)collision.FirstEntity;
            secondEntity = (IEnemy)collision.SecondEntity;
            this.collision = collision;
        }

        public void Execute()
        {
            firstEntity.Location = new Vector2(firstEntity.Location.X, firstEntity.Location.Y - collision.Overlap.Height);
            secondEntity.TakeDamage();
        }
    }
}
