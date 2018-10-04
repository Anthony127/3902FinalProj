using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Sprint0.States.Mario
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


            sourceRectangle = new Rectangle(169, 436, 15, 28);
            destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 15, 28);

            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, color);
        }
    }
}
