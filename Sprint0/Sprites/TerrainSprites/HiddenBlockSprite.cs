using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.States;

namespace SuperPixelBrosGame
{
    public class HiddenBlockSprite : ISprite
    {
        private Texture2D spriteSheet;
        private const int SIZE_SCALAR = 2;

        public HiddenBlockSprite(Texture2D texture)
        {
            spriteSheet = texture;
        }

        public void Update()
        {
            //no-op
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;

            sourceRectangle = new Rectangle(187, 119, 16, 16);
            destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 16 * SIZE_SCALAR, 16 * SIZE_SCALAR);

            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, color);
        }

        public Rectangle GetHitboxFromSprite(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y, 16 * SIZE_SCALAR, 16 * SIZE_SCALAR);
        }
    }
}