using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using System.Threading;

namespace Sprint0.States.Mario
{
    class CrouchMarioRightState : IMarioState
    {
        private MarioSprite mario;

        public CrouchMarioRightState(MarioSprite mario)
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


            sourceRectangle = new Rectangle(288, 122, 15, 14);
            destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 15, 14);

            spriteBatch.Begin();
            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public void Jump()
        {
            mario.State = new IdleMarioRightState(mario);
            Thread.Sleep(100);
        }

        public void Crouch()
        {
            //no op
        }

        public void RunRight()
        {
            // no-op
            // mario.State = new IdleMarioRightState(this);
        }

        public void RunLeft()
        {
            // no-op
            // mario.State = new IdleMarioRightState(this);
        }
    }
}
