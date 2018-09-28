using Sprint0.Interfaces;

namespace Sprint0.States.Mario.Movement
{
    class MarioRightCrouchState : IMovementState
    {
        private IMario mario;
        private string code = "RCRH";

        public MarioRightCrouchState(IMario mario)
        {
            this.mario = mario;
        }

        public void Jump()
        {
            mario.SetMovementState(new MarioRightIdleState(mario));
        }

        public void Crouch()
        {
            //no-op
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