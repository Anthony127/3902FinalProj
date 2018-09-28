using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint0
{
    class JumpingMarioSprite : ISprite
    {
        private Texture2D spriteSheet;
        private int currentFrame;
        private int totalFrames;
        private bool isFacingRight;

        public JumpingMarioSprite(Texture2D texture)
        {
            spriteSheet = texture;
            currentFrame = 0;
            totalFrames = 3;
            isFacingRight = true;
        }

        public void Update()
        {
            currentFrame = (currentFrame + 1) % totalFrames;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;
            if (isFacingRight == true)
            {
                if (currentFrame == 0)
                {
                    sourceRectangle = new Rectangle(208, 76, 15, 28);
                    destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 30, 56);
                }
                else if (currentFrame == 1)
                {
                    sourceRectangle = new Rectangle(208, 114, 16, 32);
                    destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 32, 64);
                }
                else
                {
                    sourceRectangle = new Rectangle(248, 115, 16, 28);
                    destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 32, 56);
                }
            }
            else
            {
                if (currentFrame == 0)
                {
                    sourceRectangle = new Rectangle(169, 76, 15, 28);
                    destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 20, 56);
                }
                else if (currentFrame == 1)
                {
                    sourceRectangle = new Rectangle(168, 114, 16, 32);
                    destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 32, 64);
                }
                else
                {
                    sourceRectangle = new Rectangle(128, 115, 16, 28);
                    destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 32, 56);
                }

            }


            spriteBatch.Begin();
            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}