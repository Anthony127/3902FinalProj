using Microsoft.Xna.Framework;
using SuperPixelBrosGame;
using SuperPixelBrosGame.Collisions.Collisions;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.States.Mario.Condition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sprint0.Commands.CollisionCommands.GenericCollisions.PlayerWithItem
{
    class GenericPlayerWithItemCollisionResponse : ICommand
    {
        private IItem secondEntity;

        public GenericPlayerWithItemCollisionResponse(ICollision collision)
        {
            secondEntity = (IItem)collision.SecondEntity;
        }

        public void Execute()
        {
            SuperPixelBrosGame.Level.PlayerLevel.Instance.itemArray.Remove(secondEntity);
        }
    }
}
