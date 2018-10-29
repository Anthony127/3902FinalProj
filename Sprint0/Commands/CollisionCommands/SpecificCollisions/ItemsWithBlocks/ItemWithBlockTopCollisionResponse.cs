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
        private IBlock secondEntity;
        private ICollision collision;

        public ItemWithBlockTopCollisionResponse(ICollision collision)
        {
            this.firstEntity = (IItem)collision.FirstEntity;
            this.secondEntity = (IBlock)collision.SecondEntity;
            this.collision = collision;
        }

        public void Execute()
        {
            Console.WriteLine("COLLISION OVERLAP WIDTH: " + collision.Overlap.Width + " HEIGHT: " + collision.Overlap.Height);
            firstEntity.SetLocation(new Vector2(firstEntity.GetLocation().X, firstEntity.GetLocation().Y - collision.Overlap.Height));
            firstEntity.Bounce();
        }
    }
}