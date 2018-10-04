using Sprint0.Interfaces;
using Sprint0.States.Mario.Condition;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Diagnostics;

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
            mario.SetLocation(new Vector2((int)mario.GetLocation().X, (int)mario.GetLocation().Y + 1));
            if (!(mario.GetConditionState() is SmallMarioState))
            {
                mario.SetCurrentHitboxToCrouch();
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