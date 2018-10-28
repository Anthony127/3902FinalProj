using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.States.Mario.Condition;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Diagnostics;
using Sprint0.States.BaseStates;
using Sprint0.Interfaces;

namespace SuperPixelBrosGame.States.Mario.Movement
{
    class MarioRightRunState : MovementState, IMovementState
    {
        private IMario mario;
        private IPhysics physicsMario;

        public override string MovementCode
        {
            get
            {
                return "RRUN";
            }
        }

        public MarioRightRunState(IMario mario)
        {
            this.mario = mario;
            mario.SetMovementState(this);
            physicsMario = (IPhysics)mario;
            physicsMario.Velocity = new Vector2(1, physicsMario.Velocity.Y);
            physicsMario.Friction = new Vector2((float) -.3, 0);
            mario.UpdateSprite();
        }

        public override void Jump()
        {
            mario.SetMovementState(new MarioRightJumpState(mario));
        }

        public override void Crouch()
        {
            if (!(mario.GetConditionState() is SmallMarioState))
            {
                mario.SetMovementState(new MarioRightCrouchState(mario));
            }
        }

        public override void RunRight()
        {
            if (physicsMario.Velocity.X < 2)
            {
                physicsMario.Velocity = new Vector2(physicsMario.Velocity.X + (float).4, physicsMario.Velocity.Y);
            }
        }

        public override void RunLeft()
        {
            physicsMario.Velocity = new Vector2(physicsMario.Velocity.X - (float).1, physicsMario.Velocity.Y);
        }
    }
}