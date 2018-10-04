using Microsoft.Xna.Framework;
using Sprint0.Interfaces;

namespace Sprint0.States.Mario.Condition
{
    class LargeMarioState : IConditionState
    {
        private IMario mario;
        private readonly string code = "LRGE";

        public LargeMarioState(IMario mario)
        {
            this.mario = mario;
            Rectangle hitbox = mario.GetCurrentHitbox();
            hitbox.Height = 32;
            mario.SetHitbox(hitbox);

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