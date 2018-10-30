using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.States.Mario.Condition;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Diagnostics;
using Sprint0.States.BaseStates;
using Sprint0.Interfaces;
using SuperPixelBrosGame.Level;

namespace SuperPixelBrosGame.States.Mario.Movement
{
    class MarioDeadMoveState : MovementState, IMovementState
    {
        private IPhysics marioPhysics;
        public override string MovementCode
        {
            get
            {
                return "DEAM";
            }
        }

        public MarioDeadMoveState(IMario mario)
        {
            mario.MovementState = this;
            marioPhysics = (IPhysics)mario;
            marioPhysics.Velocity = new Vector2(0, -3);
            marioPhysics.Friction = new Vector2(0, 0);
            PlayerLevel.Instance.PlayerArray.Remove(mario);
            ICommand command = new TimeLevelOutCommand();
            command.Execute();
            mario.UpdateSprite();
            
        }
    }
}
