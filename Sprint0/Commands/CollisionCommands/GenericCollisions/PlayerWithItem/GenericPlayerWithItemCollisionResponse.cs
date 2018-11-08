using Microsoft.Xna.Framework;
using SuperPixelBrosGame;
using SuperPixelBrosGame.Collisions.Collisions;
using SuperPixelBrosGame.HUDComponents;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.MasterClasses;
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
        private readonly IItem secondEntity;

        public GenericPlayerWithItemCollisionResponse(ICollision collision)
        {
            secondEntity = (IItem)collision.SecondEntity;
        }

        public void Execute()
        {
            ScoreKeeper.Instance.IncreaseScore();
            SuperPixelBrosGame.Level.PlayerLevel.Instance.ItemArray.Remove(secondEntity);
            if (secondEntity is Coin)
            {
                ScoreKeeper.Instance.IncrementCoins();
                SoundFactory.Instance.PlaySoundEffect("SOUND_COIN");
            }
            else if (secondEntity is OneUpMushroom)
            {
                SoundFactory.Instance.PlaySoundEffect("SOUND_1UP");
            }

        }
    }
}
