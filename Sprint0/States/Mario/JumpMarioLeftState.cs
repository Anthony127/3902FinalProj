using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using System.Threading;

namespace Sprint0.States.Mario
{
    class JumpMarioLeftState : IMarioState
    {

        private MarioSprite mario;
        private int totalFrames;
        private int currentFrame;

        public JumpMarioLeftState(MarioSprite mario)
        {
            this.mario = mario;
            currentFrame = 0;
            totalFrames = 3;
        }

        public void Update()
        {
            currentFrame = (currentFrame + 1) % totalFrames;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Texture2D spriteSheet)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;


            /*if (currentFrame == 0)
            {
                sourceRectangle = new Rectangle(169, 76, 15, 28);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 15, 28);
            }
            else if (currentFrame == 1)
            {*/
                sourceRectangle = new Rectangle(168, 114, 16, 32);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 16, 32);
            /*}
            else
            {
                sourceRectangle = new Rectangle(128, 115, 16, 28);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 16, 28);
            }*/

            spriteBatch.Begin();
            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public void Jump()
        {
            //no op
        }

        public void Crouch()
        {
            mario.State = new IdleMarioLeftState(mario);
            Thread.Sleep(100);
        }

        public void RunRight()
        {
            // no-op
            // mario.State = new JumpMarioRightState(this);
        }

        public void RunLeft()
        {
            // no-op
            //mario.State = new JumpMarioLeftState(this);
        }
    }
}
