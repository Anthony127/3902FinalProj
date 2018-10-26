using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperPixelBrosGame
{
    public class KoopaShellSprite : ISprite
    {
        private Texture2D spriteSheet;
        private const int SIZE_SCALAR = 2;

        public KoopaShellSprite(Texture2D texture)
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

            sourceRectangle = new Rectangle(12, 86, 16, 16);
            destinationRectangle = new Rectangle((int)location.X, (int)location.Y + 11, 16 * SIZE_SCALAR, 16 * SIZE_SCALAR);


            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, color);
        }

        public Rectangle GetHitboxFromSprite(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y + 11, 16 * SIZE_SCALAR, 16 * SIZE_SCALAR);
        }
    }
}