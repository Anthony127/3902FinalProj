﻿using Sprint0.Interfaces;
using Sprint0.States.Mario.Condition;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace Sprint0.States.Mario.Movement
{
    class MarioLeftJumpState : IMovementState
    {
        private IMario mario;
        private string code = "LJMP";

        public MarioLeftJumpState(IMario mario)
        {
            mario.SetLocation(new Vector2((int)mario.GetLocation().X, (int)mario.GetLocation().Y - 1));
            this.mario = mario;
        }

        public void Jump()
        {
            mario.SetLocation(new Vector2((int)mario.GetLocation().X, (int)mario.GetLocation().Y - 1));
        }

        public void Crouch()
        {
            mario.SetMovementState(new MarioLeftIdleState(mario));
        }

        public void RunRight()
        {
            mario.SetMovementState(new MarioRightJumpState(mario));
        }

        public void RunLeft()
        {
            mario.SetLocation(new Vector2((int)mario.GetLocation().X - 1, (int)mario.GetLocation().Y));
        }

        public string GetMovementCode()
        {
            return code;
        }
    }
}
