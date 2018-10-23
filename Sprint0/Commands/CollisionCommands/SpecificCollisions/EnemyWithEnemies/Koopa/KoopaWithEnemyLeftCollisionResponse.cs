﻿using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using SuperPixelBrosGame;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.Level;
using SuperPixelBrosGame.States.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Commands.CollisionCommands.SpecificCollisions.PlayerWIthEnemies.Koopa
{
    class KoopaWithEnemyLeftCollisionResponse : ICommand
    {
        private IEnemy firstEntity;
        private IEnemy secondEntity;
        private ICollision collision;

        public KoopaWithEnemyLeftCollisionResponse(ICollision collision)
        {
            firstEntity = (IEnemy)collision.FirstEntity;
            secondEntity = (IEnemy)collision.SecondEntity;
            this.collision = collision;
        }

        public void Execute()
        {
            if (firstEntity.GetConditionState() is EnemyDefeatedState)
            {
                IPhysics firstEntityPhysics = (IPhysics)firstEntity;
                if (firstEntityPhysics.Velocity.X != 0)
                {
                    secondEntity.PopOff();
                }
            }
            else
            {
                firstEntity.SetLocation(new Vector2(firstEntity.GetLocation().X + collision.Overlap.Width, firstEntity.GetLocation().Y));
                firstEntity.RunRight();
            }
        }
    }
}