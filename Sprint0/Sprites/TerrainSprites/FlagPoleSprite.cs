using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.States;

namespace SuperPixelBrosGame
{
    public class FlagPoleSprite : ISprite
    {

        private Texture2D spriteSheet;
        private const int SIZE_SCALAR = 2;

        public FlagPoleSprite(Texture2D texture)
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

            sourceRectangle = new Rectangle(322, 255, 12, 138);
            destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 12 * SIZE_SCALAR, 138 * SIZE_SCALAR);

            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, color);
        }

        public Rectangle GetHitboxFromSprite(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y, 12 * SIZE_SCALAR, 138 * SIZE_SCALAR);
        }
    }
}