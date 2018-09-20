using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using System.Threading;

namespace Sprint0.States.Mario
{
    class WalkMarioRightState : IMarioState
    {
        
        private MarioSprite mario;
        private int currentFrame;
        private int totalFrames;

        public WalkMarioRightState(MarioSprite mario)
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


            if (currentFrame == 0)
            {
                sourceRectangle = new Rectangle(208, 76, 15, 28);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 15, 28);
            }
            else if (currentFrame == 1)
            {
                sourceRectangle = new Rectangle(368, 76, 16, 28);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 16, 28);
            }
            else
            {
                sourceRectangle = new Rectangle(328, 76, 16, 28);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 16, 28);
            }

            spriteBatch.Begin();
            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public void Jump()
        {
            mario.State = new JumpMarioRightState(mario);
        }

        public void Crouch()
        {
            mario.State = new CrouchMarioRightState(mario);
        }

        public void RunRight()
        {
            //no op
        }

        public void RunLeft()
        {
            mario.State = new IdleMarioRightState(mario);
            Thread.Sleep(250);
        }
    }
}
