using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.States.Mario.Condition;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Diagnostics;
using Sprint0.States.BaseStates;
using Sprint0.Interfaces;

namespace SuperPixelBrosGame.States.Mario.Movement
{
    class MarioRightJumpState : MovementState, IMovementState
    {
        private IPhysics physicsMario;

        public override string MovementCode
        {
            get
            {
                return "RJMP";
            }
        }

        public MarioRightJumpState(IMario mario)
        {
            mario.Location = new Vector2((int)mario.Location.X, (int)mario.Location.Y - 1);
            mario.MovementState = this;
            physicsMario = (IPhysics)mario;
            physicsMario.Velocity = new Vector2(physicsMario.Velocity.X, (float) -7);
            physicsMario.Friction = new Vector2(0, 0);
            mario.UpdateSprite();
        }
        public override void Jump()
        {
            if (physicsMario.Velocity.Y < 0)
            {
                physicsMario.Velocity = new Vector2(physicsMario.Velocity.X, physicsMario.Velocity.Y - (float).15);
            }
        }

        public override void RunRight()
        {
            physicsMario.Velocity = new Vector2(physicsMario.Velocity.X + (float).05, physicsMario.Velocity.Y);
        }

        public override void RunLeft()
        {
            physicsMario.Velocity = new Vector2(physicsMario.Velocity.X - (float).05, physicsMario.Velocity.Y);
        }
    }
}
