using SuperPixelBrosGame.Interfaces;
using Sprint0.States.BaseStates;

namespace SuperPixelBrosGame.States.Mario.Condition
{
    class FireMarioState : ConditionState, IConditionState
    {
        private IMario mario;
        public override string ConditionCode
        {
            get
            {
                return "FIRE";
            }
        }

        public FireMarioState(IMario mario)
        {
            this.mario = mario;
            mario.UpdateSprite();
        }

        public override void TakeDamage()
        {
            mario.SetConditionState(new LargeMarioState(mario));
        }
    }
}
