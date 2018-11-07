using Microsoft.Xna.Framework;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.States.Mario.Movement;
using Sprint0.States.BaseStates;
using SuperPixelBrosGame.Level;

namespace SuperPixelBrosGame.States.Mario.Condition
{
    class SmallMarioState : ConditionState, IConditionState
    {
        private IMario mario;
        public override string ConditionCode
        {
            get
            {
                return "SMLL";
            }
        }

        public SmallMarioState(IMario mario)
        {
            this.mario = mario;
            mario.ConditionState = this;
            mario.UpdateSprite();
            

        }
        public override void PowerUp()
        {
            mario.ConditionState = new LargeMarioState(mario);
            mario.Location = new Vector2(mario.Location.X, mario.Location.Y - 12);
            mario.TransitionStatePositive();
        }

        public override void TakeDamage()
        {
            mario.ConditionState = new DeadMarioState(mario);
            mario.MovementState = new MarioDeadMoveState(mario);
            
        }
    }
}
