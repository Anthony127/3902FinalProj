using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperPixelBrosGame
{
    public class FireBallSprite : ISprite
    {

        private Texture2D spriteSheet;
        private const int SIZE_SCALAR = 2;

        public FireBallSprite(Texture2D texture)
        {
            spriteSheet = texture;
        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;

                sourceRectangle = new Rectangle(128, 180, 12, 12);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 12 * SIZE_SCALAR, 12 * SIZE_SCALAR);

            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, color);
        }

        public Rectangle GetHitboxFromSprite(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y, 12 * SIZE_SCALAR, 12 * SIZE_SCALAR);
        }
    }
}