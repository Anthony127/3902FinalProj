﻿using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.States.Mario.Condition;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Diagnostics;
using Sprint0.States.BaseStates;

namespace SuperPixelBrosGame.States.Mario.Movement
{
    class MarioDeadMoveState : MovementState, IMovementState
    {
        private IMario mario;
        public override string MovementCode
        {
            get
            {
                return "DEAM";
            }
        }

        public MarioDeadMoveState(IMario mario)
        {
            this.mario = mario;
            mario.UpdateSprite();
        }
    }
}
