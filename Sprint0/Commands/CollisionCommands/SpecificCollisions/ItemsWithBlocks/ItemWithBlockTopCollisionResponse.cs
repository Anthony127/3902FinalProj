﻿using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using SuperPixelBrosGame;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.States.Blocks;
using SuperPixelBrosGame.States.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Commands.CollisionCommands.SpecificCollisions.ItemsWithBlocks
{
    class ItemWithBlockTopCollisionResponse : ICommand
    {
        private IItem firstEntity;
        private IBlock secondEntity;
        private ICollision collision;

        public ItemWithBlockTopCollisionResponse(ICollision collision)
        {
            firstEntity = (IItem)collision.FirstEntity;
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
                IPhysics firstEntityPhysics = (IPhysics)firstEntity;
                firstEntityPhysics.Velocity = (new Vector2(-1 * firstEntityPhysics.Velocity.X, -3));
            }
        }
    }
}
