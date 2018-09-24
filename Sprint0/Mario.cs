using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    class Mario : IMario
    {
        private static Mario instance = new Mario();

        string marioMovement;
        string marioCondition;
        ISprite marioSprite;

        public static Mario Instance
        {
            get
            {
                return instance;
            }
        }

        public string GetConditionState()
        {
            return marioCondition;
        }

        public string GetMovementState()
        {
            return marioMovement;
        }

        public ISprite GetSprite()
        {
            return marioSprite;
        }

        public void SetConditionState(string condition)
        {
            marioCondition = condition;
        }

        public void SetMovementState(string movement)
        {
            marioMovement = movement;
        }

        public ISprite SetSprite()
        {
                //marioSprite = PlayerSpriteFactory.Instance.GetPlayerSprite(marioMovement,marioCondition);
                //Work in progress for solution to state explosion
            throw new NotImplementedException();
        }
    }
}
