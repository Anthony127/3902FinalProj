﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.States.Mario
{
    class WalkSmallMarioRightSprite : ISprite
    {
        private Texture2D spriteSheet;
        private int currentFrame;
        private int totalFrames;

        public WalkSmallMarioRightSprite(Texture2D texture)
        {
            spriteSheet = texture;
            currentFrame = 0;
            totalFrames = 20;

        }

        public void Update()
        {
            currentFrame = (currentFrame + 1) % totalFrames;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;

            if (currentFrame < 10)
            {
                sourceRectangle = new Rectangle(209, 0, 13, 19);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 13, 19);
            }
            else
            {
                sourceRectangle = new Rectangle(328, 0, 14, 19);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 14, 19);
            }

            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, color);
        }
    }
}
