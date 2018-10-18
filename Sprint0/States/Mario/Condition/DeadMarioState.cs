using Microsoft.Xna.Framework;
using SuperPixelBrosGame.Interfaces;
using Sprint0.States.BaseStates;

namespace SuperPixelBrosGame.States.Mario.Condition
{
    class DeadMarioState : ConditionState, IConditionState
    {
        private IMario mario;
        public override string ConditionCode
        {
            get
            {
                return "DEAD";
            }
        }

        public DeadMarioState(IMario mario)
        {
            this.mario = mario;
        }
    }
}
