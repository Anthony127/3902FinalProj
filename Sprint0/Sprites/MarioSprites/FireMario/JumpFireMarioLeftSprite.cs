using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperPixelBrosGame.States.Mario
{
    class JumpFireMarioLeftSprite : ISprite
    {
        private Texture2D spriteSheet;
        private int currentFrame;
        private int totalFrames;
                private const int SIZE_SCALAR = 2;

        public JumpFireMarioLeftSprite(Texture2D texture)
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

                sourceRectangle = new Rectangle(168, 474, 16, 16*2);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 16 * SIZE_SCALAR, 16*2 * SIZE_SCALAR);


            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, color);
        }

        public Rectangle GetHitboxFromSprite(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y, 16 * SIZE_SCALAR, 16 * 2 * SIZE_SCALAR);
        }
    }
}
