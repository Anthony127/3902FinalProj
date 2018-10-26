using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperPixelBrosGame
{
    public class GoombaRightSprite : ISprite
    {

        private Texture2D spriteSheet;
        private int currentFrame;
        private int totalFrames;
        private const int SIZE_SCALAR = 2;

        public GoombaRightSprite(Texture2D texture)
        {
            spriteSheet = texture;
            currentFrame = 0;
            totalFrames = 30;

        }

        public void Update()
        {
            currentFrame = (currentFrame + 1) % totalFrames;

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;

            if (currentFrame < 15)
            {
                sourceRectangle = new Rectangle(13, 285, 16, 16);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 16* SIZE_SCALAR, 16 * SIZE_SCALAR);
            }
            else
            {
                sourceRectangle = new Rectangle(53, 284, 16, 16);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 16 * SIZE_SCALAR, 16 * SIZE_SCALAR);
            }

            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, color);

        }

        public Rectangle GetHitboxFromSprite(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y, 16 * SIZE_SCALAR, 16 * SIZE_SCALAR);
        }
    }
}