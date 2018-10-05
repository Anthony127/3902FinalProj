using Sprint0.Interfaces;
using Sprint0.States.Mario.Condition;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace Sprint0.States.Mario.Movement
{
    class MarioLeftIdleState : IMovementState
    {
        private IMario mario;
        private string code = "LIDL";

        public MarioLeftIdleState(IMario mario)
        {
            this.mario = mario;
            mario.SetCurrentHitboxToStand();
        }

        public void Jump()
        {
            mario.SetMovementState(new MarioLeftJumpState(mario));
        }

        public void Crouch()
        {
            mario.SetLocation(new Vector2((int)mario.GetLocation().X, (int)mario.GetLocation().Y + 1));
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
