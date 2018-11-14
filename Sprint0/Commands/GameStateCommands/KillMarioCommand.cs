using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.States.Mario.Condition;
using SuperPixelBrosGame.States.Mario.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPixelBrosGame
{
    class KillMarioCommand : ICommand
    {
        private IMario mario;

        public KillMarioCommand(IMario mario)
        {
            this.mario = mario;
        }

        public void Execute()
        {
            mario.ConditionState = new DeadMarioState(mario);
            mario.MovementState = new MarioDeadMoveState(mario);
        }

    }
}
