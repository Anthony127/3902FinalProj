using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
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
    class ItemWithBlockTopCollisionResponse : ICommand
    {
        private IItem firstEntity;
        private ICollision collision;

        public ItemWithBlockTopCollisionResponse(ICollision collision)
        {
            this.firstEntity = (IItem)collision.FirstEntity;
            this.collision = collision;
        }

        public void Execute()
        {
            firstEntity.Location = new Vector2(firstEntity.Location.X, firstEntity.Location.Y - collision.Overlap.Height);
            firstEntity.Bounce();
        }
    }
}