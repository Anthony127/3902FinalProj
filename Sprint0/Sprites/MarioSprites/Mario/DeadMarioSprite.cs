using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Sprites.MarioSprites.Mario
{
    class DeadMarioSprite : IMarioSprite, ISprite
    {
        private Texture2D spriteSheet;

        public DeadMarioSprite(Texture2D texture)
        {
            spriteSheet = texture;
        }

        public void Update()
        {
            //no-op one frame
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;

            sourceRectangle = new Rectangle(368, 38, 16, 24);
            destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 16, 24);

            spriteBatch.Begin();
            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public void Jump()
        {
            //no-op
        }

        public void Crouch()
        {
            //no-op
        }

        public void RunRight()
        {
            //no-op
        }

        public void RunLeft()
        {
            //no-op
        }
    }
}
