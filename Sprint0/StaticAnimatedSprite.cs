using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint0
{
    class StaticAnimatedSprite : ISprite
    {
        private Texture2D spriteSheet;
        private int currentFrame;
        private int totalFrames;

        public StaticAnimatedSprite(Texture2D texture)
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

            if (currentFrame == 0)
            {
                sourceRectangle = new Rectangle(239, 52, 16, 32);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 64, 128);
            }
            else if (currentFrame == 1)
            {
                sourceRectangle = new Rectangle(269, 52, 16, 32);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 64, 128);
            }
            else
            {
                sourceRectangle = new Rectangle(299, 52, 16, 32);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 64, 128);
            }


            spriteBatch.Begin();
            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}