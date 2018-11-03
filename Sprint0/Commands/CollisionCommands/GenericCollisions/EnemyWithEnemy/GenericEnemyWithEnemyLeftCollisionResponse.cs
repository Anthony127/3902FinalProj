using Microsoft.Xna.Framework;
using SuperPixelBrosGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPixelBrosGame.Commands.CollisionCommands
{
    class GenericEnemyWithEnemyLeftCollisionResponse : ICommand
    {
        private IEnemy firstEntity;
        private ICollision collision;

        public GenericEnemyWithEnemyLeftCollisionResponse(ICollision collision)
        {
            firstEntity = (IEnemy)collision.FirstEntity;
            this.collision = collision;
        }

        public void Execute()
        {
            firstEntity.Location = new Vector2(firstEntity.Location.X - collision.Overlap.Width, firstEntity.Location.Y);
            //collision.FirstEntity.Hitbox = new Rectangle((int)firstEntity.Location.X, (int)firstEntity.Location.Y, collision.FirstEntity.Hitbox.Width, collision.FirstEntity.Hitbox.Height);
            firstEntity.RunLeft();
        }
    }
}
