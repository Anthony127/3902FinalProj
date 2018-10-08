using Microsoft.Xna.Framework;
using Sprint0.Interfaces;

namespace Sprint0.States.Mario.Condition
{
    class DeadMarioState : IConditionState
    {
        private IMario mario;
        private readonly string code = "DEAD";

        public DeadMarioState(IMario mario)
        {
            this.mario = mario;

        }
        public void PowerUp()
        {
            
        }

        public void TakeDamage()
        {

        }

        public string GetConditionCode()
        {
            return code;
        }
    }
}
