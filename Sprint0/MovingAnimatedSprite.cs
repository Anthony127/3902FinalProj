using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    class MovingAnimatedSprite : ISprite
    {
        readonly int LeftBound = 0;
        readonly int RightBound = 650;
        private Texture2D spriteSheet;
        private bool movingLeft;
        private int xPos;
        private int currentFrame;
        private int totalFrames;

        public MovingAnimatedSprite(Texture2D spriteSheet)
        {
            this.spriteSheet = spriteSheet;
            currentFrame = 0;
            totalFrames = 3;
            movingLeft = true;
            xPos = ( LeftBound + RightBound ) / 2;
        }

        public void Update()
        {
            currentFrame = (currentFrame + 1) % totalFrames;
            if (movingLeft)
            {
                xPos -= 3;
                if (xPos <= LeftBound)
                    movingLeft = false;
            }
            else
            {
                xPos += 3;
                if (xPos >= RightBound)
                    movingLeft = true;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;

            if (xPos <= LeftBound + 20)
            {
                sourceRectangle = new Rectangle(60, 52, 16, 32);
                destinationRectangle = new Rectangle(xPos, (int)location.Y, 64, 128);
            }
            else if (xPos >= RightBound - 20)
            {
                sourceRectangle = new Rectangle(329, 52, 16, 32);
                destinationRectangle = new Rectangle(xPos, (int)location.Y, 64, 128);
            }
            else
            {

                if (movingLeft)
                {
                    if (currentFrame == 0)
                    {
                        sourceRectangle = new Rectangle(150, 52, 16, 32);
                        destinationRectangle = new Rectangle(xPos, (int)location.Y, 64, 128);
                    }
                    else if (currentFrame == 1)
                    {
                        sourceRectangle = new Rectangle(120, 52, 16, 32);
                        destinationRectangle = new Rectangle(xPos, (int)location.Y, 64, 128);
                    }
                    else
                    {
                        sourceRectangle = new Rectangle(90, 52, 16, 32);
                        destinationRectangle = new Rectangle(xPos, (int)location.Y, 64, 128);
                    }
                }
                else
                {
                    if (currentFrame == 0)
                    {
                        sourceRectangle = new Rectangle(239, 52, 16, 32);
                        destinationRectangle = new Rectangle(xPos, (int)location.Y, 64, 128);
                    }
                    else if (currentFrame == 1)
                    {
                        sourceRectangle = new Rectangle(269, 52, 16, 32);
                        destinationRectangle = new Rectangle(xPos, (int)location.Y, 64, 128);
                    }
                    else
                    {
                        sourceRectangle = new Rectangle(299, 52, 16, 32);
                        destinationRectangle = new Rectangle(xPos, (int)location.Y, 64, 128);
                    }
                }
            }

            spriteBatch.Begin();
            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}