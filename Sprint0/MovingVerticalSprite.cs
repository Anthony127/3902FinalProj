using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    class MovingVerticalSprite : ISprite
    {
        readonly int LowerBound = 0;
        readonly int UpperBound = 400;
        private Texture2D spriteSheet;
        private bool movingDown;
        private int yPos;
        private int currentFrame;
        private int totalFrames;

        public MovingVerticalSprite(Texture2D spriteSheet)
        {
            this.spriteSheet = spriteSheet;
            currentFrame = 0;
            totalFrames = 1;
            movingDown = true;
            yPos = (LowerBound + UpperBound) / 2;
        }

        public void Update()
        {
            currentFrame = (currentFrame + 1) % totalFrames;
            if (movingDown)
            {
                yPos -= 3;
                if (yPos <= LowerBound)
                    movingDown = false;
            }
            else
            {
                yPos += 3;
                if (yPos >= UpperBound)
                    movingDown = true;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;

            sourceRectangle = new Rectangle(390, 16, 15, 14);
            destinationRectangle = new Rectangle((int)location.X, yPos, 60, 56);

            spriteBatch.Begin();
            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}