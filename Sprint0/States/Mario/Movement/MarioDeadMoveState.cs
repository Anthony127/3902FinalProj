using Sprint0.Interfaces;
using Sprint0.States.Mario.Condition;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace Sprint0.States.Mario.Movement
{
    class MarioDeadMoveState : IMovementState
    {
        private IMario mario;
        private string code = "DEAM";

        public MarioDeadMoveState(IMario mario)
        {
            this.mario = mario;

        }

        public void Jump() { }
        public void Crouch() { }
        public void RunLeft() { }
        public void RunRight() { }


        public string GetMovementCode()
        {
            return code;
        }
    }
}
