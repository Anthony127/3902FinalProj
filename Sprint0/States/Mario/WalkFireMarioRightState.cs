using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.Sprites.MarioSprites.Mario;
using System.Threading;

namespace Sprint0.States.Mario
{
    class WalkFireMarioRightState : IMarioState
    {
        private FireMarioSprite mario;
        private int currentFrame;
        private int totalFrames;

        public WalkFireMarioRightState(FireMarioSprite mario)
        {
            this.mario = mario;
            currentFrame = 0;
            totalFrames = 15;
        }

        public void Update()
        {
            currentFrame = (currentFrame + 1) % totalFrames;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Texture2D spriteSheet)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;

            if (currentFrame < 5)
            {
                sourceRectangle = new Rectangle(208, 436, 15, 28);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 15, 28);
            }
            else if (currentFrame < 10)
            {
                sourceRectangle = new Rectangle(368, 436, 16, 28);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 16, 28);
            }
            else
            {
                sourceRectangle = new Rectangle(328, 436, 16, 28);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 16, 28);
            }

            spriteBatch.Begin();
            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public void Jump()
        {
            mario.State = new JumpFireMarioRightState(mario);
        }

        public void Crouch()
        {
            mario.State = new CrouchFireMarioRightState(mario);
        }

        public void RunRight()
        {
            //no op
        }

        public void RunLeft()
        {
            mario.State = new IdleFireMarioRightState(mario);
            Thread.Sleep(100);
        }
    }
}
