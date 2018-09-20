using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.Sprites.MarioSprites.Mario;
using System.Threading;

namespace Sprint0.States.Mario
{
    class WalkSmallMarioLeftState : IMarioState
    {
        private SmallMarioSprite mario;
        private int currentFrame;
        private int totalFrames;

        public WalkSmallMarioLeftState(SmallMarioSprite mario)
        {
            this.mario = mario;
            currentFrame = 0;
            totalFrames = 2;
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
                sourceRectangle = new Rectangle(169, 0, 13, 19);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 13, 19);
            }
            else
            {
                sourceRectangle = new Rectangle(49, 0, 14, 19);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 14, 19);
            }

            spriteBatch.Begin();
            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public void Jump()
        {
            mario.State = new JumpSmallMarioLeftState(mario);
        }

        public void Crouch()
        {
            //no op
        }

        public void RunRight()
        {
            mario.State = new IdleSmallMarioLeftState(mario);
            Thread.Sleep(100);
        }

        public void RunLeft()
        {
            //no op
        }
    }
}
