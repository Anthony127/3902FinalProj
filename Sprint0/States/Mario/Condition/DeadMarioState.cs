using Microsoft.Xna.Framework;
using SuperPixelBrosGame.Interfaces;

namespace SuperPixelBrosGame.States.Mario.Condition
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
