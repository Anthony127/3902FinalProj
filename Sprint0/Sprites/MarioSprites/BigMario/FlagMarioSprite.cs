using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperPixelBrosGame.Interfaces;
using System.Threading;

namespace SuperPixelBrosGame.States.Mario
{
    class FlagMarioSprite : ISprite
    {
        private Texture2D spriteSheet;
        private const int SIZE_SCALAR = 2;
        public FlagMarioSprite(Texture2D texture)
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


            sourceRectangle = new Rectangle(204, 755, 18, 29);
            destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 18 * SIZE_SCALAR, 29 * SIZE_SCALAR);

            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, color);
        }

        public Rectangle GetHitboxFromSprite(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y, 18 * SIZE_SCALAR, 29 * SIZE_SCALAR);
        }
    }
}