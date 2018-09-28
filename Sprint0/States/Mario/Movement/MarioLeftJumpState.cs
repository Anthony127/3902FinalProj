using Sprint0.Interfaces;

namespace Sprint0.States.Mario.Movement
{
    class MarioLeftJumpState : IMovementState
    {
        private IMario mario;
        private string code = "LJMP";

        public MarioLeftJumpState(IMario mario)
        {
            this.mario = mario;
        }

        public void Jump()
        {
            //no-op
        }

        public void Crouch()
        {
            mario.SetMovementState(new MarioLeftIdleState(mario));
        }

        public void RunRight()
        {
            //no-op
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
