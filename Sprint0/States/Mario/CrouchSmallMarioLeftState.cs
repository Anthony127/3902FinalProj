using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.Sprites.MarioSprites.Mario;

namespace Sprint0.States.Mario
{
    class CrouchSmallMarioLeftState : IMarioState
    {
        private SmallMarioSprite mario;

        public CrouchSmallMarioLeftState(SmallMarioSprite mario)
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
            mario.State = new IdleSmallMarioLeftState(mario);
        }

        public void Crouch()
        {
            mario.State = new CrouchSmallMarioLeftState(mario);
        }

        public void RunRight()
        {
            // no-op
            // mario.State = new CrouchSmallMarioRightState(this);
        }

        public void RunLeft()
        {
            // no-op
            //mario.State = new WalkSmallMarioLeftState(this);
        }
    }
}
