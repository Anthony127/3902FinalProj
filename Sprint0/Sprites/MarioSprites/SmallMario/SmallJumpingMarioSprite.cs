using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint0
{
    class SmallJumpingMarioSprite : ISprite
    {
        private Texture2D spriteSheet;
        private int currentFrame;
        private int totalFrames;
        private bool isFacingRight;

        public SmallJumpingMarioSprite(Texture2D texture)
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
                    sourceRectangle = new Rectangle(209, 0, 13, 19);
                    destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 26, 38);
                }
                else if (currentFrame == 1)
                {
                    sourceRectangle = new Rectangle(208, 39, 16, 22);
                    destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 32, 44);
                }
                else
                {
                    sourceRectangle = new Rectangle(248, 40, 16, 20);
                    destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 32, 40);
                } 
            }
            else
            {
                if (currentFrame == 0)
                {
                    sourceRectangle = new Rectangle(169, 0, 13, 19);
                    destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 26, 38);
                }
                else if(currentFrame == 1)
                {
                    sourceRectangle = new Rectangle(169, 39, 16, 22);
                    destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 32, 44);
                }
                else
                {
                    sourceRectangle = new Rectangle(128, 40, 16, 20);
                    destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 32, 40);
                }

            }


            spriteBatch.Begin();
            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}