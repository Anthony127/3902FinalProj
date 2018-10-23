using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperPixelBrosGame
{
    public class GoombaLeftSprite : ISprite
    {

        private Texture2D spriteSheet;
        private int currentFrame;
        private int totalFrames;

        public GoombaLeftSprite(Texture2D texture)
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
                sourceRectangle = new Rectangle(12, 326, 16, 16);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 16, 16);
            }
            else {
                sourceRectangle = new Rectangle(52, 326, 16, 16);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 16, 16);
            }

            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, color);

        }

        public Rectangle GetHitboxFromSprite(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y, 16, 16);
        }
    }
} 