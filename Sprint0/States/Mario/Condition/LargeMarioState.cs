using Microsoft.Xna.Framework;
using SuperPixelBrosGame.Interfaces;

namespace SuperPixelBrosGame.States.Mario.Condition
{
    class LargeMarioState : IConditionState
    {
        private IMario mario;
        private readonly string code = "LRGE";

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
            mario.SetLocation(new Vector2(mario.GetLocation().X, mario.GetLocation().Y + 12));
        }

        public string GetConditionCode()
        {
            return code;
        }
    }
}