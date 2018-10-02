using Sprint0.Interfaces;
using Sprint0.States.Mario.Condition;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace Sprint0.States.Mario.Movement
{
    class MarioRightRunState : IMovementState
    {
        private IMario mario;
        private string code = "RRUN";

        public MarioRightRunState(IMario mario)
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
            //no-op
        }

        public void RunLeft()
        {
            mario.SetMovementState(new MarioRightIdleState(mario));
        }

        public string GetMovementCode()
        {
            return code;
        }
    }
}