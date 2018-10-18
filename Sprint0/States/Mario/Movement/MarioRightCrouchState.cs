using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.States.Mario.Condition;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Diagnostics;
using Sprint0.States.BaseStates;

namespace SuperPixelBrosGame.States.Mario.Movement
{
    class MarioRightCrouchState : MovementState, IMovementState
    {
        private IMario mario;
        public override string MovementCode
        {
            get
            {
                return "RCRH";
            }
        }

        public MarioRightCrouchState(IMario mario)
        {

            mario.SetLocation(new Vector2((int)mario.GetLocation().X, (int)mario.GetLocation().Y + 1));
            this.mario = mario;
        }

        public override void Jump()
        {
            mario.SetMovementState(new MarioRightIdleState(mario));
        }

        public override void Crouch()
        {
            mario.SetLocation(new Vector2((int)mario.GetLocation().X, (int)mario.GetLocation().Y + 1));
        }

        public override void RunRight()
        {
            mario.SetLocation(new Vector2((int)mario.GetLocation().X + 1, (int)mario.GetLocation().Y));
        }

        public override void RunLeft()
        {
            mario.SetMovementState(new MarioLeftCrouchState(mario));
        }
    }
}