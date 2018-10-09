using Microsoft.Xna.Framework;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.States.Mario.Movement;

namespace SuperPixelBrosGame.States.Mario.Condition
{
    class SmallMarioState : IConditionState
    {
        private IMario mario;
        private readonly string code = "SMLL";

        public SmallMarioState(IMario mario)
        {
            this.mario = mario;
            
        }
        public void PowerUp()
        {
            mario.SetConditionState(new LargeMarioState(mario));
        }

        public void TakeDamage()
        {
            mario.SetConditionState(new DeadMarioState(mario));
            mario.SetMovementState(new MarioDeadMoveState(mario));
        }

        public string GetConditionCode()
        {
            return code;
        }
    }
}
