using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.States.Mario.Condition;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Diagnostics;
using Sprint0.States.BaseStates;
using Sprint0.Interfaces;

namespace SuperPixelBrosGame.States.Mario.Movement
{
    class MarioLeftJumpState : MovementState, IMovementState
    {
        private IMario mario;
        private IPhysics physicsMario;
        public override string MovementCode
        {
            get
            {
                return "LJMP";
            }
        }

        public MarioLeftJumpState(IMario mario)
        {
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
