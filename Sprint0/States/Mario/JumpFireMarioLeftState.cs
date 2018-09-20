using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.Sprites.MarioSprites.Mario;
using System.Threading;

namespace Sprint0.States.Mario
{
    class JumpFireMarioLeftState : IMarioState
    {
        private FireMarioSprite mario;
        private int currentFrame;
        private int totalFrames;

        public JumpFireMarioLeftState(FireMarioSprite mario)
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
                sourceRectangle = new Rectangle(169, 436, 15, 28);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 15, 28);
            }
            else if (currentFrame == 1)
            {
                sourceRectangle = new Rectangle(168, 474, 16, 32);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 16, 32);
            }
            else
            {
                sourceRectangle = new Rectangle(128, 475, 16, 28);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 16, 28);
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
            mario.State = new IdleFireMarioLeftState(mario);
            Thread.Sleep(100);
        }

        public void RunRight()
        {
            // no-op
            // mario.State = new JumpFireMarioRightState(this);
        }

        public void RunLeft()
        {
            // no-op
            // mario.State = new JumpFireMarioLeftState(this);
        }

    }
}
