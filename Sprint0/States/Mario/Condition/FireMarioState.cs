using Sprint0.Interfaces;

namespace Sprint0.States.Mario.Condition
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
            //no-op
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
