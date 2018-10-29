using Microsoft.Xna.Framework;
using SuperPixelBrosGame;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.States.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Commands.CollisionCommands.SpecificCollisions.PlayerWithBlocks.HiddenBlock
{
    class MarioWithHiddenBlockLeftCollisionResponse : ICommand
    {
        private ICollidable firstEntity;
        private IBlock secondEntity;
        private ICollision collision;

        public MarioWithHiddenBlockLeftCollisionResponse(ICollision collision)
        {
            firstEntity = collision.FirstEntity;
            secondEntity = (IBlock)collision.SecondEntity;
            this.collision = collision;
        }

        public void Execute()
        {
            if (secondEntity.BlockState is ActivatedBlockState)
            {
                firstEntity.Location = new Vector2(firstEntity.Location.X - collision.Overlap.Width, firstEntity.Location.Y);
            }
        }
    }
}
