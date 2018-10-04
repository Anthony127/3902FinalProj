﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using System.Threading;

namespace Sprint0.States.Mario
{
    class WalkMarioLeftSprite : ISprite
    {
        private Texture2D spriteSheet;
        private int currentFrame;
        private int totalFrames;

        public WalkMarioLeftSprite(Texture2D texture)
        {
            spriteSheet = texture;
            currentFrame = 0;
            totalFrames = 15;

        }

        public void Update()
        {
            currentFrame = (currentFrame + 1) % totalFrames;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;

            if (currentFrame < 5)
            {
                sourceRectangle = new Rectangle(169, 76, 15, 28);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 15, 28);
            }
            else if (currentFrame < 10)
            {
                sourceRectangle = new Rectangle(8, 76, 16, 28);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 16, 28);
            }
            else
            {
                sourceRectangle = new Rectangle(48, 76, 16, 28);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 16, 28);
            }

            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, color);
        }
    }
}