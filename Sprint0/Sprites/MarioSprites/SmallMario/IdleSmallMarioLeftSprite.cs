using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperPixelBrosGame.States.Mario
{
    class IdleSmallMarioLeftSprite : ISprite
    {
        private Texture2D spriteSheet;
        private const int SIZE_SCALAR = 2;

        public IdleSmallMarioLeftSprite(Texture2D texture)
        {
            spriteSheet = texture;
        }

        public void Update()
        {
            //no-op one frame
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;

            sourceRectangle = new Rectangle(166, 0, 16, 20);
            destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 16 * SIZE_SCALAR, 20 * SIZE_SCALAR);

            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, color);
        }

        public Rectangle GetHitboxFromSprite(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y, 16 * SIZE_SCALAR, 20 * SIZE_SCALAR);
        }
    }
}
