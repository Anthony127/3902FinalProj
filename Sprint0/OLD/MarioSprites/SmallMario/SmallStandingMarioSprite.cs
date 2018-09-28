using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint0
{
    class SmallStandingMarioSprite : ISprite
    {
        private Texture2D spriteSheet;
        private int currentFrame;
        private int totalFrames;
        private bool isFacingRight;

        public SmallStandingMarioSprite(Texture2D texture)
        {
            spriteSheet = texture;
            currentFrame = 0;
            totalFrames = 1;
            isFacingRight = true;
        }

        public void Update()
        {
            currentFrame = (currentFrame + 1) % totalFrames;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;

            if (isFacingRight == true) { 
                sourceRectangle = new Rectangle(209, 0, 13, 19);
            }
            else{
                sourceRectangle = new Rectangle(169, 0, 13, 19);
            }
            destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 26, 38);

            spriteBatch.Begin();
            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
