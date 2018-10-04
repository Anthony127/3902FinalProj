using Microsoft.Xna.Framework;
using Sprint0.Interfaces;

namespace Sprint0.States.Mario.Condition
{
    class SmallMarioState : IConditionState
    {
        private IMario mario;
        private readonly string code = "SMLL";

        public SmallMarioState(IMario mario)
        {
            this.mario = mario;
            Rectangle hitbox = mario.GetHitbox();
            hitbox.Height = 19;
            mario.SetHitbox(hitbox);
        }
        public void PowerUp()
        {
            mario.SetConditionState(new LargeMarioState(mario));
        }

        public void TakeDamage()
        {
            //TODO
            //mario.SetConditionState(new DeadMarioState(mario));
        }

        public string GetConditionCode()
        {
            return code;
        }
    }
}
