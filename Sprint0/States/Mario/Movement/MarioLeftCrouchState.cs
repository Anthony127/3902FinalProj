using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.States.Mario.Condition;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Diagnostics;
using Sprint0.States.BaseStates;

namespace SuperPixelBrosGame.States.Mario.Movement
{
    class MarioLeftCrouchState : MovementState, IMovementState
    {
        private IMario mario;
        public override string MovementCode
        {
            get
            {
                return "LCRH";
            }
        }

        public MarioLeftCrouchState(IMario mario)
        {
            this.mario = mario;
            mario.MovementState = this;
            mario.UpdateSprite();
        }

        public override void Jump()
        {
            mario.MovementState = new MarioLeftIdleState(mario);
        }

        public override void RunRight()
        {
            mario.MovementState = new MarioRightCrouchState(mario);
        }
    }
}
