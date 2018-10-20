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

    class MarioWithStarCollisionResponse : ICommand
    {
        private IMario firstEntity;
        private IItem secondEntity;
        private ICollision collision;

        public MarioWithStarCollisionResponse(ICollision collision)
        {
            this.firstEntity = (IMario)collision.FirstEntity;
            this.secondEntity = (IItem)collision.SecondEntity;
            this.collision = collision;
        }

        public void Execute()
        {
            firstEntity.CreateStarMario();
            SuperPixelBrosGame.Level.PlayerLevel.Instance.itemArray.Remove(secondEntity);
        }
    }
}
