using Microsoft.Xna.Framework;
using SuperPixelBrosGame.Interfaces;
using Sprint0.States.BaseStates;

namespace SuperPixelBrosGame.States.Mario.Condition
{
    class DeadMarioState : ConditionState, IConditionState
    {
        public override string ConditionCode
        {
            get
            {
                return "DEAD";
            }
        }

        public DeadMarioState(IMario mario)
        {
            mario.ConditionState = this;
        }
    }
}
