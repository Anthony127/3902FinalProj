﻿using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.States.Mario.Condition;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Diagnostics;
using Sprint0.States.BaseStates;
using Sprint0.Interfaces;

namespace SuperPixelBrosGame.States.Mario.Movement
{
    class MarioLeftIdleState : MovementState, IMovementState
    {
        private IMario mario;
        private IPhysics physicsMario;

        public override string MovementCode
        {
            get
            {
                return "LIDL";
            }
        }

        public MarioLeftIdleState(IMario mario)
        {
            this.mario = mario;
            mario.MovementState = this;
            physicsMario = (IPhysics)mario;
            physicsMario.Velocity = new Vector2(0, physicsMario.Velocity.Y);
            physicsMario.Friction = new Vector2(0, 0);
            mario.UpdateSprite();
        }

        public override void Jump()
        {
            mario.MovementState = new MarioLeftJumpState(mario);
        }

        public override void Crouch()
        {
                mario.MovementState = new MarioLeftCrouchState(mario);
        }

        public override void RunRight()
        {
            mario.MovementState = new MarioRightIdleState(mario);
        }

        public override void RunLeft()
        {
            mario.MovementState = new MarioLeftRunState(mario);
        }
    }
}
