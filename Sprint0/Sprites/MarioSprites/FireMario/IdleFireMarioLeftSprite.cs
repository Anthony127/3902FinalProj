using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace SuperPixelBrosGame.States.Mario
{
    class IdleFireMarioLeftSprite : ISprite
    {
        private Texture2D spriteSheet;

        public IdleFireMarioLeftSprite(Texture2D texture)
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


            sourceRectangle = new Rectangle(168, 432, 16, 16*2);
            destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 16, 16*2);

            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, color);
        }

        public Rectangle GetHitboxFromSprite(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y, 16, 16 * 2);
        }
    }
}
