using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using SuperPixelBrosGame;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.States.Blocks;
using SuperPixelBrosGame.States.Mario.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Commands.CollisionCommands.SpecificCollisions.PlayerWithBlocks.HiddenBlock
{
    class MarioWithHiddenBlockTopCollisionResponse : ICommand
    {
        private ICollidable firstEntity;
        private IBlock secondEntity;
        private ICollision collision;

        public MarioWithHiddenBlockTopCollisionResponse(ICollision collision)
        {
            firstEntity = collision.FirstEntity;
            secondEntity = (IBlock)collision.SecondEntity;
            this.collision = collision;
        }

        public void Execute()
        {
            if (secondEntity.GetBlockState() is ActivatedBlockState)
            {
                firstEntity.SetLocation(new Vector2(firstEntity.GetLocation().X, firstEntity.GetLocation().Y - collision.Overlap.Height));
                IPhysics physicsFirstEntity = (IPhysics)firstEntity;
                physicsFirstEntity.Velocity = new Vector2(physicsFirstEntity.Velocity.X, 0);
                if (firstEntity is IMario)
                {
                    IMario player = (IMario)firstEntity;
                    if (player.GetMovementState() is MarioLeftJumpState || player.GetMovementState() is MarioRightJumpState)
                    {
                        player.Idle();
                    }
                }
                
            }
        }
    }
}