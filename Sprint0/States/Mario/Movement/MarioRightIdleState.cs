using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.States.Mario.Condition;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Diagnostics;
using Sprint0.States.BaseStates;
using Sprint0.Interfaces;

namespace SuperPixelBrosGame.States.Mario.Movement
{
    class MarioRightIdleState : MovementState, IMovementState
    {
        private IMario mario;
        private IPhysics physicsMario;

        public override string MovementCode
        {
            get
            {
                return "RIDL";
            }
        }

        public MarioRightIdleState(IMario mario)
        {
            this.mario = mario;
            physicsMario = (IPhysics)mario;
            physicsMario.Velocity = new Vector2(0, physicsMario.Velocity.Y);
            physicsMario.Friction = new Vector2(0, 0);
            mario.UpdateSprite();
        }

        public override void Jump()
        {
            mario.SetMovementState(new MarioRightJumpState(mario));
        }

        public override void Crouch()
        {
            mario.SetLocation(new Vector2((int)mario.GetLocation().X, (int)mario.GetLocation().Y + 1));
            if (!(mario.GetConditionState() is SmallMarioState))
            {
                mario.SetMovementState(new MarioRightCrouchState(mario));
            }
        }

        public override void RunRight()
        {
            mario.SetMovementState(new MarioRightRunState(mario));
        }

        public override void RunLeft()
        {
            mario.SetMovementState(new MarioLeftIdleState(mario));
        }
    }
}