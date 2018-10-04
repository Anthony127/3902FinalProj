using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.States.Mario
{
    class JumpSmallMarioLeftSprite : ISprite
    {
        private Texture2D spriteSheet;
        private int currentFrame;
        private int totalFrames;

        public JumpSmallMarioLeftSprite(Texture2D texture)
        {
            spriteSheet = texture;
            currentFrame = 0;
            totalFrames = 3;

        }

        public void Update()
        {
            currentFrame = (currentFrame + 1) % totalFrames;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;

            //if (currentFrame == 0)
            //{
            //    sourceRectangle = new Rectangle(169, 0, 13, 19);
            //    destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 13, 19);
            //}
            //else if (currentFrame == 1)
            //{
                sourceRectangle = new Rectangle(169, 39, 16, 22);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 16, 22);
            //}
            //else
            //{
            //    sourceRectangle = new Rectangle(128, 40, 16, 20);
            //    destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 16, 20);
            //}

            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, color);
        }
    }
}
