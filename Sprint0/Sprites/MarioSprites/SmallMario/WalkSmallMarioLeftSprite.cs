using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperPixelBrosGame.States.Mario
{
    class WalkSmallMarioLeftSprite : ISprite
    {
        private Texture2D spriteSheet;
        private int currentFrame;
        private int totalFrames;

        public WalkSmallMarioLeftSprite(Texture2D texture)
        {
            spriteSheet = texture;
            currentFrame = 0;
            totalFrames = 20;

        }

        public void Update()
        {
            currentFrame = (currentFrame + 1) % totalFrames;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;


            if (currentFrame < 10)
            {
                sourceRectangle = new Rectangle(166, 0, 16, 20);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 16, 20);
            }
            else
            {
                sourceRectangle = new Rectangle(48, 0, 16, 20);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 16, 20);
            }

            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, color);
        }

        public Rectangle GetHitboxFromSprite(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y, 16, 20);
        }
    }
}
