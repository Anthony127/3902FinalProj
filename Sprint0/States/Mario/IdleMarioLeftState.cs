using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using System.Threading;


namespace Sprint0.States.Mario
{
    class IdleMarioLeftState : IMarioState
    {

        private MarioSprite mario;

        public IdleMarioLeftState(MarioSprite mario)
        {
            this.mario = mario;
        }

        public void Update()
        {
            //no-op one frame
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Texture2D spriteSheet)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;


            sourceRectangle = new Rectangle(169, 76, 15, 28);
            destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 15, 28);

            spriteBatch.Begin();
            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public void Jump()
        {
            mario.State = new JumpMarioLeftState(mario);
        }

        public void Crouch()
        {
            mario.State = new CrouchMarioLeftState(mario);
        }

        public void RunRight()
        {
            mario.State = new IdleMarioRightState(mario);
            Thread.Sleep(100);
        }

        public void RunLeft()
        {
            mario.State = new WalkMarioLeftState(mario);
        }

    }
}
