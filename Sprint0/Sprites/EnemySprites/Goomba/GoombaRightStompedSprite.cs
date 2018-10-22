using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperPixelBrosGame
{
    public class GoombaRightStompedSprite : ISprite
    {

        private Texture2D spriteSheet;

        public GoombaRightStompedSprite(Texture2D texture)
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

            sourceRectangle = new Rectangle(13, 285, 16, 16);
            destinationRectangle = new Rectangle((int)location.X, (int)location.Y + 12, 16, 4);

            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, color);

        }

        public Rectangle GetHitboxFromSprite(Vector2 location)
        {
            return new Rectangle(0, 0, 0, 0);
        }
    }
}