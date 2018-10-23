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
        private IBlock secondEntity;
        private ICollision collision;

        public EnemyWithBlockLeftCollisionResponse(ICollision collision)
        {
            firstEntity = (IEnemy)collision.FirstEntity;
            secondEntity = (IBlock)collision.SecondEntity;
            this.collision = collision;
        }

        public void Execute()
        {
            firstEntity.SetLocation(new Vector2(firstEntity.GetLocation().X - collision.Overlap.Width, firstEntity.GetLocation().Y));
            firstEntity.RunLeft();
        }
    }
}
