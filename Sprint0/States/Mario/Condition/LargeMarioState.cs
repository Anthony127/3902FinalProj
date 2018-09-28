using Sprint0.Interfaces;

namespace Sprint0.States.Mario.Condition
{
    class LargeMarioState : IConditionState
    {
        private IMario mario;
        private string code = "LRGE";

        public LargeMarioState(IMario mario)
        {
            this.mario = mario;
        }
        public void PowerUp()
        {
            mario.SetConditionState(new FireMarioState(mario));
        }

        public void TakeDamage()
        {
            mario.SetConditionState(new SmallMarioState(mario));
        }

        public string GetConditionCode()
        {
            return code;
        }
    }
}