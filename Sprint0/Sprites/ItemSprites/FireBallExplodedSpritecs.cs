using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperPixelBrosGame
{
    public class FireBallExplodedSprite : ISprite
    {

        private Texture2D spriteSheet;
        private const int SIZE_SCALAR = 2;

        public FireBallExplodedSprite(Texture2D texture)
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

            sourceRectangle = new Rectangle(102, 81, 17, 17);
            destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 17 * SIZE_SCALAR, 17 * SIZE_SCALAR);

            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, color);
        }

        public Rectangle GetHitboxFromSprite(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y, 17 * SIZE_SCALAR, 17 * SIZE_SCALAR);
        }
    }
}