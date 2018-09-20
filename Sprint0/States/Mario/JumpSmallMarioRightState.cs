using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.Sprites.MarioSprites.Mario;
using System.Threading;

namespace Sprint0.States.Mario
{
    class JumpSmallMarioRightState : IMarioState
    {
        private SmallMarioSprite mario;
        private int currentFrame;
        private int totalFrames;

        public JumpSmallMarioRightState(SmallMarioSprite mario)
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
                sourceRectangle = new Rectangle(209, 0, 13, 19);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 13, 19);
            }
            else if (currentFrame == 1)
            {
                sourceRectangle = new Rectangle(208, 39, 16, 22);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 16, 22);
            }
            else
            {
                sourceRectangle = new Rectangle(248, 40, 16, 20);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 16, 20);
            }

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
            mario.State = new IdleSmallMarioRightState(mario);
            Thread.Sleep(250);
        }

        public void RunRight()
        {
            // no-op
            // mario.State = new JumpSmallMarioRightState(this);
        }

        public void RunLeft()
        {
            // no-op
            // mario.State = new JumpSmallMarioLeftState(this);
        }
    }
}
