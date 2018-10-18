﻿using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.States.Mario.Condition;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Diagnostics;
using Sprint0.States.BaseStates;

namespace SuperPixelBrosGame.States.Mario.Movement
{
    class MarioLeftIdleState : MovementState, IMovementState
    {
        private IMario mario;
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

        }

        public override void Jump()
        {
            mario.SetMovementState(new MarioLeftJumpState(mario));
        }

        public override void Crouch()
        {
            mario.SetLocation(new Vector2((int)mario.GetLocation().X, (int)mario.GetLocation().Y + 1));
            if (!(mario.GetConditionState() is SmallMarioState))
            {
                mario.SetMovementState(new MarioLeftCrouchState(mario));
            }
        }

        public override void RunRight()
        {
            mario.SetMovementState(new MarioRightIdleState(mario));
        }

        public override void RunLeft()
        {
            mario.SetMovementState(new MarioLeftRunState(mario));
        }
    }
}
