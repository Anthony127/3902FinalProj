using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint0
{
    class SmallDeadMarioSprite : ISprite
    {
        private Texture2D spriteSheet;
        private int currentFrame;
        private int totalFrames;
        private bool isFacingRight;

        public SmallDeadMarioSprite(Texture2D texture)
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
                sourceRectangle = new Rectangle(368, 38, 16, 24);
            }else{
                sourceRectangle = new Rectangle(8, 38, 16, 24);
            }
            destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 32, 48);

            spriteBatch.Begin();
            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
