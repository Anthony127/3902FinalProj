using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.States.Mario
{
    class IdleSmallMarioLeftSprite : ISprite
    {
        private Texture2D spriteSheet;

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

            sourceRectangle = new Rectangle(169, 0, 13, 19);
            destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 13, 19);

            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, color);
        }
    }
}
