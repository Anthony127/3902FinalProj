using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.States.Mario.Condition;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Diagnostics;
using Sprint0.States.BaseStates;
using Sprint0.Interfaces;
using SuperPixelBrosGame.Level;

namespace SuperPixelBrosGame.States.Mario.Movement
{
    class MarioFlagState : MovementState, IMovementState
    {
        private IPhysics marioPhysics;
        private IMario mario;
        public override string MovementCode
        {
            get
            {
                return "FLAG";
            }
        }

        public MarioFlagState(IMario mario)
        {
            this.mario = mario;
            mario.MovementState = this;
            marioPhysics = (IPhysics)mario;
            marioPhysics.Velocity = new Vector2(0, 1);
            marioPhysics.Friction = new Vector2(0, 0);
            mario.UpdateSprite();

        }

        public override void Jump()
        {
            marioPhysics.Velocity = new Vector2(4, marioPhysics.Velocity.Y);
            mario.MovementState = new MarioRightJumpState(mario);
        }
    }
}