using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.States.Mario.Condition;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace SuperPixelBrosGame.States.Mario.Movement
{
    class MarioRightRunState : IMovementState
    {
        private IMario mario;
        private string code = "RRUN";

        public MarioRightRunState(IMario mario)
        {
            mario.SetLocation(new Vector2((int)mario.GetLocation().X + 1, (int)mario.GetLocation().Y));
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
                mario.SetMovementState(new MarioRightCrouchState(mario));
            }
        }

        public void RunRight()
        {
            mario.SetLocation(new Vector2((int)mario.GetLocation().X + 1, (int)mario.GetLocation().Y));
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