using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.States.Mario
{
    class WalkFireMarioLeftSprite : ISprite
    {
        private Texture2D spriteSheet;
        private int currentFrame;
        private int totalFrames;

        public WalkFireMarioLeftSprite(Texture2D texture)
        {
            spriteSheet = texture;
            currentFrame = 0;
            totalFrames = 15;

        }

        public void Update()
        {
            currentFrame = (currentFrame + 1) % totalFrames;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;


            if (currentFrame < 5)
            {
                sourceRectangle = new Rectangle(169, 432, 16, 16*2);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 16, 16*2);
            }
            else if (currentFrame < 10)
            {
                sourceRectangle = new Rectangle(8, 432, 16, 16*2);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 16, 16*2);
            }
            else
            {
                sourceRectangle = new Rectangle(48, 432, 16, 16*2);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 16, 16*2);
            }

            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, color);
        }

        public Rectangle GetHitboxFromSprite(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y, 16, 16 * 2);
        }
    }
}
