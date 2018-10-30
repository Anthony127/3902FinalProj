using Microsoft.Xna.Framework;
using SuperPixelBrosGame;
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

namespace Sprint0.Commands.CollisionCommands.SpecificCollisions.PlayerWithItems
{

    class MarioWithFireFlowerCollisionResponse : ICommand
    {
        private readonly IMario firstEntity;
        private readonly IItem secondEntity;

        public MarioWithFireFlowerCollisionResponse(ICollision collision)
        {
            this.firstEntity = (IMario)collision.FirstEntity;
            this.secondEntity = (IItem)collision.SecondEntity;
        }

        public void Execute()
        {
            firstEntity.PowerUp();
            SuperPixelBrosGame.Level.PlayerLevel.Instance.ItemArray.Remove(secondEntity);
        }
    }
}
