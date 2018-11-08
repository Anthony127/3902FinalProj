using SuperPixelBrosGame.Interfaces;
using Sprint0.States.BaseStates;
using SuperPixelBrosGame.Level;

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
            mario.ConditionState = this;
            mario.UpdateSprite();
        }

        public override void TakeDamage()
        {
            mario.ConditionState = new LargeMarioState(mario);
            SoundFactory.Instance.PlaySoundEffect("SOUND_PIPE");
            mario.TransitionStateNegative();
        }
    }
}
