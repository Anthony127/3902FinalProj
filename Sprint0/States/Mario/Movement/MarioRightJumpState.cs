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
        private IMario mario;
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
            mario.SetLocation(new Vector2((int)mario.GetLocation().X, (int)mario.GetLocation().Y - 1));
            this.mario = mario;
            mario.SetMovementState(this);
            physicsMario = (IPhysics)mario;
            physicsMario.Velocity = new Vector2(physicsMario.Velocity.X, (float) -10);
            physicsMario.Friction = new Vector2(0, 0);
            mario.UpdateSprite();
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
