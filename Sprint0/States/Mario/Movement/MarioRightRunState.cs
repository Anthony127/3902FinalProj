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
            //mario.SetLocation(new Vector2((int)mario.GetLocation().X + 1, (int)mario.GetLocation().Y));
            this.mario = mario;
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
            //mario.SetLocation(new Vector2((int)mario.GetLocation().X, (int)mario.GetLocation().Y + 1));
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
            //mario.SetMovementState(new MarioLeftIdleState(mario));
            physicsMario.Velocity = new Vector2(physicsMario.Velocity.X - (float).1, physicsMario.Velocity.Y);
        }
    }
}