using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.States.Mario
{
    class JumpSmallMarioRightSprite : ISprite
    {
        private Texture2D spriteSheet;
        private int currentFrame;
        private int totalFrames;

        public JumpSmallMarioRightSprite(Texture2D texture)
        {
            spriteSheet = texture;
            currentFrame = 0;
            totalFrames = 3;

        }

        public void Update()
        {
            currentFrame = (currentFrame + 1) % totalFrames;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;


            //if (currentFrame == 0)
            //{
            //    sourceRectangle = new Rectangle(209, 0, 13, 19);
            //    destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 13, 19);
            //}
            //else if (currentFrame == 1)
            //{
                sourceRectangle = new Rectangle(208, 39, 16, 22);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 16, 22);
            //}
            //else
            //{
            //    sourceRectangle = new Rectangle(248, 40, 16, 20);
            //    destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 16, 20);
            //}

            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
