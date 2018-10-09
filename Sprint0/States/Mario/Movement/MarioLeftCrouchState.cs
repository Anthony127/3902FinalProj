using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.States.Mario.Condition;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace SuperPixelBrosGame.States.Mario.Movement
{
    class MarioLeftCrouchState : IMovementState
    {
        private IMario mario;
        private string code = "LCRH";

        public MarioLeftCrouchState(IMario mario)
        {

            mario.SetLocation(new Vector2((int)mario.GetLocation().X, (int)mario.GetLocation().Y + 1));
            this.mario = mario;
        }

        public void Jump()
        {
            mario.SetMovementState(new MarioLeftIdleState(mario));
        }

        public void Crouch()
        {
            mario.SetLocation(new Vector2((int)mario.GetLocation().X, (int)mario.GetLocation().Y + 1));
        }

        public void RunRight()
        {
            mario.SetMovementState(new MarioRightCrouchState(mario));
        }

        public void RunLeft()
        {
            mario.SetLocation(new Vector2((int)mario.GetLocation().X - 1, (int)mario.GetLocation().Y));
        }

        public string GetMovementCode()
        {
            return code;
        }
    }
}
