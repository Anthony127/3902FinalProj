using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.States;

namespace SuperPixelBrosGame
{
    public class BrickBlockBrokenSprite : ISprite
    {

        private Texture2D spriteSheet;
        private const int SIZE_SCALAR = 2;

        public BrickBlockBrokenSprite(Texture2D texture)
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

            sourceRectangle = new Rectangle(310, 15, 20, 20);
            destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 20 * SIZE_SCALAR, 20 * SIZE_SCALAR);

            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, color);
        }

        public Rectangle GetHitboxFromSprite(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y, 20 * SIZE_SCALAR, 20 * SIZE_SCALAR);
        }
    }
}