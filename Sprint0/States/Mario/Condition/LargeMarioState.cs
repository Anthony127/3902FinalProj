using Microsoft.Xna.Framework;
using SuperPixelBrosGame.Interfaces;
using Sprint0.States.BaseStates;

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

        }
        public override void PowerUp()
        {
            mario.SetConditionState(new FireMarioState(mario));
        }

        public override void TakeDamage()
        {
            mario.SetConditionState(new SmallMarioState(mario));
            mario.SetLocation(new Vector2(mario.GetLocation().X, mario.GetLocation().Y + 12));
        }
    }
}