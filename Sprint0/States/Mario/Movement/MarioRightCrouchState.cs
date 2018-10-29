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
            this.mario = mario;
            mario.MovementState = this;
            mario.UpdateSprite();
        }

        public override void Jump()
        {
            mario.MovementState = new MarioRightIdleState(mario);
        }

        public override void RunLeft()
        {
            mario.MovementState = new MarioLeftCrouchState(mario);
        }
    }
}