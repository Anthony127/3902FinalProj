using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.Sprites.MarioSprites.Mario;
using System.Threading;

namespace Sprint0.States.Mario
{
    class IdleSmallMarioLeftState : IMarioState
    {

        private SmallMarioSprite mario;

        public IdleSmallMarioLeftState(SmallMarioSprite mario)
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


            sourceRectangle = new Rectangle(169, 0, 13, 19);
            destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 13, 19);

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
            //no-op
        }

        public void RunRight()
        {
            mario.State = new IdleSmallMarioRightState(mario);
            Thread.Sleep(100);
        }

        public void RunLeft()
        {
            mario.State = new WalkSmallMarioLeftState(mario);
        }

    }
}
