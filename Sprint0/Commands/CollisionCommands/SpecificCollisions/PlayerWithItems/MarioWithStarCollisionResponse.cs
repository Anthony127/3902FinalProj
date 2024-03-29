﻿using Microsoft.Xna.Framework;
using SuperPixelBrosGame;
using SuperPixelBrosGame.Collisions.Collisions;
using SuperPixelBrosGame.HUDComponents;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.States.Enemies;
using SuperPixelBrosGame.States.Mario.Condition;
using SuperPixelBrosGame.States.Mario.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Commands.CollisionCommands.SpecificCollisions.PlayerWithItems
{

    class MarioWithStarCollisionResponse : ICommand
    {
        private readonly IMario firstEntity;
        private readonly IItem secondEntity;

        public MarioWithStarCollisionResponse(ICollision collision)
        {
            this.firstEntity = (IMario)collision.FirstEntity;
            this.secondEntity = (IItem)collision.SecondEntity;
        }

        public void Execute()
        {
            firstEntity.CreateStarMario();
            int score = ScoreKeeper.Instance.IncreaseCustomScore(1000);
            SuperPixelBrosGame.Level.PlayerLevel.Instance.ScoreArray.Add(ScoreFactory.CreateScore(score, secondEntity.Location));
            SuperPixelBrosGame.Level.PlayerLevel.Instance.ItemArray.Remove(secondEntity);
        }
    }
}
