using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace Sprint0
{
    public class StarSprite : ISprite
    {

        private Texture2D spriteSheet;
        private int currentFrame;
        private int totalFrames;

        public StarSprite(Texture2D texture)
        {
            spriteSheet = texture;
            currentFrame = 0;
            totalFrames = 30;
        }

        public void Update()
        {
            currentFrame = (currentFrame + 1) % totalFrames;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;

            if (currentFrame < 15)
            {
                sourceRectangle = new Rectangle(25, 23, 15, 16);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 15, 16);
            }
            else
            {
                sourceRectangle = new Rectangle(43, 23, 15, 16);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 15, 16);
            }           

            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, color);
        }
    }
}
