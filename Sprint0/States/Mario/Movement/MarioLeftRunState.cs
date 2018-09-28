using Sprint0.Interfaces;
using Sprint0.States.Mario.Condition;

namespace Sprint0.States.Mario.Movement
{
    class MarioLeftRunState : IMovementState
    {
        private IMario mario;
        private string code = "LRUN";

        public MarioLeftRunState(IMario mario)
        {
            this.mario = mario;
        }

        public void Jump()
        {
            mario.SetMovementState(new MarioLeftJumpState(mario));
        }

        public void Crouch()
        {
            if (!(mario.GetConditionState() is SmallMarioState))
            {
                mario.SetMovementState(new MarioLeftCrouchState(mario));
            }
        }

        public void RunRight()
        {
            mario.SetMovementState(new MarioLeftIdleState(mario));
        }

        public void RunLeft()
        {
            //no-op
        }

        public string GetMovementCode()
        {
            return code;
        }
    }
}

