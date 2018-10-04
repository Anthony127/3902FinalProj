using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using System.Threading;

namespace Sprint0.States.Mario
{
    class JumpMarioRightSprite : ISprite
    {
        private Texture2D spriteSheet;
        private int currentFrame;
        private int totalFrames;

        public JumpMarioRightSprite(Texture2D texture)
        {
            spriteSheet = texture;
            currentFrame = 0;
            totalFrames = 3;

        }

        public void Update()
        {
            currentFrame = (currentFrame + 1) % totalFrames;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;


            /*if (currentFrame == 0)
            {
                sourceRectangle = new Rectangle(208, 76, 15, 28);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 15, 28);
            }
            else if (currentFrame == 1)
            {*/
                sourceRectangle = new Rectangle(208, 114, 16, 32);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 16, 32);
            /*}
            else
            {
                sourceRectangle = new Rectangle(248, 115, 16, 28);
               destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 16, 28);
            }*/

            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, color);
        }
    }
}
