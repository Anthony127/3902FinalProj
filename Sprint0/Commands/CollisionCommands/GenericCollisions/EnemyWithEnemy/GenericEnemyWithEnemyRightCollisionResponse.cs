using Microsoft.Xna.Framework;
using SuperPixelBrosGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPixelBrosGame.Commands.CollisionCommands
{
    class GenericEnemyWithEnemyRightCollisionResponse : ICommand
    {
        private IEnemy firstEntity;
        private ICollision collision;

        public GenericEnemyWithEnemyRightCollisionResponse(ICollision collision)
        {
            firstEntity = (IEnemy)collision.FirstEntity;
            this.collision = collision;
        }

        public void Execute()
        {
            firstEntity.SetLocation(new Vector2(firstEntity.GetLocation().X + collision.Overlap.Width, firstEntity.GetLocation().Y));
            firstEntity.RunLeft();
        }
    }
}
