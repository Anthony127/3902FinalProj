using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.Sprites.MarioSprites.Mario;

namespace Sprint0.States.Mario
{
    class WalkSmallMarioRightState : IMarioState
    {
        private SmallMarioSprite mario;

        public WalkSmallMarioRightState(SmallMarioSprite mario)
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


            sourceRectangle = new Rectangle(208, 76, 15, 28); // FIX RECTANGLE
            destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 30, 56);

            spriteBatch.Begin();
            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public void Jump()
        {
            mario.State = new JumpSmallMarioRightState(mario);
        }

        public void Crouch()
        {
            mario.State = new CrouchSmallMarioRightState(mario);
        }

        public void RunRight()
        {
            //no op
        }

        public void RunLeft()
        {
            mario.State = new IdleSmallMarioRightState(mario);
        }
    }
}
