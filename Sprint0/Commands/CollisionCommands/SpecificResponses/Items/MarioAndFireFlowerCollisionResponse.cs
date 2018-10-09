﻿using Microsoft.Xna.Framework;
using SuperPixelBrosGame.Collisions.Collisions;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.States.Enemies;
using SuperPixelBrosGame.States.Mario.Condition;
using SuperPixelBrosGame.States.Mario.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPixelBrosGame.Commands.CollisionCommands
{
    class MarioAndFireFlowerCollisionResponse : ICommand
    {
        private IMario firstEntity;
        private IItem secondEntity;
        private ICollision collision;

        public MarioAndFireFlowerCollisionResponse(ICollision collision)
        {
            this.firstEntity = (IMario)collision.GetFirstEntity();
            this.secondEntity = (IItem)collision.GetSecondEntity();
            this.collision = collision;
        }

        public void Execute()
        {
            firstEntity.PowerUp();
        }
    }
}
