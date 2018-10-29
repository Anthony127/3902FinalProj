﻿using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.States.Mario.Condition;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Diagnostics;
using Sprint0.States.BaseStates;
using Sprint0.Interfaces;

namespace SuperPixelBrosGame.States.Mario.Movement
{
    class MarioLeftRunState : MovementState, IMovementState
    {
        private IMario mario;
        private IPhysics physicsMario;

        public override string MovementCode
        {
            get
            {
                return "LRUN";
            }
        }

        public MarioLeftRunState(IMario mario)
        {
            //mario.SetLocation(new Vector2((int)mario.GetLocation().X - 1, (int)mario.GetLocation().Y));
            
            this.mario = mario;
            mario.SetMovementState(this);
            physicsMario = (IPhysics)mario;
            if (physicsMario.Velocity.X == 0)
            {
                physicsMario.Velocity = new Vector2((float)-.8, physicsMario.Velocity.Y);
            }
            else
            {
                physicsMario.Velocity = new Vector2(physicsMario.Velocity.X, physicsMario.Velocity.Y);
            }
            physicsMario.Friction = new Vector2((float).3, 0);
            mario.UpdateSprite();
        }

        public override void Jump()
        {
            mario.SetMovementState(new MarioLeftJumpState(mario));
        }

        public override void Crouch()
        {
            if (!(mario.GetConditionState() is SmallMarioState))
            {
                mario.SetMovementState(new MarioLeftCrouchState(mario));
            }
        }

        public override void RunRight()
        {
            physicsMario.Velocity = new Vector2(physicsMario.Velocity.X + (float).1, physicsMario.Velocity.Y);
        }

        public override void RunLeft()
        {
            physicsMario.Velocity = new Vector2(physicsMario.Velocity.X - (float).55, physicsMario.Velocity.Y);
        }
    }
}

