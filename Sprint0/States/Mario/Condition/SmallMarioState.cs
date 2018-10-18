using Microsoft.Xna.Framework;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.States.Mario.Movement;
using Sprint0.States.BaseStates;

namespace SuperPixelBrosGame.States.Mario.Condition
{
    class SmallMarioState : ConditionState, IConditionState
    {
        private IMario mario;
        public override string ConditionCode
        {
            get
            {
                return "SMLL";
            }
        }

        public SmallMarioState(IMario mario)
        {
            this.mario = mario;
            
        }
        public override void PowerUp()
        {
            mario.SetConditionState(new LargeMarioState(mario));
        }

        public override void TakeDamage()
        {
            mario.SetConditionState(new DeadMarioState(mario));
            mario.SetMovementState(new MarioDeadMoveState(mario));
        }
    }
}
