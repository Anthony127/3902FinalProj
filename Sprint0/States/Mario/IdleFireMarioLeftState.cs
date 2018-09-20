using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.Sprites.MarioSprites.Mario;
using System.Threading;


namespace Sprint0.States.Mario
{
    class IdleFireMarioLeftState : IMarioState
    {
        private FireMarioSprite mario;

        public IdleFireMarioLeftState(FireMarioSprite mario)
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


            sourceRectangle = new Rectangle(169, 436, 15, 28);
            destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 15, 28);

            spriteBatch.Begin();
            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public void Jump()
        {
            mario.State = new JumpFireMarioLeftState(mario);
        }

        public void Crouch()
        {
            mario.State = new CrouchFireMarioLeftState(mario);
        }

        public void RunRight()
        {
            mario.State = new IdleFireMarioRightState(mario);
            Thread.Sleep(250);
        }

        public void RunLeft()
        {
            mario.State = new WalkFireMarioLeftState(mario);
        }

    }
}
