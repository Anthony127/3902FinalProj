using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using SuperPixelBrosGame;
using SuperPixelBrosGame.HUDComponents;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.Level;
using SuperPixelBrosGame.States.Mario.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPixelBrosGame.Commands.CollisionCommands.SpecificCollisions.MarioWithFlag
{
    class MarioWithFlagCollisionResponse : ICommand
    {
        private IMario firstEntity;
        private FlagPole secondEntity;

        public MarioWithFlagCollisionResponse(ICollision collision)
        {
            this.firstEntity = (IMario)collision.FirstEntity;
            this.secondEntity = (FlagPole)collision.SecondEntity;
        }

        public void Execute()
        {
            if (!(PlayerLevel.Instance.Game.GameState is VictoryGameState))
            {
                ScoreKeeper.Instance.ScoreFlag((int)firstEntity.Location.Y);
                firstEntity.MovementState = new MarioFlagState(firstEntity);
                firstEntity.Location = new Vector2(secondEntity.Location.X - (secondEntity.Hitbox.Width / 2), firstEntity.Location.Y);
                PlayerLevel.Instance.VictoryState(firstEntity, secondEntity);
            }
        }
    }
}
