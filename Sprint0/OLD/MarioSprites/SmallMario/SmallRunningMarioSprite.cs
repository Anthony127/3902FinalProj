using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint0
{
    class SmallRunningMarioSprite : ISprite
    {
        private Texture2D spriteSheet;
        private int currentFrame;
        private int totalFrames;
        private bool isFacingRight;

        public SmallRunningMarioSprite(Texture2D texture)
        {
            spriteSheet = texture;
            currentFrame = 0;
            totalFrames = 2;
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
                    sourceRectangle = new Rectangle(209, 0, 13, 19);
                    destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 26, 38);
                }
                else
                {
                    sourceRectangle = new Rectangle(328, 0, 14, 19);
                    destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 28, 38);
                }
            }
            else
            {
                if (currentFrame == 0)
                {
                    sourceRectangle = new Rectangle(169, 0, 13, 19);
                    destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 26, 38);
                }
                else
                {
                    sourceRectangle = new Rectangle(49, 0, 14, 19);
                    destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 28, 38);
                }
            }


            spriteBatch.Begin();
            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}