﻿using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using SuperPixelBrosGame;
using SuperPixelBrosGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Commands.CollisionCommands.GenericCollisions.EnemyWithBlock
{
    class EnemyWithBlockLeftCollisionResponse : ICommand
    {
        private IEnemy firstEntity;
        private ICollision collision;

        public EnemyWithBlockLeftCollisionResponse(ICollision collision)
        {
            firstEntity = (IEnemy)collision.FirstEntity;
            this.collision = collision;
        }

        public void Execute()
        {
            firstEntity.Location = new Vector2(firstEntity.Location.X - collision.Overlap.Width, firstEntity.Location.Y);
            firstEntity.RunLeft();
        }
    }
}
