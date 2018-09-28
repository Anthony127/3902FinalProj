using Sprint0.Interfaces;
using Sprint0.States.Mario.Condition;

namespace Sprint0.States.Mario.Movement
{
    class MarioRightIdleState : IMovementState
    {
        private IMario mario;
        private string code = "RIDL";

        public MarioRightIdleState(IMario mario)
        {
            this.mario = mario;
        }

        public void Jump()
        {
            mario.SetMovementState(new MarioRightJumpState(mario));
        }

        public void Crouch()
        {
            if (!(mario.GetConditionState() is SmallMarioState))
            {
                mario.SetMovementState(new MarioRightCrouchState(mario));
            }
        }

        public void RunRight()
        {
            mario.SetMovementState(new MarioRightRunState(mario));
        }

        public void RunLeft()
        {
            mario.SetMovementState(new MarioLeftIdleState(mario));
        }

        public string GetMovementCode()
        {
            return code;
        }
    }
}