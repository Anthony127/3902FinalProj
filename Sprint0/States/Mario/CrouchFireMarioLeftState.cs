using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.Sprites.MarioSprites.Mario;
using System.Threading;

namespace Sprint0.States.Mario
{
    
        class CrouchFireMarioLeftState : IMarioState
        {
            private FireMarioSprite mario;

            public CrouchFireMarioLeftState(FireMarioSprite mario)
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


                sourceRectangle = new Rectangle(88, 482, 15, 14);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 15, 14);

                spriteBatch.Begin();
                spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, Color.White);
                spriteBatch.End();
            }

            public void Jump()
            {
                mario.State = new IdleFireMarioLeftState(mario);
                Thread.Sleep(100);
            }

            public void Crouch()
            {
                mario.State = new CrouchFireMarioLeftState(mario);
            }

            public void RunRight()
            {
                // no-op
                // mario.State = new CrouchFireMarioRightState(this);
            }

            public void RunLeft()
            {
                // no-op
                // mario.State = new IdleFireMarioLeftState(this);
            }
        }
    
}
