using SuperPixelBrosGame.Interfaces;

namespace SuperPixelBrosGame.States.Mario.Condition
{
    class FireMarioState : IConditionState
    {
        private IMario mario;
        private readonly string code = "FIRE";

        public FireMarioState(IMario mario)
        {
            this.mario = mario;
        }
        public void PowerUp()
        {
        }

        public void TakeDamage()
        {
            mario.SetConditionState(new LargeMarioState(mario));
        }

        public string GetConditionCode()
        {
            return code;
        }
    }
}
