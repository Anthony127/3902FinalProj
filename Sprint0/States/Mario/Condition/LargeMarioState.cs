using Microsoft.Xna.Framework;
using SuperPixelBrosGame.Interfaces;
using Sprint0.States.BaseStates;
using SuperPixelBrosGame.Level;

namespace SuperPixelBrosGame.States.Mario.Condition
{
    class LargeMarioState : ConditionState, IConditionState
    {
        private IMario mario;
        public override string ConditionCode
        {
            get
            {
                return "LRGE";
            }
        }

        public LargeMarioState(IMario mario)
        {
            this.mario = mario;
            mario.ConditionState = this;
            mario.UpdateSprite();
            PlayerLevel.Instance.TransitionState();
        }
        public override void PowerUp()
        {
            mario.ConditionState = new FireMarioState(mario);
        }

        public override void TakeDamage()
        {
            mario.ConditionState = new SmallMarioState(mario);
            mario.Location = new Vector2(mario.Location.X, mario.Location.Y + 12);
        }
    }
}