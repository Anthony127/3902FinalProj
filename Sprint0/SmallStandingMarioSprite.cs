using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint0
{
    class SmallStandingMarioSprite : ISprite
    {
        private Texture2D spriteSheet;
        private int currentFrame;
        private int totalFrames;

        public StaticStandingSprite(Texture2D texture)
        {
            spriteSheet = texture;
            currentFrame = 0;
            totalFrames = 1;
        }

        public void Update()
        {
            currentFrame = (currentFrame + 1) % totalFrames;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;

            sourceRectangle = new Rectangle(169, 0, 13, 19);
            destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 64, 128);

            spriteBatch.Begin();
            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
