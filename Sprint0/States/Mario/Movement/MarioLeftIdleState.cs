using Sprint0.Interfaces;
using Sprint0.States.Mario.Condition;

namespace Sprint0.States.Mario.Movement
{
    class MarioLeftIdleState : IMovementState
    {
        private IMario mario;
        private string code = "LIDL";

        public MarioLeftIdleState(IMario mario)
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
            mario.SetMovementState(new MarioRightIdleState(mario));
        }

        public void RunLeft()
        {
            mario.SetMovementState(new MarioLeftRunState(mario));
        }

        public string GetMovementCode()
        {
            return code;
        }
    }
}
